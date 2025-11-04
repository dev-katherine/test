/// <summary>
/// /// Author:    Katherine Jang, Chloe Shin
/// Partner:   Katherine Jang, Chloe Shin 
/// Date:      3/11/2025
/// Course:    CS 3500, University of Utah, School of Computing 
/// Copyright: CS 3500 and Katherine Jang - This work may not be copied for use in Academic Coursework. 
/// 
/// I, Katherine Jang , certify that I wrote this code from scratch and did not copy it in part or whole from
/// another source.  All references used in the completion of the assignment are cited in my README file. 
/// 
/// This file implements the Spreadsheet GUI with Window Forms.
/// The Designer.cs file contains components config of the window forms gui.
/// SpreadsheetGUI class includes event handling which is occured by user interaction.
/// </summary>

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
            openToolStripMenuItem = new ToolStripMenuItem();
            saveToolStripMenuItem = new ToolStripMenuItem();
            closeToolStripMenuItem = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            panelTop = new TableLayoutPanel();
            label1 = new Label();
            CellNameBox = new TextBox();
            label2 = new Label();
            CellValueBox = new TextBox();
            label3 = new Label();
            CellContentBox = new TextBox();
            EnterButton = new Button();
            spreadsheetPanel1 = new SpreadsheetPanel();
            menuStrip1.SuspendLayout();
            panelTop.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.AutoSize = false;
            menuStrip1.ImageScalingSize = new Size(32, 32);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1200, 36);
            menuStrip1.TabIndex = 2;
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { newToolStripMenuItem, openToolStripMenuItem, saveToolStripMenuItem, closeToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(71, 32);
            fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            newToolStripMenuItem.Name = "newToolStripMenuItem";
            newToolStripMenuItem.Size = new Size(359, 44);
            newToolStripMenuItem.Text = "New";
            newToolStripMenuItem.Click += newToolStripMenuItem_Click;
            // 
            // openToolStripMenuItem
            // 
            openToolStripMenuItem.Name = "openToolStripMenuItem";
            openToolStripMenuItem.Size = new Size(359, 44);
            openToolStripMenuItem.Text = "Open";
            openToolStripMenuItem.Click += openToolStripMenuItem_Click;
            // 
            // saveToolStripMenuItem
            // 
            saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            saveToolStripMenuItem.Size = new Size(359, 44);
            saveToolStripMenuItem.Text = "Save";
            saveToolStripMenuItem.Click += saveToolStripMenuItem_Click_1;
            // 
            // closeToolStripMenuItem
            // 
            closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            closeToolStripMenuItem.Size = new Size(359, 44);
            closeToolStripMenuItem.Text = "Close";
            closeToolStripMenuItem.Click += closeToolStripMenuItem_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(84, 32);
            helpToolStripMenuItem.Text = "Help";
            helpToolStripMenuItem.Click += helpToolStripMenuItem_Click;
            // 
            // panelTop
            // 
            panelTop.ColumnCount = 7;
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 160F));
            panelTop.ColumnStyles.Add(new ColumnStyle());
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            panelTop.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 90F));
            panelTop.Controls.Add(label1, 0, 0);
            panelTop.Controls.Add(CellNameBox, 1, 0);
            panelTop.Controls.Add(label2, 2, 0);
            panelTop.Controls.Add(CellValueBox, 3, 0);
            panelTop.Controls.Add(label3, 4, 0);
            panelTop.Controls.Add(CellContentBox, 5, 0);
            panelTop.Controls.Add(EnterButton, 6, 0);
            panelTop.Dock = DockStyle.Top;
            panelTop.GrowStyle = TableLayoutPanelGrowStyle.FixedSize;
            panelTop.Location = new Point(0, 36);
            panelTop.Name = "panelTop";
            panelTop.Padding = new Padding(10, 6, 10, 6);
            panelTop.RowCount = 1;
            panelTop.RowStyles.Add(new RowStyle(SizeType.Absolute, 44F));
            panelTop.Size = new Size(1200, 56);
            panelTop.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(10, 16);
            label1.Margin = new Padding(0, 10, 8, 0);
            label1.Name = "label1";
            label1.Size = new Size(78, 32);
            label1.TabIndex = 0;
            label1.Text = "Name";
            // 
            // CellNameBox
            // 
            CellNameBox.Location = new Point(96, 12);
            CellNameBox.Margin = new Padding(0, 6, 16, 0);
            CellNameBox.MinimumSize = new Size(120, 28);
            CellNameBox.Name = "CellNameBox";
            CellNameBox.ReadOnly = true;
            CellNameBox.Size = new Size(120, 39);
            CellNameBox.TabIndex = 1;
            CellNameBox.TextAlign = HorizontalAlignment.Center;
            CellNameBox.TextChanged += CellNameBox_TextChanged_2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(246, 16);
            label2.Margin = new Padding(0, 10, 8, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 32);
            label2.TabIndex = 2;
            label2.Text = "Value";
            // 
            // CellValueBox
            // 
            CellValueBox.Location = new Point(326, 12);
            CellValueBox.Margin = new Padding(0, 6, 16, 0);
            CellValueBox.MinimumSize = new Size(140, 28);
            CellValueBox.Name = "CellValueBox";
            CellValueBox.ReadOnly = true;
            CellValueBox.Size = new Size(140, 39);
            CellValueBox.TabIndex = 3;
            CellValueBox.TextAlign = HorizontalAlignment.Center;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(486, 16);
            label3.Margin = new Padding(0, 10, 8, 0);
            label3.Name = "label3";
            label3.Size = new Size(100, 32);
            label3.TabIndex = 4;
            label3.Text = "Content";
            // 
            // CellContentBox
            // 
            CellContentBox.Dock = DockStyle.Fill;
            CellContentBox.Location = new Point(594, 12);
            CellContentBox.Margin = new Padding(0, 6, 10, 0);
            CellContentBox.MinimumSize = new Size(200, 28);
            CellContentBox.Name = "CellContentBox";
            CellContentBox.Size = new Size(496, 39);
            CellContentBox.TabIndex = 5;
            // 
            // EnterButton
            // 
            EnterButton.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            EnterButton.AutoSize = true;
            EnterButton.Location = new Point(1111, 12);
            EnterButton.Margin = new Padding(0, 6, 0, 0);
            EnterButton.Name = "EnterButton";
            EnterButton.Size = new Size(79, 38);
            EnterButton.TabIndex = 6;
            EnterButton.Text = "Enter";
            EnterButton.Click += EnterButton_Click;
            // 
            // spreadsheetPanel1
            // 
            spreadsheetPanel1.Dock = DockStyle.Fill;
            spreadsheetPanel1.Location = new Point(0, 92);
            spreadsheetPanel1.Name = "spreadsheetPanel1";
            spreadsheetPanel1.Size = new Size(1200, 708);
            spreadsheetPanel1.TabIndex = 0;
            // 
            // SpreadsheetGUI
            // 
            AutoScaleDimensions = new SizeF(192F, 192F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1200, 800);
            Controls.Add(spreadsheetPanel1);
            Controls.Add(panelTop);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "SpreadsheetGUI";
            Text = "Spreadsheet";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelTop.ResumeLayout(false);
            panelTop.PerformLayout();
            ResumeLayout(false);
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
        private ToolStripMenuItem saveToolStripMenuItem;
        private ToolStripMenuItem openToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;

        //

    }
}