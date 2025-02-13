using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.PeriodNodes.Abstructs
{
    public abstract class NTimesChildNodeBase : ChildNodeBase, IFromToTimeList
    {
        public List<FromToTime> Times { get; set; } = [];
        public IEnumerable<IFromToTime> GetTimes
        {
            get
            {
                return Times;
            }
        }

        public void AddTime<T>(T value) where T : IFromToTime
        {
            if(value is FromToTime v)
                Times.Add(v);
        }

        public void ClearTimes()
        {
            Times.Clear();
        }
    }
}


