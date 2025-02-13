namespace TimeAndAttendanceSystem
{
    public class YearCalendar
    {
        public DateTime Date { get; set; }
        public DateTime FromTime { get; set; }
        public DateTime ToTime { get; set; }
        public Color? DateColor { get; set; }
        public bool Enabled { get; set; } = true;
        public TimeSpan Time => (ToTime - FromTime);
    }
}
