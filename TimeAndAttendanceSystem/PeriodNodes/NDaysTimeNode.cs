
using System.Xml.Linq;
using TimeAndAttendanceSystem.Nodes;
using TimeAndAttendanceSystem.PeriodNodes.Data;

namespace TimeAndAttendanceSystem.PeriodNodes
{
   
    public class NDaysTimeNode : ChildNode
    {
        public List<FromToTime> DayTimes = [];

        public override object Clone()
        {
            var clone = (NDaysTimeNode)this.MemberwiseClone();

            // Reset the Children list to an empty list
            clone.DayTimes = [
                   new  FromToTime{
                    Name = "Each Day"
                }
            ];

            return clone;
        }
        public override bool Calculate(YearCalendar calendar, DateTime currentDate, int dayIndex)
        {
            if (DayTimes == null || DayTimes.Count == 0)
                return false;

            int index = (dayIndex % DayTimes.Count);
            calendar.FromTime = DateTime.Parse(DayTimes[index].From.ToString());
            calendar.ToTime = DateTime.Parse(DayTimes[index].To.ToString());

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
    }
}
