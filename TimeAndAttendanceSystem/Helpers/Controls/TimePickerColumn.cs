using System;
using System.Globalization;
using System.Windows.Forms;
using System.ComponentModel;

namespace BasicExample.DataGridViewColumns
{
    /// <summary>
    /// Provides a time picker column for the DataGridView control.
    /// </summary>
    public class TimePickerColumn : DataGridViewColumn
    {
        public TimePickerColumn() : base(new TimePickerCell()) { }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override DataGridViewCell CellTemplate
        {
            get => base.CellTemplate;
            set
            {
                if (value != null && !(value.GetType().IsAssignableFrom(typeof(TimePickerCell))))
                {
                    throw new InvalidCastException("Must be a TimePickerCell");
                }
                base.CellTemplate = value;
            }
        }
    }

    public class TimePickerCell : DataGridViewTextBoxCell
    {
        public TimePickerCell()
        {
            DefaultTime = DateTime.Now;
        }

        /// <summary>
        /// Default time value when the cell is empty.
        /// </summary>
        public DateTime DefaultTime { get; set; }

        public override void InitializeEditingControl(int rowIndex, object initialFormattedValue, DataGridViewCellStyle dataGridViewCellStyle)
        {
            base.InitializeEditingControl(rowIndex, initialFormattedValue, dataGridViewCellStyle);
            if (DataGridView.EditingControl is TimePickerEditingControl timeControl)
            {
                if (Value == null || Convert.IsDBNull(Value))
                {
                    timeControl.Value = DefaultTime;
                }
                else
                {
                    var t = Value.ToString();
                    timeControl.Value = Convert.ToDateTime(t);
                }
            }
        }

        public override Type EditType => typeof(TimePickerEditingControl);
        public override Type ValueType => typeof(TimeOnly);
        public override object DefaultNewRowValue => DateTime.Now;
    }

    /// <summary>
    /// Provides Time Picker within the DataGridView.
    /// </summary>
    public class TimePickerEditingControl : DateTimePicker, IDataGridViewEditingControl
    {
        private DataGridView _dataGridView;
        private bool _valueChanged;
        private int _rowIndex;

        public TimePickerEditingControl()
        {
            Format = DateTimePickerFormat.Custom;
            CustomFormat = "hh:mm tt"; // 24-hour format
            ShowUpDown = true; // Enables time selection without a calendar
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public object EditingControlFormattedValue
        {
            get => Value.ToString("hh:mm tt");
            set
            {
                if (value is string strValue && DateTime.TryParseExact(strValue, "hh:mm tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedTime))
                {
                    Value = parsedTime;
                }
            }
        }

        public object GetEditingControlFormattedValue(DataGridViewDataErrorContexts context)
        {
            var x = Value.ToString("hh:mm tt");
            return x;
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
            get => _rowIndex;
            set => _rowIndex = value;
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
            get => _dataGridView;
            set => _dataGridView = value;
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool EditingControlValueChanged
        {
            get => _valueChanged;
            set
            {
                _valueChanged = value;
                _dataGridView?.NotifyCurrentCellDirty(value);
            }
        }

        public Cursor EditingPanelCursor => Cursors.Default;

        protected override void OnValueChanged(EventArgs eventArgs)
        {
            _valueChanged = true;
            _dataGridView?.NotifyCurrentCellDirty(true);
            base.OnValueChanged(eventArgs);
        }
    }
}
