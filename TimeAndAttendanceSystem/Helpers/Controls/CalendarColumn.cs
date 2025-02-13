using System;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

namespace BasicExample.DataGridViewColumns
{
    /// <summary>
    /// Provides a calendar column for the DataGridView control.
    /// Original code from Microsoft https://tinyurl.com/y8nr9okh
    /// </summary>
    public class CalendarColumn : DataGridViewColumn
    {
        public CalendarColumn() : base(new CalendarCell()) { }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value != null && !(value.GetType().IsAssignableFrom(typeof(CalendarCell))))
                {
                    throw new InvalidCastException("Must be a CalendarCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class CalendarCell : DataGridViewTextBoxCell
    {
        public CalendarCell()
        {
            EmptyDate = DateTime.Now;
        }

        /// <summary>
        /// Set default Date
        /// </summary>
        public DateTime EmptyDate { get; set; }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            if (DataGridView.EditingControl is CalendarEditingControl theControl)
            {
                if (Value == null || Convert.IsDBNull(Value))
                {
                    theControl.Value = DateTime.Now;
                }
                else
                {
                    theControl.Value = Convert.ToDateTime(Value);
                }
            }
        }

        public override Type EditType => typeof(CalendarEditingControl);
        public override Type ValueType => typeof(DateTime);
        public override object DefaultNewRowValue => DateTime.Now;
    }

    /// <summary>
    /// Provides Calendar popup within the DataGridView.
    /// </summary>
    public class CalendarEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridViewControl;
        private bool _valueChanged;
        private int _rowIndexNumber;

        public CalendarEditingControl()
        {
            Format = DateTimePickerFormat.Short;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditingControlFormattedValue
        {
            get => Value.ToShortDateString();
            set
            {
                if (value is string strValue && DateTime.TryParse(strValue, out DateTime parsedDate))
                {
                    Value = parsedDate;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            return Value.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
        }

        public void ApplyCellStyleToEditingControl(DataGridViewCellStyle dataGridViewCellStyle)
        {
            Font = dataGridViewCellStyle.Font;
            CalendarForeColor = dataGridViewCellStyle.ForeColor;
            CalendarMonthBackground = dataGridViewCellStyle.BackColor;
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
                   Keys.Home or Keys.End or Keys.PageDown or Keys.PageUp;
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

        public Cursor EditingPanelCursor => Cursors.Default; // Fixed Cursor Implementation

        protected override void OnValueChanged(EventArgs eventArgs)
        {
            _valueChanged = true;
            _dataGridViewControl?.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventArgs);
        }
    }
}
