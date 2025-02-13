namespace TimeAndAttendanceSystem
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            treeView1 = new TreeView();
            contextMenuStrip1 = new ContextMenuStrip(components);
            dateToolStripMenuItem = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripMenuItem();
            twoDaysToolStripMenuItem = new ToolStripMenuItem();
            weeklyToolStripMenuItem = new ToolStripMenuItem();
            monthlyToolStripMenuItem = new ToolStripMenuItem();
            removeToolStripMenuItem = new ToolStripMenuItem();
            upToolStripMenuItem = new ToolStripMenuItem();
            downToolStripMenuItem = new ToolStripMenuItem();
            propertiesPanel = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            DaysPanel = new Panel();
            daysDgv = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            Day = new DataGridViewTextBoxColumn();
            From = new DataGridViewTextBoxColumn();
            To = new DataGridViewTextBoxColumn();
            Time = new DataGridViewTextBoxColumn();
            contextMenuStrip1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            DaysPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)daysDgv).BeginInit();
            SuspendLayout();
            // 
            // treeView1
            // 
            treeView1.Dock = DockStyle.Fill;
            treeView1.Location = new Point(3, 3);
            treeView1.Name = "treeView1";
            treeView1.ShowNodeToolTips = true;
            treeView1.Size = new Size(310, 498);
            treeView1.TabIndex = 0;
            treeView1.MouseDown += treeView1_MouseDown;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { dateToolStripMenuItem, toolStripMenuItem1, removeToolStripMenuItem, upToolStripMenuItem, downToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(138, 134);
            // 
            // dateToolStripMenuItem
            // 
            dateToolStripMenuItem.Name = "dateToolStripMenuItem";
            dateToolStripMenuItem.Size = new Size(137, 26);
            dateToolStripMenuItem.Tag = "1";
            dateToolStripMenuItem.Text = "Parents";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.DropDownItems.AddRange(new ToolStripItem[] { toolStripMenuItem2, twoDaysToolStripMenuItem, weeklyToolStripMenuItem, monthlyToolStripMenuItem });
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(137, 26);
            toolStripMenuItem1.Text = "Childern";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(151, 26);
            toolStripMenuItem2.Tag = "1";
            toolStripMenuItem2.Text = "Daily";
            // 
            // twoDaysToolStripMenuItem
            // 
            twoDaysToolStripMenuItem.Name = "twoDaysToolStripMenuItem";
            twoDaysToolStripMenuItem.Size = new Size(151, 26);
            twoDaysToolStripMenuItem.Tag = "1";
            twoDaysToolStripMenuItem.Text = "TwoDays";
            // 
            // weeklyToolStripMenuItem
            // 
            weeklyToolStripMenuItem.Name = "weeklyToolStripMenuItem";
            weeklyToolStripMenuItem.Size = new Size(151, 26);
            weeklyToolStripMenuItem.Tag = "2";
            weeklyToolStripMenuItem.Text = "Weekly";
            // 
            // monthlyToolStripMenuItem
            // 
            monthlyToolStripMenuItem.Name = "monthlyToolStripMenuItem";
            monthlyToolStripMenuItem.Size = new Size(151, 26);
            monthlyToolStripMenuItem.Tag = "3";
            monthlyToolStripMenuItem.Text = "Monthly";
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Image = (Image)resources.GetObject("removeToolStripMenuItem.Image");
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new Size(137, 26);
            removeToolStripMenuItem.Text = "Remove";
            // 
            // upToolStripMenuItem
            // 
            upToolStripMenuItem.Name = "upToolStripMenuItem";
            upToolStripMenuItem.Size = new Size(137, 26);
            upToolStripMenuItem.Text = "Up";
            // 
            // downToolStripMenuItem
            // 
            downToolStripMenuItem.Name = "downToolStripMenuItem";
            downToolStripMenuItem.Size = new Size(137, 26);
            downToolStripMenuItem.Text = "Down";
            // 
            // propertiesPanel
            // 
            propertiesPanel.AutoSize = true;
            propertiesPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            propertiesPanel.BackColor = SystemColors.ActiveCaption;
            propertiesPanel.Dock = DockStyle.Fill;
            propertiesPanel.Location = new Point(319, 3);
            propertiesPanel.Name = "propertiesPanel";
            propertiesPanel.Size = new Size(404, 498);
            propertiesPanel.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 43.47826F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56.52174F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 400F));
            tableLayoutPanel1.Controls.Add(DaysPanel, 2, 0);
            tableLayoutPanel1.Controls.Add(propertiesPanel, 1, 0);
            tableLayoutPanel1.Controls.Add(treeView1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1127, 504);
            tableLayoutPanel1.TabIndex = 2;
            // 
            // DaysPanel
            // 
            DaysPanel.AutoSize = true;
            DaysPanel.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            DaysPanel.BackColor = SystemColors.ActiveCaption;
            DaysPanel.Controls.Add(daysDgv);
            DaysPanel.Dock = DockStyle.Fill;
            DaysPanel.Location = new Point(729, 3);
            DaysPanel.Name = "DaysPanel";
            DaysPanel.Size = new Size(395, 498);
            DaysPanel.TabIndex = 2;
            // 
            // daysDgv
            // 
            daysDgv.AllowUserToAddRows = false;
            daysDgv.AllowUserToDeleteRows = false;
            daysDgv.AllowUserToResizeColumns = false;
            daysDgv.AllowUserToResizeRows = false;
            daysDgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            daysDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            daysDgv.Columns.AddRange(new DataGridViewColumn[] { Date, Day, From, To, Time });
            daysDgv.Dock = DockStyle.Fill;
            daysDgv.Location = new Point(0, 0);
            daysDgv.Name = "daysDgv";
            daysDgv.ReadOnly = true;
            daysDgv.RowHeadersVisible = false;
            daysDgv.RowHeadersWidth = 51;
            daysDgv.Size = new Size(395, 498);
            daysDgv.TabIndex = 1;
            // 
            // Date
            // 
            Date.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Date.HeaderText = "Date";
            Date.MinimumWidth = 6;
            Date.Name = "Date";
            Date.ReadOnly = true;
            Date.SortMode = DataGridViewColumnSortMode.NotSortable;
            Date.Width = 47;
            // 
            // Day
            // 
            Day.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Day.DataPropertyName = "Day";
            Day.FillWeight = 30F;
            Day.HeaderText = "Day";
            Day.MinimumWidth = 6;
            Day.Name = "Day";
            Day.ReadOnly = true;
            Day.Resizable = DataGridViewTriState.True;
            Day.SortMode = DataGridViewColumnSortMode.NotSortable;
            Day.Width = 41;
            // 
            // From
            // 
            From.DataPropertyName = "From";
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.ReadOnly = true;
            From.Resizable = DataGridViewTriState.True;
            From.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // To
            // 
            To.DataPropertyName = "To";
            To.HeaderText = "To";
            To.MinimumWidth = 6;
            To.Name = "To";
            To.ReadOnly = true;
            To.Resizable = DataGridViewTriState.True;
            To.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // Time
            // 
            Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Time.DataPropertyName = "Time";
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.SortMode = DataGridViewColumnSortMode.NotSortable;
            Time.Width = 48;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1127, 504);
            Controls.Add(tableLayoutPanel1);
            Name = "Form1";
            Text = "Form1";
            contextMenuStrip1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            DaysPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)daysDgv).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TreeView treeView1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem dateToolStripMenuItem;
        private ToolStripMenuItem toolStripMenuItem1;
        private ToolStripMenuItem toolStripMenuItem2;
        private ToolStripMenuItem twoDaysToolStripMenuItem;
        private ToolStripMenuItem weeklyToolStripMenuItem;
        private ToolStripMenuItem monthlyToolStripMenuItem;
        private Panel propertiesPanel;
        private ToolStripMenuItem removeToolStripMenuItem;
        private TableLayoutPanel tableLayoutPanel1;
        private Panel DaysPanel;
        private DataGridView daysDgv;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Day;
        private DataGridViewTextBoxColumn From;
        private DataGridViewTextBoxColumn To;
        private DataGridViewTextBoxColumn Time;
        private ToolStripMenuItem upToolStripMenuItem;
        private ToolStripMenuItem downToolStripMenuItem;
    }
}
