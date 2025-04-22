using System.Data;
using TimeAndAttendanceSystem.Helpers.Extensions;
using TimeAndAttendanceSystem.Nodes;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class HolidayTableControl : UserControl
    {
        private HolidayNode _node;
        public Action? OnSave;

        public HolidayTableControl(HolidayNode node)
        {
            InitializeComponent();

            _node = node;

            dataGridView1.AutoGenerateColumns = false;


            dataGridView1.CallDgvRowDirty((r) =>
            {
                if (r.Index >= _node.Holidays.Count())
                    return true;

                var dayName = r.Cells[ColDay.Index].Value?.ToString();
                var day = _node.Holidays[r.Index];

                return day.Enabled;
            });

            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;

            SetControls(node);

            AdjustDataGridViewHeight(dataGridView1);
            CalculateRowId();
        }

        private void DataGridView1_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Clicks == 1 && e.RowIndex >= 0 && e.ColumnIndex == ColDelete.Index)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                AdjustDataGridViewHeight(dataGridView1);
                CalculateRowId();
            }
        }

        private void CalculateRowId()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.Cells[ColId.Index].Value = row.Index + 1;
            }
        }


        private void BtnNew_Click(object? sender, EventArgs e)
        {
            int rowId = dataGridView1.Rows.Add();
            FromToTime newData = new();

            dataGridView1.Rows[rowId].Cells[ColDay.Index].Value = $"Day {rowId + 1}";

            AdjustDataGridViewHeight(dataGridView1);
            CalculateRowId();
            dataGridView1.PreformEndEdit();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            _node.Holidays.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index < 0)
                    continue;


                _node.Holidays.Add(new Holiday
                {
                    Name = dataGridView1.Rows[row.Index].Cells[ColDay.Index].Value!.ToString()!,
                    DayIndex = null,
                    Enabled = true,
                });
                
            }

            _node.Name = txtName.Text;

            OnSave?.Invoke();

            SetControls(_node);
        }

        private void AdjustDataGridViewHeight(DataGridView dataGridView)
        {
            // Calculate the total height of all rows
            int rowHeight = dataGridView.RowTemplate.Height; // Height of a single row
            int headerHeight = dataGridView.ColumnHeadersVisible ? dataGridView.ColumnHeadersHeight : 0; // Header height
            int totalRowHeight = dataGridView.Rows.Cast<DataGridViewRow>().Sum(row => row.Height); // Sum of all row heights

            // Add padding or margins if necessary (optional)
            int padding = 2; // Adjust as needed

            // Set the DataGridView height
            dataGridView.Height = headerHeight + totalRowHeight + padding;
        }
        public void SetControls(HolidayNode node)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < _node.Holidays.Count; i++)
            {
                int rowId = dataGridView1.Rows.Add();
                var value = _node.Holidays[i];

                dataGridView1.Rows[rowId].Cells[ColEnable.Index].Value = value.Enabled;
                dataGridView1.Rows[rowId].Cells[ColDay.Index].Value = value.Name;
            }

            CalculateRowId();

            txtName.Text = node.Name;
            dataGridView1.EndEdit();
        }

    }
}
