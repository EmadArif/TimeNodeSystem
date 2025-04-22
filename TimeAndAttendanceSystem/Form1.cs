
using TimeAndAttendanceSystem.Helpers;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem
{
    public partial class Form1 : Form
    {
        public List<YearCalendar> yearCalendars = [];
        public Form1()
        {
            InitializeComponent();

            RefreshFullTree();

            foreach (ToolStripMenuItem item in contextMenuStrip1.Items)
            {
                if (item.Text == "Childern")
                {
                    item.DropDownItems.Clear();
                    foreach (var p in NodesManager.Periods.Where(x => x is not IParentNode))
                    {
                        ToolStripMenuItem newItem = new(p.Name.ToString())
                        {
                            Tag = p.Id // Optionally, store the period object in the Tag property for later use
                        }; // Use the period's string representation as the item text

                        item.DropDownItems.Add(newItem); // Add the new item to the dropdown
                    }
                    item.DropDownItemClicked += OnPeriodSelected;

                }
                else if (item.Text == "Parents")
                {
                    item.DropDownItems.Clear();
                    foreach (var p in NodesManager.Periods.Where(x => x is IParentNode))
                    {
                        ToolStripMenuItem newItem = new ToolStripMenuItem(p.Name.ToString()); // Use the period's string representation as the item text
                        newItem.Tag = p.Id; // Optionally, store the period object in the Tag property for later use

                        item.DropDownItems.Add(newItem); // Add the new item to the dropdown
                    }
                    item.DropDownItemClicked += OnParentSelected;
                }
            }

            contextMenuStrip1.ItemClicked += MoveNodes;
            treeView1.MouseDown += TreeView1_MouseDown;
            treeView1.KeyDown += TreeView1_KeyDown;
            treeView1.AfterSelect += TreeView1_AfterSelect;
        }
        private void MoveNodeUp(TreeNode node)
        {
            if (node == null || node.Parent == null)
                return; // Node has no parent (root node or invalid)

            TreeNodeCollection siblings = node.Parent.Nodes; // Get the sibling collection
            int index = node.Index; // Get the current index of the node

            if (index > 0) // Check if the node is not the first child
            {
                // Swap the node with its previous sibling
                TreeNode previousNode = siblings[index - 1];
                siblings.RemoveAt(index - 1);
                siblings.Insert(index, previousNode);
            }
        }
        private void MoveNodeDown(TreeNode node)
        {
            if (node == null || node.Parent == null)
                return; // Node has no parent (root node or invalid)

            TreeNodeCollection siblings = node.Parent.Nodes; // Get the sibling collection
            int index = node.Index; // Get the current index of the node

            if (index < siblings.Count - 1) // Check if the node is not the last child
            {
                // Swap the node with its next sibling
                TreeNode nextNode = siblings[index + 1];
                siblings.RemoveAt(index + 1);
                siblings.Insert(index, nextNode);
            }
        }
        private void MoveNodes(object? sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Up")
            {
                if (treeView1.SelectedNode.Tag == null || treeView1.SelectedNode.Parent.Tag == null)
                    return;

                string parentId = treeView1.SelectedNode.Parent.Tag.ToString();
                string childId = treeView1.SelectedNode.Tag.ToString();

                if (NodesManager.MoveNodeUp(parentId, childId))
                {
                    MoveNodeUp(treeView1.SelectedNode);
                }
            }
            else if (e.ClickedItem.Text == "Down")
            {
                if (treeView1.SelectedNode.Tag == null || treeView1.SelectedNode.Parent.Tag == null)
                    return;

                string parentId = treeView1.SelectedNode.Parent.Tag.ToString();
                string childId = treeView1.SelectedNode.Tag.ToString();

                if (NodesManager.MoveNodeDown(parentId, childId))
                {
                    MoveNodeDown(treeView1.SelectedNode);
                }
            }
        }


        public void SetTimesForDateRange(DateTime fromDate, DateTime toDate)
        {
            yearCalendars.Clear();
            for (DateTime currentDay = fromDate; currentDay <= toDate; currentDay = currentDay.AddDays(1))
            {
                yearCalendars.Add(new YearCalendar
                {
                    Date = currentDay,
                    FromTime = DateTime.Now.Date,
                    ToTime = DateTime.Now.Date,
                });
            }
        }

        public void UpdateDatesDgv()
        {
            daysDgv.Rows.Clear();
            int newMonth = 0;
            foreach (var currDate in yearCalendars)
            {
                DataGridViewRow row = daysDgv.Rows[daysDgv.Rows.Add()];
                if (row.IsNewRow)
                    continue; // Skip the new empty row
                row.Visible = currDate.Enabled;

                if (newMonth != currDate.Date.Month)
                {
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                    newMonth = currDate.Date.Month;
                }
                else
                {
                    if (currDate.DateColor != null)
                        row.DefaultCellStyle.BackColor = (Color)currDate.DateColor;
                    
                }

                if (!row.Visible)
                    continue;

                row.Cells["Date"].Value = currDate.Date.ToShortDateString();
                row.Cells["Day"].Value = currDate.Date.ToString("dddd");
                row.Cells["From"].Value = currDate.FromTime.ToShortTimeString(); // Example: 8:00 AM
                row.Cells["To"].Value = currDate.ToTime.ToShortTimeString(); // Example: 5:00 PM
                row.Cells["Time"].Value = (currDate.ToTime - currDate.FromTime).ToString(@"hh\:mm\:ss");
            }

        }

        private void TreeView1_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Back)
            {
                var id = treeView1.SelectedNode?.Tag;
                if (id != null)
                {
                    bool found = NodesManager.RemoveNodeById(id.ToString()!);
                    if (found)
                    {
                        treeView1.Nodes.Remove(treeView1.SelectedNode!);
                    }

                }
            }
            if (e.KeyCode == Keys.E)
            {
                var startDate = ((ITwoDatesNode)NodesManager.AddedNodes[0]).DateOne;
                var endDate = ((ITwoDatesNode)NodesManager.AddedNodes[0]).DateTwo;
                SetTimesForDateRange(startDate, endDate);
                bool success = StartProcess((IParentNode)NodesManager.AddedNodes!.FirstOrDefault()!);

                if (!success)
                {
                    MessageBox.Show("Œÿ√ ›Ì  ‰›Ì– ‘Ã—… «·› —« ");
                }
                else
                {
                    UpdateDatesDgv();
                }
            }
        }

        private bool StartProcess(IParentNode? parent)
        {
            if (parent == null)
                return false;

            var twoDatesNode = (ITwoDatesNode)parent;
            // Calculate the number of days between FromDate and ToDate
            int numberOfDays = (twoDatesNode.DateTwo.Date - twoDatesNode.DateOne.Date).Days + 1; // Inclusive of both dates

            // Iterate through each child
            foreach (var child in parent.Children)
            {
                if (child is IParentNode newParent)
                {
                    // If the child is also a parent, recursively process it
                    if (!StartProcess(newParent))
                    {
                        return false;
                    }
                }
                else
                {
                    var color = GetLightColor();
                    // If the child is not a parent, execute it `numberOfDays` times
                    for (int i = 0; i < numberOfDays; i++)
                    {
                        if (!ExecuteChild(child, twoDatesNode.DateOne.AddDays(i), i, color))
                        {
                            return false;
                        }
                    }
                }
            }

            return true;
        }
        private bool ExecuteChild(INode node, DateTime executionDate, int localDayIndex, Color? color)
        {
            var day = yearCalendars.FirstOrDefault(x => x.Date.Date == executionDate.Date);
            if (day == null)
                return false;

            day.DateColor = color;
            return node.Calculate(day!, localDayIndex);
        }

        public static Color GetLightColor()
        {
            Random _random = new Random();
            int r = _random.Next(180, 256); // High red value
            int g = _random.Next(180, 256); // High green value
            int b = _random.Next(180, 256); // High blue value

            return Color.FromArgb(r, g, b);
        }
        private void TreeView1_MouseDown(object? sender, MouseEventArgs e)
        {
            TreeNode? node = treeView1.GetNodeAt(e.X, e.Y);
            if (node != null)
            {
                treeView1.SelectedNode = node;
            }
        }

        private void RefreshFullTree()
        {
            treeView1.Nodes.Clear();
            TreeNodeHelper.RebuildTreeNode(treeView1.Nodes.Add("Start"), NodesManager.AddedNodes.First());
        }

        private void TreeView1_AfterSelect(object? sender, TreeViewEventArgs e)
        {
            if (e.Node == null)
                return;

            var id = e.Node.Tag;
            propertiesPanel.Controls.Clear();

            if (id != null)
            {
                var selectedNode = NodesManager.GetNodeById<INode>(id.ToString()!);

                if (selectedNode != null)
                {
                    if (selectedNode is INode baseNode)
                    {
                        Action? callback = () =>
                        {
                            UpdateFromParent(e.Node, baseNode);
                            TreeNodeHelper.RefreshTreeNodeFrom(treeView1.Nodes, selectedNode);
                            treeView1.Refresh();
                        };

                        baseNode.OnSelected?.Invoke(baseNode, new Dictionary<string, object>
                        {
                            {"propertiesPanel", propertiesPanel }
                        },
                        callback);
                    }

                }
                else
                {
                    MessageBox.Show("Œÿ√ ›Ì «Œ Ì«— «·⁄ﬁœ…");
                }
            }


        }

        private void UpdateFromParent(TreeNode? node, INode currentNode)
        {
            var parentId = node?.Parent?.Tag;
            if (parentId == null)
            {
                NodesManager.UpdateFromParentToChildern(null, currentNode);
                return;
            }

            var parentNode = NodesManager.GetNodeById<INode>(parentId.ToString()!);
            NodesManager.UpdateFromParentToChildern(parentNode, currentNode);

        }

        private void OnParentSelected(object? sender, ToolStripItemClickedEventArgs e)
        {
            var id = e.ClickedItem!.Tag;

            if (id != null)
            {

                if (treeView1.SelectedNode != null)
                {
                    var parentId = treeView1.SelectedNode.Tag;
                    var item = (ToolStripMenuItem)e.ClickedItem;
                    if (item.DropDownItems.Count != 0)
                    {
                        return;
                    }

                    INode? cloneNode = NodesManager.CloneParentNode(id, parentId);
                    if (cloneNode == null)
                        return;

                    var parentNode = NodesManager.GetNodeById<IParentNode>(parentId!.ToString()!);
                    if (parentNode == null) return;

                    NodesManager.AddChildNode(parentNode, cloneNode);
                    TreeNodeHelper.AddToTree(treeView1.SelectedNode, cloneNode);
                }
            }
        }

        private void OnPeriodSelected(object? sender, ToolStripItemClickedEventArgs e)
        {
            var id = e.ClickedItem!.Tag;

            if (id != null)
            {
                if (treeView1.SelectedNode != null)
                {
                    var parentId = treeView1.SelectedNode.Tag;
                    if (parentId == null)
                        return;
                    var cloneNode = NodesManager.CloneChildNode(id, parentId);

                    if (cloneNode == null) return;
                    var parentNode = NodesManager.GetNodeById<IParentNode>(parentId!.ToString()!, NodesManager.AddedNodes);
                    if (parentNode == null) return;
                    NodesManager.AddChildNode(parentNode, cloneNode);
                    TreeNodeHelper.AddToTree(treeView1.SelectedNode, cloneNode);
                }
            }
        }


        private void treeView1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                contextMenuStrip1.Show(this, e.Location);
            }
        }

    }
}
