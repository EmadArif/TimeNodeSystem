
using TimeAndAttendanceSystem.Controls;
using TimeAndAttendanceSystem.PeriodNodes.Interfaces;

namespace TimeAndAttendanceSystem.Helpers
{
    public static class TreeNodeHelper
    {
        public static TreeNode AddToTree(TreeNode parent, INode node)
        {
            TreeNode newNode = new()
            {
                Tag = node.Id,
                
                Text = node.FullName.ToString()
            };
            parent.Nodes.Add(newNode);
            parent.ExpandAll();
            return newNode;
        }

        public static bool RefreshTreeNodeFrom(TreeNodeCollection tree, INode node)
        {
            for (int i = tree.Count - 1; i >= 0; i--)
            {
                TreeNode currentNode = tree[i];

                // If the node's text matches the name, remove it and its sub-nodes
                if (currentNode.Tag != null && currentNode.Tag.ToString() == node.Id)
                {
                    currentNode.Text = node.FullName;
                    if(node is IParentNode pNode)
                    {
                        if(pNode.Children != null)
                        {
                            foreach (var child in pNode.Children)
                            {
                                RefreshTreeNodeFrom(currentNode.Nodes, child);

                            }
                        }
                    }
                }
                else
                {
                    // Recursively check the child nodes
                    RefreshTreeNodeFrom(currentNode.Nodes, node);
                }
            }

            return false;
        }
        public static bool RefreshSingleTreeNode(TreeNodeCollection tree, INode node)
        {
            
            for (int i = tree.Count - 1; i >= 0; i--)
            {
                TreeNode currentNode = tree[i];

                // If the node's text matches the name, remove it and its sub-nodes
                if (currentNode.Tag != null && currentNode.Tag.ToString() == node.Id)
                {
                    currentNode.Text = node.FullName;
                    return true;
                }
                else
                {
                    // Recursively check the child nodes
                    RefreshSingleTreeNode(currentNode.Nodes, node);
                }
            }

            return false;
        }
        public static void RemoveNodeById(TreeNodeCollection tree, string id)
        {
            // Iterate through the nodes collection
            for (int i = tree.Count - 1; i >= 0; i--)
            {
                TreeNode node = tree[i];

                // If the node's text matches the name, remove it and its sub-nodes
                if (node.Tag != null && node.Tag.ToString() == id)
                {
                    tree.RemoveAt(i);
                }
                else
                {
                    // Recursively check the child nodes
                    RemoveNodeById(node.Nodes, id);
                }
            }
        }

        public static void RebuildTreeNode(TreeNode parentNode, INode node)
        {

            if (node is IParentNode pNode)
            {
                var newNode = AddToTree(parentNode, node);

                if (pNode.Children.Count > 0)
                {
                    foreach (var sub in pNode.Children)
                    {
                        RebuildTreeNode(newNode, sub);
                    }
                }
            }
            else
            {
                AddToTree(parentNode, node);
            }
        }
    }
}
