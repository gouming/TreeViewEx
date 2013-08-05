using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TriStateTreeNode : TreeNode, IStateTreeNode
    {
        private CheckState _checkState;
        public virtual CheckState CheckState
        {
            get { return _checkState; }
            set
            {
                _checkState = value;
                StateImageIndex = (int)value;
            }
        }

        private bool _allowIndeterminateCheck;
        /// <summary>
        /// 部分选中状态，可以只选中当前节点不用同步子节点，比如选择连接属性
        /// </summary>
        public bool AllowIndeterminateCheck
        {
            get { return _allowIndeterminateCheck; }
            set { _allowIndeterminateCheck = value; }
        }

        public TriStateTreeNode()
            : this(null)
        {

        }

        public TriStateTreeNode(string text)
            : base(text)
        {
            CheckState = CheckState.Unchecked;
        }

        public virtual void UpdateState(TreeViewCancelEventArgs e)
        {
            if (_allowIndeterminateCheck)
                UpdateAllowIndeterminateNodeState(e.Node);
            else
                UpdateState(e.Node);
        }

        private void UpdateState(TreeNode node)
        {
            if (CheckState == CheckState.Checked || CheckState == CheckState.Indeterminate)
            {
                Checked = false;
                CheckState = CheckState.Unchecked;
            }
            else if (CheckState == CheckState.Unchecked)
            {
                Checked = true;
                CheckState = CheckState.Checked;
            }

            TriStateTreeViewNodeUtils.ToggleState(node.Nodes, CheckState);
            TriStateTreeViewNodeUtils.UpdateParentState(node, CheckState);
        }

        private void UpdateAllowIndeterminateNodeState(TreeNode node)
        {
            if (CheckState == CheckState.Checked)
            {
                Checked = false;
                CheckState = CheckState.Unchecked;
            }
            else if (CheckState == CheckState.Unchecked)
            {
                Checked = true;
                CheckState = CheckState.Indeterminate;
            }
            else if (CheckState == CheckState.Indeterminate)
            {
                Checked = true;
                CheckState = CheckState.Checked;
            }

            //部分选中时不用同步子节点的状态
            if (CheckState != CheckState.Indeterminate)
                TriStateTreeViewNodeUtils.ToggleState(node.Nodes, CheckState);
            TriStateTreeViewNodeUtils.UpdateParentState(node, CheckState);
        }
    }
}
