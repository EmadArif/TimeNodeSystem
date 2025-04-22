using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using System;

namespace TimeAndAttendanceSystem.Nodes
{
    public class WeeklyNode : WeeklyTimeNodeBase
    {
        public override object Clone()
        {
            var clone = (WeeklyNode)this.MemberwiseClone();
            clone.Times = [
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Saturday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Sunday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Monday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Tuesday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Wednesday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Thursday,
                },
                new  WeeklyFromToTime{
                    DayIndex = DayOfWeek.Friday,
                },
            ];
            return clone;
        }

        public override bool Calculate(YearCalendar calendar, int dayIndex)
        {
            if (Times == null || Times.Count == 0)
                return false;

            int index = Times.FindIndex(x => x.Enabled && x.DayIndex == calendar.Date.DayOfWeek);

            if (index >= 0)
            {
                calendar.FromTime = DateTime.Parse(Times[index].From.ToString());
                calendar.ToTime = DateTime.Parse(Times[index].To.ToString());
            }
            //calendar.Enabled = index != -1;

            return true;
        }
    }
}
