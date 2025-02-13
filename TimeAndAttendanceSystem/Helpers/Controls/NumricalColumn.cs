using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;

namespace BasicExample.DataGridViewColumns
{
    /// <summary>
    /// Provides a numeric column for the DataGridView control.
    /// </summary>
    public class NumericColumn : DataGridViewColumn
    {
        public NumericColumn() : base(new NumericCell()) { }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value != null && !(value is NumericCell))
                {
                    throw new InvalidCastException("Must be a NumericCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class NumericCell : DataGridViewTextBoxCell
    {
        public NumericCell()
        {
            DefaultValue = 0;
        }

        /// <summary>
        /// Default numeric value
        /// </summary>
        public int DefaultValue { get; set; }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            if (DataGridView.EditingControl is NumericEditingControl control)
            {
                if (Value == null || Convert.IsDBNull(Value))
                {
                    control.Value = DefaultValue;
                }
                else
                {
                    control.Value = Convert.ToInt32(Value);
                }
            }
        }

        public override Type EditType => typeof(NumericEditingControl);
        public override Type ValueType => typeof(int);
        public override object DefaultNewRowValue => DefaultValue;
    }

    /// <summary>
    /// Provides numeric input within the DataGridView.
    /// </summary>
    public class NumericEditingControl : NumericUpDown, IDataGridViewEditingControl
    {
        private DataGridView _dataGridViewControl;
        private bool _valueChanged;
        private int _rowIndexNumber;

        public NumericEditingControl()
        {
            Minimum = int.MinValue;
            Maximum = int.MaxValue;
            DecimalPlaces = 0; // السماح فقط بالأرقام الصحيحة

            // ربط حدث KeyDown لالتقاط الضغط على Enter
            this.KeyDown += NumericEditingControl_KeyDown;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditingControlFormattedValue
        {
            get => Value.ToString(CultureInfo.InvariantCulture);
            set
            {
                if (value is string strValue && int.TryParse(strValue, out int parsedValue))
                {
                    Value = parsedValue;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Value.ToString(CultureInfo.InvariantCulture);
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            ForeColor = dataGridViewCellStyle.ForeColor;
            BackColor = dataGridViewCellStyle.BackColor;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int EditingControlRowIndex
        {
            get => _rowIndexNumber;
            set => _rowIndexNumber = value;
        }

        public bool EditingControlWantsInputKey(Keys key, bool dataGridViewWantsInputKey)
        {
            return key is Keys.Left or Keys.Right or Keys.Up or Keys.Down or
                   Keys.Home or Keys.End or Keys.PageDown or Keys.PageUp or
                   Keys.Enter; // السماح بالتقاط مفتاح Enter
        }

        public void PrepareEditingControlForEdit(bool selectAll) { }

        public bool RepositionEditingControlOnValueChange => false;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public DataGridView EditingControlDataGridView
        {
            get => _dataGridViewControl;
            set => _dataGridViewControl = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditingControlValueChanged
        {
            get => _valueChanged;
            set
            {
                _valueChanged = value;
                _dataGridViewControl?.NotifyCurrentCellDirty(value);
            }
        }

        public Cursor EditingPanelCursor => Cursors.Default;

        protected override void OnValueChanged(EventArgs eventArgs)
        {
            _valueChanged = true;
            _dataGridViewControl?.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventArgs);
        }

        private void NumericEditingControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                // إنهاء التحرير وحفظ التعديل عند الضغط على Enter
                _dataGridViewControl.CurrentCell = null; // إلغاء التحديد
                e.Handled = true;
            }
        }
    }

}
