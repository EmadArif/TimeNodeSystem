namespace TimeAndAttendanceSystem.Controls
{
    partial class WeeklyTableControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSave = new Button();
            label3 = new Label();
            txtName = new TextBox();
            dataGridView1 = new DataGridView();
            Enable = new DataGridViewCheckBoxColumn();
            Day = new DataGridViewTextBoxColumn();
            From = new BasicExample.DataGridViewColumns.TimePickerColumn();
            To = new BasicExample.DataGridViewColumns.TimePickerColumn();
            Time = new DataGridViewTextBoxColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnSave, 0, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(439, 380);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // btnSave
            // 
            tableLayoutPanel1.SetColumnSpan(btnSave, 2);
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(3, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(433, 29);
            btnSave.TabIndex = 7;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(433, 23);
            label3.TabIndex = 5;
            label3.Text = "Name";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            tableLayoutPanel1.SetColumnSpan(txtName, 2);
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(3, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(433, 27);
            txtName.TabIndex = 6;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { Enable, Day, From, To, Time });
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(3, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(433, 209);
            dataGridView1.TabIndex = 0;
            // 
            // Enable
            // 
            Enable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Enable.DataPropertyName = "Enable";
            Enable.HeaderText = "Enable";
            Enable.MinimumWidth = 6;
            Enable.Name = "Enable";
            Enable.Resizable = DataGridViewTriState.True;
            Enable.Width = 60;
            // 
            // Day
            // 
            Day.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Day.FillWeight = 30F;
            Day.HeaderText = "Day";
            Day.MinimumWidth = 6;
            Day.Name = "Day";
            Day.ReadOnly = true;
            Day.Resizable = DataGridViewTriState.False;
            Day.SortMode = DataGridViewColumnSortMode.NotSortable;
            Day.Width = 41;
            // 
            // From
            // 
            From.HeaderText = "From";
            From.MinimumWidth = 6;
            From.Name = "From";
            From.Resizable = DataGridViewTriState.True;
            // 
            // To
            // 
            To.HeaderText = "To";
            To.MinimumWidth = 6;
            To.Name = "To";
            To.Resizable = DataGridViewTriState.True;
            // 
            // Time
            // 
            Time.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            Time.HeaderText = "Time";
            Time.MinimumWidth = 6;
            Time.Name = "Time";
            Time.ReadOnly = true;
            Time.Resizable = DataGridViewTriState.False;
            Time.SortMode = DataGridViewColumnSortMode.NotSortable;
            Time.Width = 48;
            // 
            // WeeklyTableControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "WeeklyTableControl";
            Size = new Size(439, 380);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Button btnSave;
        private Label label3;
        private TextBox txtName;
        private DataGridView dataGridView1;
        private DataGridViewCheckBoxColumn Enable;
        private DataGridViewTextBoxColumn Day;
        private BasicExample.DataGridViewColumns.TimePickerColumn From;
        private BasicExample.DataGridViewColumns.TimePickerColumn To;
        private DataGridViewTextBoxColumn Time;
    }
}
