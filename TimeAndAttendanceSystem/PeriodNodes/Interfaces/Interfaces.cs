using TimeAndAttendanceSystem.PeriodNodes.Data;

namespace TimeAndAttendanceSystem.PeriodNodes.Interfaces
{
    public interface INode : ICloneable
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Action<INode, Dictionary<string, object>?, Action?>? OnSelected { get; set; }
        public Action<INode>? OnValueUpdated { get; set; }
        public string FullName => $"({Name})";
        public void Initalize(INode parentNode);

        public void Update(INode parentNode)
        {
            OnValueUpdated?.Invoke(this);
        }

        public bool Calculate(YearCalendar calendar, int localDayIndex);
    }
    public interface IParentNode : INode
    {
        public List<INode> Children { get; set; }
    }
    public interface ITwoDatesNode : INode
    {
        public DateTime DateOne { get; set; }
        public DateTime DateTwo { get; set; }

        public void SetDates(DateTime dateOne, DateTime dateTwo)
        {
            DateOne = dateOne;
            DateTwo = dateTwo;
        }
    }
    public interface ITwoDatesLimitedNode : ITwoDatesNode
    {
        public DateTime MinDate { get; set; }
        public DateTime MaxDate { get; set; }

    }

    public interface IFromToTimeList
    {
        IEnumerable<IFromToTime> GetTimes { get;}

        public void ClearTimes();
        public void AddTime<T>(T value) where T : IFromToTime;
    }
    public interface ISwitchable
    {
        public bool Enabled { get; set; }
    }
    public interface IHoliday
    {
        public DayOfWeek? DayIndex { get; set; }

    }
    public interface IFromToTime
    {
        public string Name { get; set; }
        public TimeSpan EarlyFrom { get; set; }
        public TimeSpan From { get; set; }
        public TimeSpan To { get; set; }
        public TimeSpan LateTo { get; set; }
        public int MinutesAllowed { get; set; }


        public TimeSpan Time
        {
            get
            {
                return To - From;
            }
        }

    }
}
