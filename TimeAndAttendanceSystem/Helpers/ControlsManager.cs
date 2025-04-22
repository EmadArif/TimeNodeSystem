
using TimeAndAttendanceSystem.Controls;
using TimeAndAttendanceSystem.Nodes;
using TimeAndAttendanceSystem.PeriodNodes;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Data;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Helpers
{
    public static class ControlsManager
    {

        public static void DefaultNodeControl(INode node, Dictionary<string, object>? arg2, Action? callback)
        {
            var propertiesPanel = (arg2!["propertiesPanel"] as Control)!;

            propertiesPanel.Controls.Add(new DefaultControl(node)
            {
                Dock = DockStyle.Fill,
                OnSave = () => {
                    callback?.Invoke();
                }
            });
        }

        public static void TwoDatesControl(INode node, Dictionary<string, object>? arg2, Action? callback)
        {
            var propertiesPanel = (arg2!["propertiesPanel"] as Control)!;

            propertiesPanel.Controls.Add(new TwoDatesControl((ITwoDatesNode)node)
            {
                Dock = DockStyle.Fill,
                OnSave = () =>
                {
                    callback?.Invoke();
                }
            });
        }
        public static void NTimesTableControl(INode node, Dictionary<string, object>? arg2, Action? callback)
        {
            var propertiesPanel = (arg2!["propertiesPanel"] as Control)!;

            propertiesPanel.Controls.Add(new NTimesTableControl((ChildNodeBase)node)
            {
                Dock = DockStyle.Fill,
                OnSave = () =>
                {
                    callback?.Invoke();
                }
            });
        }

        public static void HolidayTableControl(INode node, Dictionary<string, object>? arg2, Action? callback)
        {
            var propertiesPanel = (arg2!["propertiesPanel"] as Control)!;

            propertiesPanel.Controls.Add(new HolidayTableControl((HolidayNode)node)
            {
                Dock = DockStyle.Fill,
                OnSave = () =>
                {
                    callback?.Invoke();
                }
            });
        }
    }
}
