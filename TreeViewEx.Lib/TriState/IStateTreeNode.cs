using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public interface IStateTreeNode
    {
        void UpdateState(TreeViewCancelEventArgs e);
    }
}
