using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class CustomStateTreeView : TreeViewEx
    {
        protected override void OnMouseDown(MouseEventArgs e)
        {
            TreeViewHitTestInfo info = HitTest(e.X, e.Y);
            if (StateImageList != null && info.Node != null && info.Location.ToString() == "StateImage")
                OnCustomCheck(info.Node, TreeViewAction.ByMouse);

            base.OnMouseDown(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Space:
                    if (StateImageList != null && SelectedNode != null)
                        OnCustomCheck(SelectedNode, TreeViewAction.ByKeyboard);

                    e.Handled = true;
                    break;
            }

            base.OnKeyDown(e);
        }

        protected virtual void OnCustomCheck(TreeNode node, TreeViewAction action)
        {
            TreeViewCancelEventArgs e = new TreeViewCancelEventArgs(node, false, action);
            OnBeforeCheck(e);

            if (e.Cancel)
                return;

            if (node is IStateTreeNode)
                (node as IStateTreeNode).UpdateState(e);

            OnAfterCheck(new TreeViewEventArgs(node, action));
        }
    }
}
