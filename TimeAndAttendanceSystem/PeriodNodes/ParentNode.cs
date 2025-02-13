using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeAndAttendanceSystem.Nodes
{
    public abstract class ParentNode : IParentNode
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public Action<INode, Dictionary<string, object>?, Action?>? OnSelected { get; set; }
        public Action<INode>? OnValueUpdated { get; set; }
        public List<INode> Children { get; set; } = [];

        public virtual bool Calculate(YearCalendar calendar, DateTime currentDate, int dayIndex)
        {
            return true;
        }

        public virtual object Clone()
        {
            var clone = (ParentNode)this.MemberwiseClone();

            // Reset the Children list to an empty list
            clone.Children = [];

            return clone;
        }

        public virtual void Initalize(INode parentNode)
        {
            
        }
    }

}
