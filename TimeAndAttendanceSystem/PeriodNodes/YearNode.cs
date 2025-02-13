
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Nodes
{
    public class YearNode : ParentNodeBase, ITwoDatesLimitedNode
    {
        public string FullName => $"({Name})" + $" {DateOne.Year}/{DateOne.Month}/{DateOne.Day} - To {DateOne.Year}/{DateTwo.Month}/{DateTwo.Day}";

        public DateTime DateOne { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime DateTwo { get; set; } = new DateTime(DateTime.Now.Year, 12, 31);
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.MaxValue;
        public void SetDatesLimit()
        {
            DateOne = DateOne < MinDate ? MinDate : DateOne;
            DateOne = DateOne > MaxDate ? MaxDate : DateOne;

            // Ensure DateTwo is within MinDate and MaxDate
            DateTwo = DateTwo < MinDate ? MinDate : DateTwo;
            DateTwo = DateTwo > MaxDate ? MaxDate : DateTwo;

            // Ensure DateOne is not greater than DateTwo
            if (DateOne > DateTwo)
            {
                DateOne = DateTwo;
            }
        }
        public void SetDates(DateTime dateOne, DateTime dateTwo)
        {
            DateOne = dateOne;
            DateTwo = dateTwo;
            SetDatesLimit();
        }
        public void Update(INode parentNode)
        {
            if (parentNode is ITwoDatesNode twoDatesNode)
            {
                MinDate = twoDatesNode.DateOne;
                MaxDate = twoDatesNode.DateTwo;
            }

            SetDatesLimit();
            OnValueUpdated?.Invoke(this);
        }
    }
}
