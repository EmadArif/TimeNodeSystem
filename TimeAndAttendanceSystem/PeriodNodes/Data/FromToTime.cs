using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TimeAndAttendanceSystem.Helpers.Attributes;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.PeriodNodes.Data
{
    public class FromToTime : IFromToTime
    {
        public string Name { get; set; }
        public TimeSpan EarlyFrom { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan From { get; set; } = new TimeSpan(0, 0, 0);
        public TimeSpan To { get; set; } = new TimeSpan(23, 59, 59);
        public TimeSpan LateTo { get; set; } = new TimeSpan(23, 59, 59);
        public int MinutesAllowed { get; set; } = 0;


        public TimeSpan Time { get
            {
                return To  - From;
            } 
        }

    }
}
