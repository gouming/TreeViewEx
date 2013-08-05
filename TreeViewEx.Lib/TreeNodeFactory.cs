using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TreeNodeFactory
    {
        public static TriStateTreeNode CreateNode(string text, string imageKey, object tag)
        {
            return new TriStateTreeNode
            {
                Text = text,
                ImageKey = imageKey,
                SelectedImageKey = imageKey,
                Tag = tag
            };
        }
    }
}
