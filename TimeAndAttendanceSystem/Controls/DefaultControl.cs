using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class DefaultControl : UserControl
    {
        private INode _node;
        public Action? OnSave;
        public DefaultControl(INode node)
        {
            InitializeComponent();

            txtName.Text = node.Name;

            _node = node;
            
            btnSave.Click += BtnSave_Click;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            _node.Name = txtName.Text;

            OnSave?.Invoke();
        }
    }
}
