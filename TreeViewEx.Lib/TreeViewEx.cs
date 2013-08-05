using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TreeViewEx : TreeView
    {
        protected override void WndProc(ref Message m)
        {
            // WM_LBUTTONDBLCLK
            if (m.Msg == 0x203)
            {
                Point point = PointToClient(Cursor.Position);
                TreeViewHitTestInfo hitTestInfo = HitTest(point);

                if (hitTestInfo.Node != null && hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
                {
                    //实现单击效果
                    //OnBeforeCheck(new TreeViewCancelEventArgs(hitTestInfo.Node, false, TreeViewAction.ByMouse));
                    //hitTestInfo.Node.Checked = !hitTestInfo.Node.Checked;
                    //OnAfterCheck(new TreeViewEventArgs(hitTestInfo.Node, TreeViewAction.ByMouse));
                    m.Result = IntPtr.Zero;
                    return;
                }
            }

            base.WndProc(ref m);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                TreeViewHitTestInfo hitTestInfo = HitTest(e.X, e.Y);
                if (hitTestInfo.Node != null && hitTestInfo.Location != TreeViewHitTestLocations.RightOfLabel)
                    SelectedNode = hitTestInfo.Node;
            }

            base.OnMouseDown(e);
        }
    }
}
