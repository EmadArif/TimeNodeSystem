namespace TimeAndAttendanceSystem.PeriodNodes.Data
{
    public class WeeklyFromToTime
    {
        public bool Enabled { get; set; }
        public DayOfWeek DayIndex { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }

        public string Name
        {
            get
            {
                return Enum.GetName(DayIndex)!;
            }
        }

        public DateTime FromAsDate
        {
            get
            {
                return DateTime.Today.Add(From);
            }
        }

        public DateTime ToAsDate
        {
            get
            {
                return DateTime.Today.Add(To);
            }
        }
    }
}
