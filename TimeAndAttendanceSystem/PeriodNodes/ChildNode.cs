using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TimeAndAttendanceSystem.Nodes
{

    public abstract class ChildNode : INode
    {
        public required string Id { get; set; }
        public required string Name { get; set; }
        public Action<INode, Dictionary<string, object>?, Action?>? OnSelected { get; set; }
        public Action<INode>? OnValueUpdated { get; set; }

        public virtual bool Calculate(YearCalendar calendar, DateTime currentDate, int dayIndex)
        {
            return true;
        }

        public virtual object Clone()
        {
            return this.MemberwiseClone();
        }

        public virtual void Initalize(INode parentNode)
        {
        }
    }
}
