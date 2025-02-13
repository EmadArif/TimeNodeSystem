using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.PeriodNodes.Data
{
    public class WeeklyFromToTime : IFromToTime, ISwitchable
    {
        public bool Enabled { get; set; } = true;

        public DayOfWeek DayIndex { get; set; }
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

        public TimeSpan EarlyFrom { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan From { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan To { get; set; } = new TimeSpan(23, 59, 59);
        public TimeSpan LateTo { get; set; } = new TimeSpan(23, 59, 59);
        public int MinutesAllowed { get; set; } = 0;


        public TimeSpan Time
        {
            get
            {
                return To - From;
            }
        }
    }
}
