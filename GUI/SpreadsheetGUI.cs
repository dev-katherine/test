using SpreadsheetUtilities;
using SS;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Linq;

namespace GUI
{
    /// <summary>
    /// Class for Spreadsheet GUI
    /// </summary 
    public partial class SpreadsheetGUI : Form
    {
        private Spreadsheet spreadsheet;
        private string fileName;

        private Dictionary<string, Color> cellColors;

        /// <summary>
        /// Consturctor 
        /// </summary>
        public SpreadsheetGUI()
        {
            InitializeComponent();
            spreadsheet = new Spreadsheet(s => Regex.IsMatch(s, @"^[a-zA-Z][1-9][0-9]?$"), s => s.ToUpper(), "six");
            InitializeSpreadsheetGUI();
            spreadsheetPanel1.SetSelection(0, 0);

            cellColors = new Dictionary<string, Color>();

            CellContentBox.KeyDown += CellContentBox_KeyDown;
            spreadsheetPanel1.Paint += SpreadsheetPanel1_Paint;

        }

        private void CellContentBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                EnterButton_Click(sender, e);
                e.SuppressKeyPress = true;
            }
        }


        /// <summary>
        /// Initialize event handler 
        /// </summary>
        private void InitializeSpreadsheetGUI()
        {
            spreadsheetPanel1.SelectionChanged += (ss) => UpdateSpreadsheetUI();
        }


        /// <summary>
        /// update displayed cell information 
        /// </summary>
        private void UpdateSpreadsheetUI()
        {
            string cellName = GetCellName();
            displaySelection(cellName);
        }

        /// <summary>
        /// Gets the currently selected cell name
        /// </summary>
        private string GetCellName()
        {
            spreadsheetPanel1.GetSelection(out int col, out int row);
            char COL = (char)('A' + col);
            int ROW = row + 1;
            return $"{COL}{ROW}";
        }

        /// <summary>
        /// Display content and value of selected cell
        /// </summary>
        private void displaySelection(string cellName)
        {
            CellNameBox.Text = cellName;
            var content = spreadsheet.GetCellContents(cellName);
            var value = spreadsheet.GetCellValue(cellName);
            CellContentBox.Text = content is Formula ? "=" + content : content.ToString();
            CellValueBox.Text = value is FormulaError ? ((FormulaError)value).Reason : value.ToString();
        }

        ///<summary>
        /// open new spreadsheet - handle "NEW" menu click
        /// </summary>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spreadsheet.Changed)
            {
                var result = MessageBox.Show("Unsaved Changes Exist",
                                                "Unsaved",
                                                MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                {
                    SaveCurrentSpreadsheet();
                    if (spreadsheet.Changed)
                        return;
                }
                else if (result == DialogResult.Cancel)
                    return;
            }
            SpreadsheetApplicationContext.getAppContext().RunForm(new SpreadsheetGUI());
        }

        /// <summary>
        /// closes spreadsheet window - ahndles "Close" menu click
        /// </summary>
        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spreadsheet.Changed)
            {
                var result = MessageBox.Show(
                    "Unsaved Changes Exist",
                    "Unsave",
                    MessageBoxButtons.YesNoCancel);

                if (result == DialogResult.Yes)
                {
                    SaveCurrentSpreadsheet();
                    if (spreadsheet.Changed)
                        return;
                }
                else if (result == DialogResult.Cancel)
                    return;
            }
            Close();
        }


        /// <summary>
        /// set cell contents - Handles Enter button click
        /// </summary>
        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                var dependents = spreadsheet.SetContentsOfCell(CellNameBox.Text, CellContentBox.Text);
                foreach (var cell in dependents)
                    UpdateCellUI(cell);
            }
            catch (Exception ex) when (ex is FormulaFormatException || ex is CircularException)
            {
                MessageBox.Show($"Error: {ex.Message}", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        ///<summary>
        /// updates a single cell value of panel
        /// </summary>
        private void UpdateCellUI(string cellName)
        {
            int col = cellName[0] - 'A';
            int row = int.Parse(cellName.Substring(1)) - 1;
            var cellValue = spreadsheet.GetCellValue(cellName);

            spreadsheetPanel1.SetValue(col, row, cellValue.ToString());

            Color cellColor = setCellColor(cellValue);
            cellColors[cellName] = cellColor;

            spreadsheetPanel1.Invalidate();
        }

        private Color setCellColor(object cellValue)
        {
            if (cellValue is FormulaError)
                return Color.FromArgb(255, 229, 204);
            else if (cellValue is double)
            {
                double numValue = (double)cellValue;
                if (numValue < 0)
                    return Color.FromArgb(255, 224, 224);
                else if (numValue == 0)
                    return Color.FromArgb(255, 255, 204);
                else
                    return Color.FromArgb(224, 255, 224);
            }
            else
                return Color.White;
        }

        private void SpreadsheetPanel1_Paint(object sender, PaintEventArgs e)
        {

            const int LABEL_COL_WIDTH = 30;
            const int LABEL_ROW_HEIGHT = 30;
            const int DATA_COL_WIDTH = 80;
            const int DATA_ROW_HEIGHT = 20;


            foreach (var kvp in cellColors)
            {
                string cellName = kvp.Key;
                Color color = kvp.Value;

                int col = cellName[0] - 'A';
                int row = int.Parse(cellName.Substring(1)) - 1;

                int x = LABEL_COL_WIDTH + col * DATA_COL_WIDTH;
                int y = LABEL_ROW_HEIGHT + row * DATA_ROW_HEIGHT;

                using (SolidBrush brush = new SolidBrush(color))
                {
                    e.Graphics.FillRectangle(brush, x + 1, y + 1, DATA_COL_WIDTH - 2, DATA_ROW_HEIGHT - 2);
                }
            }
        }

        ///<summary>
        /// Displays help message box
        /// </summary>
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(
                "Spreadsheet HELP!:\n\n" +
                "1. Click a cell to select.\n" +
                "2. Edit or insert content in the top textbox and press Enter.\n" +
                "3. To Insert Formula, use prefix '=' in Formula\n" +
                "- Unsaved changes will prompt a warning before closing.",
                "Help",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }

        /// <summary>
        /// open existing spreadsheet file - handle "Open" menu
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (spreadsheet.Changed)
            {
                var result = MessageBox.Show(
                    "Unsaved Changed Exist:",
                    "Unsaved",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning
                );
                if (result == DialogResult.Yes)
                {
                    SaveCurrentSpreadsheet();
                    if (spreadsheet.Changed)
                        return;
                }
                else if (result == DialogResult.Cancel)
                {
                    return;
                }
            }

            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Filter = "Spreadsheet Files (*.sprd)|*.sprd|All Files (*.*)|*.*";
                dialog.Title = "Open Spreadsheet";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        spreadsheet = new Spreadsheet(
                            dialog.FileName,
                            s => true,
                            s => s.ToUpper(),
                            "Six"
                        );

                        spreadsheetPanel1.Clear();
                        fileName = dialog.FileName;

                        foreach (string cell in spreadsheet.GetNamesOfAllNonemptyCells())
                        {
                            UpdateCellUI(cell);
                        }

                        spreadsheetPanel1.SetSelection(0, 0);
                        UpdateSpreadsheetUI();

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(
                            $"Spreadsheet loading error",
                            "Open Error",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                    }
                }
            }
        }


        /// <summary>
        /// save current spreadsheet - handle "Save" menu
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveCurrentSpreadsheet();
        }

        /// <summary>
        /// Save the current spreadsheet to file
        /// </summary>
        private void SaveCurrentSpreadsheet()
        {
            try
            {
                if (string.IsNullOrEmpty(fileName))
                {
                    using (SaveFileDialog saveDialog = new SaveFileDialog())
                    {
                        saveDialog.Filter = "Spreadsheet Files (*.sprd)|*.sprd|All Files (*.*)|*.*";
                        saveDialog.DefaultExt = "sprd";
                        saveDialog.AddExtension = true;

                        if (saveDialog.ShowDialog() == DialogResult.OK)
                        {
                            string selectedFile = saveDialog.FileName;

                            if (!selectedFile.EndsWith(".sprd"))
                                selectedFile += ".sprd";

                            if (File.Exists(selectedFile))
                            {
                                var result = MessageBox.Show(
                                    $"File '{Path.GetFileName(selectedFile)}' already exists. Overwrite?",
                                    "Overwrite",
                                    MessageBoxButtons.YesNo,
                                    MessageBoxIcon.Warning);

                                if (result != DialogResult.Yes)
                                    return;
                            }
                            spreadsheet.Save(selectedFile);
                            fileName = selectedFile;
                            MessageBox.Show("Spreadsheet saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
                else
                {
                    spreadsheet.Save(fileName);
                    MessageBox.Show("Spreadsheet saved successfully!", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving spreadsheet: {ex.Message}", "Save Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }





        /// <summary>
        /// Placeholder for CellContentBox text change
        /// </summary>
        private void CellContentBox_TextChanged(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for CellValueBox text change
        /// </summary>
        private void CellValueBox_TextChanged(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for CellNameBox text change
        /// </summary>
        private void CellNameBox_TextChanged(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for load event
        /// </summary>
        private void SpreadsheetGUI_Load(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for label1 click event
        /// </summary>
        private void label1_Click(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for label2 click event
        /// </summary>
        private void label2_Click(object sender, EventArgs e) { }
        /// <summary>
        /// Placeholder for label3 click event
        /// </summary>
        private void label3_Click(object sender, EventArgs e) { }


    }
}