using TimeAndAttendanceSystem.Nodes;

namespace TimeAndAttendanceSystem.Controls
{
    public partial class TwoDatesControl : UserControl
    {
        private ITwoDatesNode _node;
        public Action? OnSave;
        public TwoDatesControl(ITwoDatesNode node)
        {
            InitializeComponent();

            _node = node;

            SetControls(node);

            btnSave.Click += BtnSave_Click;
        }

        public void SetControls(ITwoDatesNode node)
        {
            fromDate.Value = node.DateOne;
            toDate.Value = node.DateTwo;
            txtName.Text = node.Name;
        }

        private void BtnSave_Click(object? sender, EventArgs e)
        {
            _node.DateOne = fromDate.Value;
            _node.DateTwo = toDate.Value;
            _node.Name = txtName.Text;

            OnSave?.Invoke();

            SetControls(_node);

        }
    }
}
