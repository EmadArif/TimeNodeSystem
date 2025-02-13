

namespace TimeAndAttendanceSystem.Nodes
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

        public bool Calculate(YearCalendar calendar, DateTime currentDate, int dayIndex);
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

}
