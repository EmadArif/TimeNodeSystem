using TimeAndAttendanceSystem.Helpers.Extensions;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class NTimesTableControl : UserControl
    {
        private ChildNodeBase _node;
        public Action? OnSave;

        public NTimesTableControl(ChildNodeBase node)
        {
            InitializeComponent();

            _node = node;

            if(_node is WeeklyTimeNodeBase)
            {
                btnNew.Enabled = false;
                btnNew.Visible = false;
            }
            else
            {
                dataGridView1.Columns[ColEnable.Index].Visible = false;
            }

            dataGridView1.AddIntegerTextColumn(ColTimeAllowed.Index);

            dataGridView1.AutoGenerateColumns = false;

            dataGridView1.CellEndEdit += DataGridView1_CellEndEdit;

            dataGridView1.CallDgvRowDirty((r) =>
            {
                if (_node is IFromToTimeList timeList)
                {
                    if (r.Index >= timeList.GetTimes.Count())
                        return true;

                    var earlyFrom = DateTime.Parse(r.Cells[ColEarlyFrom.Index].Value!.ToString()!).ToHH_MM_TT();
                    var from = DateTime.Parse(r.Cells[ColFrom.Index].Value!.ToString()!).ToHH_MM_TT();
                    var to = DateTime.Parse(r.Cells[ColTo.Index].Value!.ToString()!).ToHH_MM_TT();
                    var lateTo = DateTime.Parse(r.Cells[ColLateTo.Index].Value!.ToString()!).ToHH_MM_TT();
                    var timeAllowed = int.Parse(r.Cells[ColTimeAllowed.Index].Value!.ToString()!);

                    var dayName = r.Cells[ColDay.Index].Value?.ToString();
                    var day = timeList.GetTimes.ElementAt(r.Index);

                    var dayEarlyFrom = day.EarlyFrom.ToDateTime().ToHH_MM_TT();
                    var dayFrom = day.From.ToDateTime().ToHH_MM_TT();

                    var dayTo = day.To.ToDateTime().ToHH_MM_TT();
                    var dayLateTo = day.LateTo.ToDateTime().ToHH_MM_TT();

                    bool isValuesChanged = dayFrom != from || dayTo != to || dayName != day.Name
                    || earlyFrom != dayEarlyFrom || lateTo != dayLateTo || timeAllowed != day.MinutesAllowed;

                    if (day is ISwitchable sw)
                    {
                        var isEnabled = Convert.ToBoolean(r.Cells[ColEnable.Index].Value);
                        return isValuesChanged || sw.Enabled != isEnabled;
                    }

                    return isValuesChanged;
                }
                return false;
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
            if (_node is IFromToTimeList timeList)
            {
                List<IFromToTime> times = timeList.GetTimes.ToList();

                if (timeList.GetTimes is not List<WeeklyFromToTime>)
                    timeList.ClearTimes();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Index < 0)
                        continue;

                    var earlyFrom = DateTime.Parse(row.Cells[ColEarlyFrom.Index].Value.ToString()).TimeOfDay;
                    var from = DateTime.Parse(row.Cells[ColFrom.Index].Value.ToString()).TimeOfDay;
                    var to = DateTime.Parse(row.Cells[ColTo.Index].Value.ToString()).TimeOfDay;
                    var lateTo = DateTime.Parse(row.Cells[ColLateTo.Index].Value.ToString()).TimeOfDay;
                    var minutesAllowed = int.Parse(row.Cells[ColTimeAllowed.Index].Value.ToString());

                    IFromToTime? newValue = null;

                    if (timeList.GetTimes is List<WeeklyFromToTime> w)
                    {
                        var enabled = bool.Parse(row.Cells[ColEnable.Index].Value.ToString());

                        w[row.Index].EarlyFrom = earlyFrom;
                        w[row.Index].From = from;
                        w[row.Index].To = to;
                        w[row.Index].LateTo = lateTo;
                        w[row.Index].MinutesAllowed = minutesAllowed;
                        w[row.Index].Enabled = enabled;
                    }
                    else if(_node is NTimesChildNodeBase)
                    {
                        newValue = new FromToTime
                        {
                            Name = row.Cells[ColDay.Index].Value.ToString(),

                            EarlyFrom = earlyFrom,
                            From = from,
                            To = to,
                            LateTo = lateTo,
                            MinutesAllowed = minutesAllowed,
                        };
                        timeList.AddTime(newValue);
                    }
                }
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
        public void SetControls(ChildNodeBase node)
        {
            dataGridView1.Rows.Clear();
            if (_node is IFromToTimeList timeList)
            {

                for (int i = 0; i < timeList.GetTimes.Count(); i++)
                {
                    int rowId = dataGridView1.Rows.Add();
                    var value = timeList.GetTimes.ElementAt(i);

                    if (timeList.GetTimes.ElementAt(i) is ISwitchable sw)
                    {
                        dataGridView1.Rows[rowId].Cells[ColEnable.Index].Value = sw.Enabled;
                    }

                    dataGridView1.Rows[rowId].Cells[ColDay.Index].Value = value.Name;

                    dataGridView1.Rows[rowId].Cells[ColEarlyFrom.Index].Value = value.EarlyFrom.ToDateTime().ToHH_MM_TT();
                    dataGridView1.Rows[rowId].Cells[ColFrom.Index].Value = value.From.ToDateTime().ToHH_MM_TT();
                    dataGridView1.Rows[rowId].Cells[ColTo.Index].Value = value.To.ToDateTime().ToHH_MM_TT();
                    dataGridView1.Rows[rowId].Cells[ColLateTo.Index].Value = value.LateTo.ToDateTime().ToHH_MM_TT();
                
                    dataGridView1.Rows[rowId].Cells[ColTimeAllowed.Index].Value = value.MinutesAllowed;
                    dataGridView1.Rows[rowId].Cells[ColTime.Index].Value = (value.To - value.From).ToString(@"hh\:mm\:ss");
                }
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

        private void EnsureValidTime(DataGridViewRow row, int cellIndex, DateTime min, DateTime max, string errorMessage)
        {
            var time = DateTime.Parse(row.Cells[cellIndex].Value.ToString());
            if (time.TimeOfDay > max.TimeOfDay)
            {
                row.Cells[cellIndex].Value = min.ToShortTimeString();
                row.Cells[cellIndex].ErrorText = errorMessage;
            }
            else
            {
                row.Cells[cellIndex].ErrorText = null;
            }
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
