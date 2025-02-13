

using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Nodes
{

    public class BetweenDatesNode : ParentNodeBase, ITwoDatesLimitedNode
    {
        public string FullName => $"({Name})" + $" {DateOne.Year}/{DateOne.Month}/{DateOne.Day} - To {DateOne.Year}/{DateTwo.Month}/{DateTwo.Day}";

        public DateTime DateOne { get; set; } = new DateTime(DateTime.Now.Year, 1, 1);
        public DateTime DateTwo { get; set; } = new DateTime(DateTime.Now.Year, 12, 31);
        public DateTime MinDate { get; set; } = DateTime.MinValue;
        public DateTime MaxDate { get; set; } = DateTime.MaxValue;

        public override void Initalize(INode parentNode)
        {
            if (parentNode is ITwoDatesNode twoDatesNode)
            {
                SetDatesLimit(twoDatesNode.DateOne, twoDatesNode.DateTwo);
            }
        }
        public void SetDatesLimit(DateTime minDate, DateTime maxDate)
        {
            MinDate = minDate;
            MaxDate = maxDate;

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
        public void CalculateDatesLimite()
        {
            SetDatesLimit(MinDate, MaxDate);
        }
        public void SetDates(DateTime dateOne, DateTime dateTwo)
        {
            DateOne = dateOne;
            DateTwo = dateTwo;
            CalculateDatesLimite();
        }
        public void Update(INode parentNode)
        {
            if (parentNode is ITwoDatesNode twoDatesNode)
            {
                SetDatesLimit(twoDatesNode.DateOne, twoDatesNode.DateTwo);
            }

            OnValueUpdated?.Invoke(this);
        }
    }
}
