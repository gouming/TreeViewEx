using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using TreeViewEx.Lib;

namespace Demo
{
    class TestTree : TreeViewWrapper
    {
        public void BuildTree()
        {
            TriStateTreeNode rootNode = new TriStateTreeNode("root");
            BuildNode(rootNode, 0);
            TreeView.Nodes.Add(rootNode);
            rootNode.ExpandAll();
        }

        private void BuildNode(TriStateTreeNode parentNode, int level)
        {
            if (level > 2)
                return;

            for (int i = 0; i < 2; i++)
            {
                TriStateTreeNode node = new TriStateTreeNode(string.Concat("node", level, i));
                parentNode.Nodes.Add(node);

                BuildNode(node, level + 1);
            }
        }
    }
}
