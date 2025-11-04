using SS;

namespace GUI
{
    partial class SpreadsheetGUI
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            newToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            panelTop = new TableLayoutPanel();
            label1 = new Label();
            CellNameBox = new TextBox();
            label2 = new Label();
            CellValueBox = new TextBox();
            label3 = new Label();
            contentRow = new TableLayoutPanel();
            CellContentBox = new TextBox();
            EnterButton = new Button();
            menuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            contentRow.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1200, 40);
            menuStrip1.TabIndex = 1;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 36);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(205, 44);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(205, 44);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // panelTop
            // 
            panelTop.AutoSize = true;
            panelTop.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panelTop.ColumnCount = 6;
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 130F));
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTop.Controls.Add(label1, 0, 0);
            panelTop.Controls.Add(CellNameBox, 1, 0);
            panelTop.Controls.Add(label2, 2, 0);
            panelTop.Controls.Add(CellValueBox, 3, 0);
            panelTop.Controls.Add(label3, 4, 0);
            panelTop.Controls.Add(contentRow, 5, 0);
            panelTop.Dock = DockStyle.Top;
            panelTop.Location = new Point(0, 40);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 8, 10, 8);
            panelTop.RowCount = 1;
            panelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            panelTop.Size = new Size(1200, 36);
            panelTop.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 18);
            label1.Margin = new Padding(0, 10, 8, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 10);
            label1.TabIndex = 0;
            label1.Text = "Name";
            label1.Click += label1_Click;
            // 
            // CellNameBox
            // 
            CellNameBox.Location = new Point(96, 13);
            CellNameBox.Margin = new Padding(0, 5, 16, 0);
            CellNameBox.Name = "CellNameBox";
            CellNameBox.ReadOnly = true;
            CellNameBox.Size = new Size(100, 39);
            CellNameBox.TabIndex = 1;
            CellNameBox.TextAlign = HorizontalAlignment.Center;
            CellNameBox.TextChanged += CellNameBox_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(226, 18);
            label2.Margin = new Padding(0, 10, 8, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 10);
            label2.TabIndex = 2;
            label2.Text = "Value";
            label2.Click += label2_Click;
            // 
            // CellValueBox
            // 
            CellValueBox.Location = new Point(306, 13);
            CellValueBox.Margin = new Padding(0, 5, 16, 0);
            CellValueBox.Name = "CellValueBox";
            CellValueBox.ReadOnly = true;
            CellValueBox.Size = new Size(100, 39);
            CellValueBox.TabIndex = 3;
            CellValueBox.TextAlign = HorizontalAlignment.Center;
            CellValueBox.TextChanged += CellValueBox_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(456, 18);
            label3.Margin = new Padding(0, 10, 8, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 10);
            label3.TabIndex = 4;
            label3.Text = "Content";
            label3.Click += label3_Click;
            // 
            // contentRow
            // 
            contentRow.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            contentRow.ColumnStyles.Add(new ColumnStyle());
            contentRow.Controls.Add(CellContentBox, 0, 0);
            contentRow.Controls.Add(EnterButton, 1, 0);
            contentRow.Location = new Point(567, 11);
            contentRow.Name = "contentRow";
            contentRow.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            contentRow.Size = new Size(200, 14);
            contentRow.TabIndex = 5;
            // 
            // CellContentBox
            // 
            CellContentBox.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            CellContentBox.Location = new Point(0, 5);
            CellContentBox.Margin = new Padding(0, 5, 10, 0);
            CellContentBox.Name = "CellContentBox";
            CellContentBox.Size = new Size(111, 39);
            CellContentBox.TabIndex = 0;
            CellContentBox.TextChanged += CellContentBox_TextChanged;
            // 
            // EnterButton
            // 
            EnterButton.AutoSize = true;
            EnterButton.Location = new Point(121, 3);
            EnterButton.Margin = new Padding(0, 3, 0, 0);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(79, 17);
            EnterButton.TabIndex = 1;
            EnterButton.Text = "Enter";
            EnterButton.Click += EnterButton_Click;
            // 
            // SpreadsheetGUI
            // 
            ClientSize = new Size(1200, 800);
            Controls.Add(panelTop);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SpreadsheetGUI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Spreadsheet";
            Load += SpreadsheetGUI_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            contentRow.ResumeLayout(false);
            contentRow.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        private SpreadsheetPanel spreadsheetPanel1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripMenuItem closeToolStripMenuItem;
        private Label label1;
        private TextBox CellNameBox;
        private Label label2;
        private TextBox CellValueBox;
        private Label label3;
        private TextBox CellContentBox;
        private Button EnterButton;
        private TableLayoutPanel panelTop;
        private TableLayoutPanel contentRow;
    }
}