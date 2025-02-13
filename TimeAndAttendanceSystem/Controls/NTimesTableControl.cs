using TimeAndAttendanceSystem.Helpers.Extensions;
using TimeAndAttendanceSystem.PeriodNodes;
using TimeAndAttendanceSystem.PeriodNodes.Data;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class NTimesTableControl : UserControl
    {
        private NDaysTimeNode _node;
        public Action? OnSave;

        public NTimesTableControl(NDaysTimeNode node)
        {
            InitializeComponent();
            _node = node;

            dataGridView1.AddIntegerTextColumn(ColTimeAllowed.Index);

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            dataGridView1.CallDgvRowDirty((r) =>
            {
                if (r.Index >= _node.DayTimes.Count)
                    return true;

                var earlyFrom = DateTime.Parse(r.Cells[ColEarlyFrom.Index].Value.ToString()!).ToHH_MM_TT();
                var from = DateTime.Parse(r.Cells[ColFrom.Index].Value.ToString()!).ToHH_MM_TT();
                var to = DateTime.Parse(r.Cells[ColTo.Index].Value.ToString()!).ToHH_MM_TT();
                var lateTo = DateTime.Parse(r.Cells[ColLateTo.Index].Value.ToString()!).ToHH_MM_TT();
                var timeAllowed = int.Parse(r.Cells[ColTimeAllowed.Index].Value?.ToString()!);

                var dayName = r.Cells[ColDay.Index].Value.ToString();
                var day = _node.DayTimes[r.Index];

                var dayEarlyFrom = day.EarlyFrom.ToDateTime().ToHH_MM_TT();
                var dayFrom = day.From.ToDateTime().ToHH_MM_TT();

                var dayTo = day.To.ToDateTime().ToHH_MM_TT();
                var dayLateTo = day.LateTo.ToDateTime().ToHH_MM_TT();


                return dayFrom != from || dayTo != to || dayName != day.Name 
                || earlyFrom != dayEarlyFrom || lateTo != dayLateTo || timeAllowed != day.MinutesAllowed;
            });

            dataGridView1.CellMouseDown += DataGridView1_CellMouseDown;
            btnNew.Click += BtnNew_Click;
            btnSave.Click += BtnSave_Click;

            SetControls(node);
            CalculateTime();

            AdjustDataGridViewHeight(dataGridView1);
            CalculateRowId();
        }

        private void DataGridView1_CellMouseDown(object? sender, DataGridViewCellMouseEventArgs e)
        {
            if(e.Clicks == 1 && e.RowIndex >= 0 && e.ColumnIndex == ColDelete.Index)
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

            dataGridView1.Rows[rowId].Cells[ColEarlyFrom.Index].Value = newData.EarlyFrom.ToDateTime().ToHH_MM_TT();
            dataGridView1.Rows[rowId].Cells[ColFrom.Index].Value = newData.From.ToDateTime().ToHH_MM_TT();
            dataGridView1.Rows[rowId].Cells[ColTo.Index].Value = newData.To.ToDateTime().ToHH_MM_TT();
            dataGridView1.Rows[rowId].Cells[ColLateTo.Index].Value = newData.LateTo.ToDateTime().ToHH_MM_TT();
            dataGridView1.Rows[rowId].Cells[ColTimeAllowed.Index].Value = 0;

            dataGridView1.Rows[rowId].Cells[ColTime.Index].Value = (newData.From - newData.To).ToString(@"hh\:mm\:ss");

            AdjustDataGridViewHeight(dataGridView1);
            CalculateRowId();
            dataGridView1.PreformEndEdit();
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            _node.DayTimes.Clear();

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index < 0)
                    continue;

                var earlyFrom = DateTime.Parse(row.Cells[ColEarlyFrom.Index].Value.ToString()).TimeOfDay;
                var from = DateTime.Parse(row.Cells[ColFrom.Index].Value.ToString()).TimeOfDay;
                var to = DateTime.Parse(row.Cells[ColTo.Index].Value.ToString()).TimeOfDay;
                var lateTo = DateTime.Parse(row.Cells[ColLateTo.Index].Value.ToString()).TimeOfDay;
                var minutesAllowed = int.Parse(row.Cells[ColTimeAllowed.Index].Value.ToString());
                var x = new FromToTime
                {
                    Name = row.Cells[ColDay.Index].Value.ToString(),

                    EarlyFrom = earlyFrom,
                    From = from,
                    To = to,
                    LateTo = lateTo,
                    MinutesAllowed = minutesAllowed,
                };

                _node.DayTimes.Add(x);
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
        public void SetControls(NDaysTimeNode node)
        {
            dataGridView1.Rows.Clear();

            for (int i = 0; i < _node.DayTimes.Count; i++)
            {
                int rowId = dataGridView1.Rows.Add();

                dataGridView1.Rows[rowId].Cells[ColDay.Index].Value = _node.DayTimes[i].Name;

                dataGridView1.Rows[rowId].Cells[ColEarlyFrom.Index].Value = _node.DayTimes[i].EarlyFrom.ToDateTime().ToHH_MM_TT();
                dataGridView1.Rows[rowId].Cells[ColFrom.Index].Value = _node.DayTimes[i].From.ToDateTime().ToHH_MM_TT();
                dataGridView1.Rows[rowId].Cells[ColTo.Index].Value = _node.DayTimes[i].To.ToDateTime().ToHH_MM_TT();
                dataGridView1.Rows[rowId].Cells[ColLateTo.Index].Value = _node.DayTimes[i].LateTo.ToDateTime().ToHH_MM_TT();
                
                dataGridView1.Rows[rowId].Cells[ColTimeAllowed.Index].Value = _node.DayTimes[i].MinutesAllowed;
                dataGridView1.Rows[rowId].Cells[ColTime.Index].Value = (_node.DayTimes[i].To - _node.DayTimes[i].From).ToString(@"hh\:mm\:ss");
            }
            CalculateRowId();

            txtName.Text = node.Name;
            dataGridView1.EndEdit();
        }

        private void CalculateTime()
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Index < 0)
                    continue;

                var from = DateTime.Parse(row.Cells[ColFrom.Index].Value.ToString());
                var to = DateTime.Parse(row.Cells[ColTo.Index].Value.ToString());

                row.Cells[ColTime.Index].Value = (to.TimeOfDay - from.TimeOfDay).ToString(@"hh\:mm\:ss");
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

                DateTime dtEarlyFrom = DateTime.Parse(row.Cells[ColEarlyFrom.Index].Value.ToString());
                DateTime dtFrom = DateTime.Parse(row.Cells[ColFrom.Index].Value.ToString());


                DateTime dtTo = DateTime.Parse(row.Cells[ColTo.Index].Value.ToString());
                DateTime dtLateTo = DateTime.Parse(row.Cells[ColLateTo.Index].Value.ToString());

                // Get the values from column 1 and column 2

                if (dtEarlyFrom.TimeOfDay > dtFrom.TimeOfDay)
                {
                    row.Cells[ColEarlyFrom.Index].Value = dtFrom.ToShortTimeString();
                    row.Cells[ColEarlyFrom.Index].ErrorText = "Time exceeded time From.";
                }
                if (dtLateTo.TimeOfDay < dtTo.TimeOfDay)
                {
                    row.Cells[ColLateTo.Index].Value = dtTo.ToShortTimeString();
                    row.Cells[ColLateTo.Index].ErrorText = "Time exceeded time To.";
                }

                if (dtFrom.TimeOfDay > dtTo.TimeOfDay)
                {
                    row.Cells[ColFrom.Index].Value = dtTo.ToShortTimeString();
                    row.Cells[ColFrom.Index].ErrorText = "Time exceeded time To.";
                }
                else
                {
                    row.Cells[ColFrom.Index].ErrorText = null;
                }
            }
        }
    }
}
