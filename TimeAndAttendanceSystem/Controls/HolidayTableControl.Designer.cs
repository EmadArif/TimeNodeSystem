namespace TimeAndAttendanceSystem.Controls
{
    partial class HolidayTableControl
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            tableLayoutPanel1 = new TableLayoutPanel();
            btnSave = new Button();
            label3 = new Label();
            txtName = new TextBox();
            dataGridView1 = new DataGridView();
            btnNew = new Button();
            ColEnable = new DataGridViewCheckBoxColumn();
            ColId = new DataGridViewTextBoxColumn();
            ColDay = new DataGridViewTextBoxColumn();
            ColDelete = new DataGridViewButtonColumn();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(btnSave, 1, 3);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(dataGridView1, 0, 2);
            tableLayoutPanel1.Controls.Add(btnNew, 0, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 5;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(458, 409);
            tableLayoutPanel1.TabIndex = 3;
            // 
            // btnSave
            // 
            btnSave.Dock = DockStyle.Fill;
            btnSave.Location = new Point(103, 274);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(352, 29);
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
            label3.Size = new Size(452, 23);
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
            txtName.Size = new Size(452, 27);
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
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { ColEnable, ColId, ColDay, ColDelete });
            tableLayoutPanel1.SetColumnSpan(dataGridView1, 2);
            dataGridView1.Dock = DockStyle.Top;
            dataGridView1.Location = new Point(3, 59);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(452, 209);
            dataGridView1.TabIndex = 0;
            // 
            // btnNew
            // 
            btnNew.Dock = DockStyle.Fill;
            btnNew.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNew.Location = new Point(3, 274);
            btnNew.Name = "btnNew";
            btnNew.Size = new Size(94, 29);
            btnNew.TabIndex = 7;
            btnNew.Text = "+";
            btnNew.UseVisualStyleBackColor = true;
            // 
            // ColEnable
            // 
            ColEnable.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ColEnable.HeaderText = "";
            ColEnable.MinimumWidth = 6;
            ColEnable.Name = "ColEnable";
            ColEnable.Width = 6;
            // 
            // ColId
            // 
            ColId.AutoSizeMode = DataGridViewAutoSizeColumnMode.DisplayedCells;
            ColId.HeaderText = "Id";
            ColId.MinimumWidth = 6;
            ColId.Name = "ColId";
            ColId.SortMode = DataGridViewColumnSortMode.NotSortable;
            ColId.Width = 28;
            // 
            // ColDay
            // 
            ColDay.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            ColDay.FillWeight = 30F;
            ColDay.HeaderText = "Day";
            ColDay.MinimumWidth = 6;
            ColDay.Name = "ColDay";
            ColDay.Resizable = DataGridViewTriState.True;
            ColDay.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // ColDelete
            // 
            ColDelete.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            ColDelete.DataPropertyName = "Delete";
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(255, 128, 128);
            dataGridViewCellStyle1.SelectionBackColor = Color.FromArgb(192, 0, 0);
            ColDelete.DefaultCellStyle = dataGridViewCellStyle1;
            ColDelete.FlatStyle = FlatStyle.Flat;
            ColDelete.HeaderText = "Delete";
            ColDelete.MinimumWidth = 6;
            ColDelete.Name = "ColDelete";
            ColDelete.Resizable = DataGridViewTriState.True;
            ColDelete.Text = "X";
            ColDelete.ToolTipText = "X";
            ColDelete.UseColumnTextForButtonValue = true;
            ColDelete.Width = 59;
            // 
            // HolidayTableControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "HolidayTableControl";
            Size = new Size(458, 409);
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
        private Button btnNew;
        private DataGridViewCheckBoxColumn ColEnable;
        private DataGridViewTextBoxColumn ColId;
        private DataGridViewTextBoxColumn ColDay;
        private DataGridViewButtonColumn ColDelete;
    }
}
