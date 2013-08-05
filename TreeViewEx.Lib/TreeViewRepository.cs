using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public partial class TreeViewRepository : UserControl
    {
        public ImageList ImageList { get { return imageList1; } }

        public TreeViewEx TreeView { get { return customStateTreeView1; } }

        public TreeViewRepository()
        {
            InitializeComponent();
        }

        private void tsmiExpandAll_Click(object sender, EventArgs e)
        {
            if (customStateTreeView1.SelectedNode != null)
                customStateTreeView1.SelectedNode.ExpandAll();
        }

        private void tsmiCollapseAll_Click(object sender, EventArgs e)
        {
            if (customStateTreeView1.SelectedNode != null)
                customStateTreeView1.SelectedNode.Collapse();
        }
    }

    public static class TreeViewWrapperImageListConstants
    {
        public const string Default = "Default";

        public const string File = "File";

        public const string Folder = "Folder";

        public const string FolderOpened = "FolderOpened";
    }
}
