using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.PeriodNodes.Abstructs
{
    public abstract class WeeklyTimeNodeBase : ChildNodeBase, IFromToTimeList
    {
        public List<WeeklyFromToTime> Times { get; set; } = [];
        public IEnumerable<IFromToTime> GetTimes
        {
            get
            {
                return Times;
            }
        }

        public void ClearTimes()
        {
            Times.Clear();
        }
        public void AddTime<T>(T value) where T : IFromToTime
        {
            if (value is WeeklyFromToTime v)
                Times.Add(v);
        }

    }
}


