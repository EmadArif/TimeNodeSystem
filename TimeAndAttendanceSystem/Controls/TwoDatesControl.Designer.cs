namespace TimeAndAttendanceSystem.Controls
{
    partial class TwoDatesControl
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
            label2 = new Label();
            label3 = new Label();
            txtName = new TextBox();
            btnSave = new Button();
            fromDate = new DateTimePicker();
            label1 = new Label();
            toDate = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(label2, 0, 2);
            tableLayoutPanel1.Controls.Add(label3, 0, 0);
            tableLayoutPanel1.Controls.Add(txtName, 0, 1);
            tableLayoutPanel1.Controls.Add(btnSave, 0, 4);
            tableLayoutPanel1.Controls.Add(fromDate, 0, 3);
            tableLayoutPanel1.Controls.Add(label1, 1, 2);
            tableLayoutPanel1.Controls.Add(toDate, 1, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 6;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(402, 410);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Font = new Font("Segoe UI", 10F);
            label2.Location = new Point(3, 56);
            label2.Name = "label2";
            label2.Size = new Size(195, 23);
            label2.TabIndex = 1;
            label2.Text = "From";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(label3, 2);
            label3.Dock = DockStyle.Fill;
            label3.Font = new Font("Segoe UI", 10F);
            label3.Location = new Point(3, 0);
            label3.Name = "label3";
            label3.Size = new Size(396, 23);
            label3.TabIndex = 3;
            label3.Text = "Name";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // txtName
            // 
            tableLayoutPanel1.SetColumnSpan(txtName, 2);
            txtName.Dock = DockStyle.Fill;
            txtName.Location = new Point(3, 26);
            txtName.Name = "txtName";
            txtName.Size = new Size(396, 27);
            txtName.TabIndex = 4;
            // 
            // btnSave
            // 
            tableLayoutPanel1.SetColumnSpan(btnSave, 2);
            btnSave.Dock = DockStyle.Top;
            btnSave.Location = new Point(3, 115);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(396, 29);
            btnSave.TabIndex = 5;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            // 
            // fromDate
            // 
            fromDate.Dock = DockStyle.Fill;
            fromDate.Format = DateTimePickerFormat.Short;
            fromDate.Location = new Point(3, 82);
            fromDate.Name = "fromDate";
            fromDate.Size = new Size(195, 27);
            fromDate.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Segoe UI", 10F);
            label1.Location = new Point(204, 56);
            label1.Name = "label1";
            label1.Size = new Size(195, 23);
            label1.TabIndex = 0;
            label1.Text = "To";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // toDate
            // 
            toDate.Format = DateTimePickerFormat.Short;
            toDate.Location = new Point(204, 82);
            toDate.Name = "toDate";
            toDate.Size = new Size(195, 27);
            toDate.TabIndex = 2;
            // 
            // TwoDatesControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "TwoDatesControl";
            Size = new Size(402, 410);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label2;
        private Label label3;
        private TextBox txtName;
        private Button btnSave;
        private DateTimePicker fromDate;
        private Label label1;
        private DateTimePicker toDate;
    }
}
