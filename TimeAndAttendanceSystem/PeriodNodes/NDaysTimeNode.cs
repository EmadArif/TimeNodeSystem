using TimeAndAttendanceSystem.Helpers.Extensions;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Data;

namespace TimeAndAttendanceSystem.PeriodNodes
{

    public class NDaysTimeNode : NTimesChildNodeBase
    {
        public override object Clone()
        {
            var clone = (NDaysTimeNode)this.MemberwiseClone();

            // Reset the Children list to an empty list
            clone.Times = [
                   new  FromToTime{
                    Name = "Each Day"
                }
            ];

            return clone;
        }
        public override bool Calculate(YearCalendar calendar, int dayIndex)
        {
            if (Times == null || Times.Count == 0)
                return false;

            if(calendar.Enabled)
            {
                int index = (dayIndex % Times.Count);
                calendar.FromTime = Times[index].From.ToDateTime();
                calendar.ToTime = Times[index].To.ToDateTime();
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
    }
}
