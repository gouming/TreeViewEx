using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TriStateTreeViewNodeUtils
    {
        public static void ToggleState(TreeNodeCollection nodes, CheckState checkState, Func<TriStateTreeNode, bool> predicate = null)
        {
            foreach (TreeNode node in nodes)
            {
                TriStateTreeNode triStateTreeNode = node as TriStateTreeNode;
                if (triStateTreeNode != null)
                {
                    if (predicate == null || predicate(triStateTreeNode))
                    {
                        triStateTreeNode.CheckState = checkState;
                        if (checkState == CheckState.Checked)
                            triStateTreeNode.Checked = true;
                        else if (checkState == CheckState.Unchecked)
                            triStateTreeNode.Checked = false;
                    }

                    if (node.Nodes.Count > 0)
                        ToggleState(node.Nodes, checkState, predicate);
                }
            }
        }

        public static void UpdateParentState(TreeNode node, CheckState checkState)
        {
            if (node.Parent == null)
                return;

            TriStateTreeNode parent = node.Parent as TriStateTreeNode;

            bool diffStateInChildNodes = false;
            foreach (TreeNode child in parent.Nodes)
            {
                if (!checkState.Equals((child as TriStateTreeNode).CheckState))
                {
                    diffStateInChildNodes = true;
                    break;
                }
            }

            CheckState tmpCheckState = diffStateInChildNodes ? CheckState.Indeterminate : checkState;
            //需要先设置Checked属性，因为设置Checked属性也会改变CheckBox图标状态
            if (tmpCheckState == CheckState.Checked || tmpCheckState == CheckState.Indeterminate)
                parent.Checked = true;
            else if (tmpCheckState == CheckState.Unchecked)
                parent.Checked = false;

            parent.CheckState = tmpCheckState;

            UpdateParentState(parent, checkState);
        }
    }
}
