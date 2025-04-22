using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.PeriodNodes.Data
{
    public class Holiday : ISwitchable, IHoliday
    {
        public bool Enabled { get; set; } = true;

        public DayOfWeek? DayIndex { get; set; }
        public string Name
        {
            get
            {
                return DayIndex.ToString();
            }
            set
            {
            }
        }
    }
}
