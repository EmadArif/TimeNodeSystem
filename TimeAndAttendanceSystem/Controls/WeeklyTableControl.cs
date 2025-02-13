using System.Data;
using TimeAndAttendanceSystem.Helpers.Extensions;
using TimeAndAttendanceSystem.Nodes;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class WeeklyTableControl : UserControl
    {
        private WeeklyNode _node;
        public Action? OnSave;
        public WeeklyTableControl(WeeklyNode node)
        {
            InitializeComponent();

            _node = node;

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            dataGridView1.CallDgvRowDirty((r) =>
            {
                var from = DateTime.Parse(r.Cells["From"].Value.ToString()!).ToHH_MM_TT();
                var to = DateTime.Parse(r.Cells["To"].Value.ToString()!).ToHH_MM_TT();

                var day = _node.WeekTimes[r.Index];

                var isEnabled = Convert.ToBoolean(r.Cells["Enable"].Value);

                var dayFrom = day.FromAsDate.ToHH_MM_TT();
                var dayTo = day.ToAsDate.ToHH_MM_TT();


                return dayFrom != from || dayTo != to || isEnabled != day.Enabled;
            });

            btnSave.Click += BtnSave_Click;

            SetControls(node);
            CalculateTime();

            AdjustDataGridViewHeight(dataGridView1);
        }


        private void BtnSave_Click(object? sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index < 0)
                    continue;

                _node.WeekTimes[row.Index].Enabled = Convert.ToBoolean(row.Cells["Enable"].Value);
                var from = DateTime.Parse(row.Cells["From"].Value.ToString()).ToHH_MM_TT();
                var to = DateTime.Parse(row.Cells["To"].Value.ToString()).ToHH_MM_TT();

                _node.WeekTimes[row.Index].From = DateTime.Parse(from).TimeOfDay;
                _node.WeekTimes[row.Index].To = DateTime.Parse(to).TimeOfDay;

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
        public void SetControls(WeeklyNode node)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < _node.WeekTimes.Count; i++)
            {
                int rowId = dataGridView1.Rows.Add();

                dataGridView1.Rows[rowId].Cells["Enable"].Value = _node.WeekTimes[i].Enabled;
                dataGridView1.Rows[rowId].Cells["Day"].Value = _node.WeekTimes[i].Name;
                dataGridView1.Rows[rowId].Cells["From"].Value = _node.WeekTimes[i].FromAsDate.ToHH_MM_TT();
                dataGridView1.Rows[rowId].Cells["To"].Value = _node.WeekTimes[i].ToAsDate.ToHH_MM_TT();
                dataGridView1.Rows[rowId].Cells["Time"].Value = (_node.WeekTimes[i].To - _node.WeekTimes[i].From).ToString(@"hh\:mm\:ss");
            }

            txtName.Text = node.Name;
            dataGridView1.EndEdit();
        }

        private void CalculateTime()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index < 0)
                    continue;

                var from = DateTime.Parse(row.Cells["From"].Value.ToString());
                var to = DateTime.Parse(row.Cells["To"].Value.ToString());
                row.Cells["Time"].Value = (to.TimeOfDay - from.TimeOfDay).ToHH_MM();
            }
        }

        private void DataGridView1_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            ValidateTimes(dataGridView1);
            CalculateTime();
        }

        private void ValidateTimes(DataGridView dataGridView)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                dataGridView1.EndEdit();

                if (row.Cells[1].Value == null)
                    continue;

                // Skip if the row is empty or new
                if (row.IsNewRow) continue;

                DateTime datetimeFrom = DateTime.Parse(row.Cells["From"].Value.ToString());
                DateTime datetimeTo = DateTime.Parse(row.Cells["To"].Value.ToString());

                // Get the values from column 1 and column 2
                if (datetimeFrom.TimeOfDay > datetimeTo.TimeOfDay)
                {
                    row.Cells["From"].Value = datetimeTo.ToShortTimeString();
                    row.Cells["From"].ErrorText = "Time exceeded time To.";
                }
                else
                {
                    row.Cells["From"].ErrorText = null;
                }
            }
        }
    }
}
