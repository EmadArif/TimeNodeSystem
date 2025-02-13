using System.Windows.Forms;

namespace TimeAndAttendanceSystem.Nodes
{
    /*public class TwoDaysTimeNode : ChildNode
    {
        public TimeSpan DayOneFrom { get; set; } = DateTime.Now.TimeOfDay;
        public TimeSpan DayOneTo { get; set; } = DateTime.Now.TimeOfDay;

        public TimeSpan DayTwoFrom { get; set; } = DateTime.Now.TimeOfDay;
        public TimeSpan DayTwoTo { get; set; } = DateTime.Now.TimeOfDay;

        public override bool Calculate(YearCalendar? calendar, DateTime currentDate, int dayIndex)
        {
            if (calendar == null)
                return false;

            if(currentDate.Day % 2 == 1) //Every odd days
            {
                calendar.FromTime = DateTime.Parse(DayOneFrom.ToString());
                calendar.ToTime = DateTime.Parse(DayOneTo.ToString());
            }
            else
            {
                calendar.FromTime = DateTime.Parse(DayTwoFrom.ToString());
                calendar.ToTime = DateTime.Parse(DayTwoTo.ToString());
            }

            return true;
        }
            

        public bool ValidateDayOne(TimeSpan dayOneFrom, TimeSpan dayOneTo)
        {
            // Ensure DayOne "From" is before or equal to "To"
            if (dayOneFrom > dayOneTo)
            {
                Console.WriteLine("Invalid time range for Day One: 'From' time cannot be later than 'To' time.");
                return false; // Conflict in DayOne
            }
            return true; // Valid DayOne time range
        }
        
        public bool ValidateDayTwo(TimeSpan dayTwoFrom, TimeSpan dayTwoTo)
        {
            // Ensure DayTwo "From" is before or equal to "To"
            if (dayTwoFrom > dayTwoTo)
            {
                Console.WriteLine("Invalid time range for Day Two: 'From' time cannot be later than 'To' time.");
                return false; // Conflict in DayTwo
            }
            return true; // Valid DayTwo time range
        }
    }*/
}
