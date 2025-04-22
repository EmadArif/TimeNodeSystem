using System.Net.Mail;
using TimeAndAttendanceSystem.Nodes;
using TimeAndAttendanceSystem.PeriodNodes;
using TimeAndAttendanceSystem.PeriodNodes.Abstructs;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Helpers
{
    public static class NodesManager
    {

        public static readonly IReadOnlyList<INode> Periods = [
            new BetweenDatesNode { Id = "1", Name = "Between Dates", OnSelected = ControlsManager.TwoDatesControl },

            new NDaysTimeNode { Id = Guid.NewGuid().ToString(), Name = "N Days Time", OnSelected = ControlsManager.NTimesTableControl },
            new WeeklyNode { Id = Guid.NewGuid().ToString(), Name = "Weekly", OnSelected = ControlsManager.NTimesTableControl },
            new HolidayNode { Id = Guid.NewGuid().ToString(), Name = "Holiday", OnSelected = ControlsManager.HolidayTableControl },
            new TestNode { Id = Guid.NewGuid().ToString(), Name = "TestNode", OnSelected = ControlsManager.DefaultNodeControl },
        ];


        public static readonly List<INode> AddedNodes = [
            new YearNode{
                Id = Guid.NewGuid().ToString(),
                Name = "Year",
                OnSelected = ControlsManager.TwoDatesControl
            }
        ];
        public static bool MoveNodeUp(string parentId, string childId)
        {
            var node = GetNodeById<INode>(childId);
            var nodes = GetNodeById<IParentNode>(parentId)!.Children;

            if (nodes == null || node == null)
                return false;

            int index = nodes.IndexOf(node);

            if (index > 0) // Check if the node is not the first element
            {
                // Swap the node with the previous node
                INode previousNode = nodes[index - 1];
                nodes[index - 1] = node;
                nodes[index] = previousNode;
            }

            return true;
        }
        public static bool MoveNodeDown(string parentId, string childId)
        {
            var node = GetNodeById<INode>(childId);
            var nodes = GetNodeById<IParentNode>(parentId)!.Children;

            if (nodes == null || node == null)
                return false;

            int index = nodes.IndexOf(node);

            if (index < nodes.Count - 1) // Check if the node is not the last element
            {
                // Swap the node with the next node
                INode nextNode = nodes[index + 1];
                nodes[index + 1] = node;
                nodes[index] = nextNode;
            }

            return true;
        }
        public static void AddChildNode(IParentNode parent, INode child)
        {
            child.Initalize(parent);
            parent.Children.Add(child);
        }

        public static bool RemoveNodeById(string id, INode? currentNode = null)
        {
            if (currentNode == null)
                currentNode = AddedNodes.FirstOrDefault();

            if (currentNode == null) return false;

            if (currentNode.Id == id) //this is the first node
            {
                //Cannot remove first node
                if (currentNode.Id == AddedNodes.FirstOrDefault()!.Id)
                    return false;

                AddedNodes.RemoveAll(x => x.Id == id);
            }

            if (currentNode is IParentNode parentNode)
            {
                int removedCount = parentNode.Children.RemoveAll(x => x.Id == id);
                if (removedCount > 0)
                    return true;
                else
                {
                    foreach (var node in parentNode.Children)
                    {
                        if (RemoveNodeById(id, node))
                            return true;
                    }
                }
            }


            return false;
        }

        public static INode? CloneChildNode(object? id, object? parentId)
        {

            var parentNode = GetNodeById<IParentNode>(parentId.ToString());
            bool hasParentNode = parentNode != null;
            if (!hasParentNode)
                return null;

            var period = Periods.FirstOrDefault(p => p.Id == id.ToString() && p is not IParentNode);
            if (period == null)
                return null;

            var clonedNode = (INode)period.Clone();

            string guid = Guid.NewGuid().ToString();
            clonedNode.Id = guid;

            return clonedNode;
        }

        public static T? GetNodeById<T>(string id, List<INode>? nodes = null, bool isFirstRound = true) where T : INode
        {
            var currNodes = isFirstRound ? AddedNodes : nodes;
            if (currNodes == null)
                return default;
            T? foundChild = default;
            foreach (INode n in currNodes)
            {
                if (n is T && n.Id == id)
                {
                    return (T)n;
                }
                if (n is IParentNode parent && parent.Children != null && parent.Children.Count > 0)
                {
                    foundChild = GetNodeById<T>(id, parent.Children, false);
                }
                if (foundChild != null)
                    return foundChild;
            }

            return default;
        }
        public static void UpdateFromParentToChildern(INode? parentNode, INode currentNode)
        {
            if (parentNode != null)
                currentNode.Update(parentNode);
            else
                currentNode.Update(currentNode);

            if (currentNode is IParentNode currentParent)
            {
                if (currentParent.Children == null)
                    return;
                

                foreach (var item in currentParent.Children)
                {
                    UpdateFromParentToChildern(currentParent, item);
                }
            }

        }

        public static INode? CloneParentNode(object? id, object? parentId)
        {
            if (parentId == null) return null;
            var parentNode = GetNodeById<IParentNode>(parentId.ToString());

            if (parentNode == null)
                return null;


            var newParentNode = Periods.FirstOrDefault(p => p.Id == id.ToString() && p is IParentNode);
            if (newParentNode == null)
                return null;

            var cloneNode = (INode)newParentNode.Clone();

            string guid = Guid.NewGuid().ToString();
            cloneNode.Id = guid;

            return cloneNode;
        }

    }
}
