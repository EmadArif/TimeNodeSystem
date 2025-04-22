using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;

namespace TimeAndAttendanceSystem.PeriodNodes
{
    internal class TestNode : ChildNodeBase
    {
        public override bool Calculate(YearCalendar calendar, int dayIndex)
        {
            
            
            return true;
        }
    }
}
