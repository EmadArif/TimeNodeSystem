using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Data;

namespace TimeAndAttendanceSystem.Nodes
{
    public class HolidayNode : ChildNodeBase
    {
        public List<Holiday> Holidays { get; set; } = [];
        public override bool Calculate(YearCalendar calendar, int dayIndex)
        {
            if (Holidays.Count == 0)
                return false;

            int i = dayIndex % Holidays.Count;
            Holiday holiday = Holidays[i];
            if (holiday == null) {
                return false;
            }
            if (holiday.Enabled)
                calendar.DateColor = Color.Green;
            return true;
        }
    }
}
