using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes;

namespace TimeAndAttendanceSystem.Nodes
{
    public class WeeklyNode : ChildNode
    {
        public List<WeeklyFromToTime> WeekTimes { get; private set; } = [];

        public override object Clone()
        {
            var clone = (WeeklyNode)this.MemberwiseClone();
            clone.WeekTimes = [
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Saturday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Sunday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Monday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Tuesday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Wednesday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Thursday,
                },
                new  WeeklyFromToTime{
                    Enabled = true,
                    From = DateTime.Now.TimeOfDay,
                    To = DateTime.Now.TimeOfDay,
                    DayIndex = DayOfWeek.Friday,
                },
            ];
            return clone;
        }

        public override bool Calculate(YearCalendar calendar, DateTime currentDate, int dayIndex)
        {
            if (WeekTimes == null || WeekTimes.Count == 0)
                return false;

            int index = GetElementIndexByWeekName(WeekTimes, currentDate.DayOfWeek);
            if (index >= 0)
            {
                calendar.FromTime = DateTime.Parse(WeekTimes[index].From.ToString());
                calendar.ToTime = DateTime.Parse(WeekTimes[index].To.ToString());
            }

            return true;
        }

        public static int GetElementIndexByWeekName(List<WeeklyFromToTime> timeRanges, DayOfWeek dayOfWeek)
        {
            return timeRanges.FindIndex(x => x.Enabled && x.DayIndex == dayOfWeek);
        }
    }
}
