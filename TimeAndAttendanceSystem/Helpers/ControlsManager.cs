
using TimeAndAttendanceSystem.Controls;
using TimeAndAttendanceSystem.Nodes;
using TimeAndAttendanceSystem.PeriodNodes;

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

            propertiesPanel.Controls.Add(new NTimesTableControl((NDaysTimeNode)node)
            {
                Dock = DockStyle.Fill,
                OnSave = () =>
                {
                    callback?.Invoke();
                }
            });
        }
        public static void WeeklyTableControl(INode node, Dictionary<string, object>? arg2, Action? callback)
        {
            var propertiesPanel = (arg2!["propertiesPanel"] as Control)!;

            propertiesPanel.Controls.Add(new WeeklyTableControl((WeeklyNode)node)
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
