using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TreeViewWrapperUtils
    {
        public static void Expand(TreeView treeView, int level)
        {
            if (treeView == null || treeView.Nodes.Count == 0 || level == 0)
                return;

            treeView.CollapseAll();

            Expand(treeView.Nodes, level);
        }

        private static void Expand(TreeNodeCollection nodes, int level)
        {
            if (nodes == null || level == 0)
                return;

            foreach (TreeNode node in nodes)
            {
                if (node.Nodes.Count > 0)
                {
                    node.Expand();
                    Expand(node.Nodes, level - 1);
                }
            }
        }

        /// <summary>
        /// 展开所有祖先节点
        /// </summary>
        public static void ExpandParentNodes(TreeNode node)
        {
            if (node == null)
                return;

            TreeNode parent = node.Parent;
            while (parent != null)
            {
                parent.Expand();
                parent = parent.Parent;
            }
        }

        public static T[] GetNodes<T>(TreeNodeCollection nodes)
        {
            return Select(nodes, c => c.Tag is T).Select(c => (T)c.Tag).ToArray();
        }

        public static TreeNode[] GetCheckedNodes(TreeNodeCollection nodes)
        {
            return Select(nodes, c => c.Checked);
        }

        public static T[] GetCheckedNodes<T>(TreeNodeCollection nodes)
        {
            return Select(nodes, c => c.Checked && c.Tag is T).Select(c => (T)c.Tag).ToArray();
        }

        /// <summary>
        /// 获取TreeView边界高度
        /// </summary>
        /// <returns></returns>
        public static int GetBoundHeight(TreeView treeView)
        {
            if (treeView == null || treeView.Nodes.Count == 0)
                return 0;

            TreeNode tn = treeView.Nodes[treeView.Nodes.Count - 1];
            while (tn.IsExpanded)
            {
                if (tn.Nodes.Count > 0)
                    tn = tn.Nodes[tn.Nodes.Count - 1];
                else
                    break;
            }

            //NOTE: 有时需要计算两次才能得到正确的结果，原因不明
            int i = tn.Bounds.Y + tn.Bounds.Height;
            return tn.Bounds.Y + tn.Bounds.Height;
        }

        /// <summary>
        /// 获取TreeView边界宽度
        /// </summary>
        /// <returns></returns>
        public static int GetBoundWidth(TreeView treeView, int level = 1)
        {
            if (treeView == null || treeView.Nodes.Count == 0)
                return 0;

            return GetBoundWidth(treeView.Nodes, level);
        }

        private static int GetBoundWidth(TreeNodeCollection nodes, int level, int evaluatedWidth = 0)
        {
            if (nodes.Count == 0)
                return 0;

            if (level == 0)
                return evaluatedWidth;

            for (int i = 0; i < nodes.Count; i++)
            {
                int width = nodes[i].Bounds.X + nodes[i].Bounds.Width;
                if (width > evaluatedWidth)
                    evaluatedWidth = width;

                if (nodes[i].Nodes.Count > 0)
                    evaluatedWidth = GetBoundWidth(nodes[i].Nodes, level - 1, evaluatedWidth);
            }

            return evaluatedWidth;
        }

        public static bool Any(TreeNodeCollection nodes, Func<TreeNode, bool> predicate)
        {
            if (predicate == null)
                throw new ArgumentNullException("predicate");

            foreach (TreeNode node in nodes)
            {
                if (predicate(node))
                    return true;

                if (node.Nodes.Count > 0)
                {
                    bool result = Any(node.Nodes, predicate);
                    if (result)
                        return true;
                }
            }

            return false;
        }

        public static TreeNode[] Select(TreeNodeCollection nodes, Func<TreeNode, bool> predicate = null)
        {
            List<TreeNode> results = new List<TreeNode>();

            foreach (TreeNode node in nodes)
            {
                if (predicate == null || predicate(node))
                {
                    results.Add(node);
                }
                if (node.Nodes.Count > 0)
                {
                    TreeNode[] children = Select(node.Nodes, predicate);
                    results.AddRange(children);
                }
            }

            return results.ToArray();
        }

        public static TreeNode First(TreeNodeCollection nodes, Func<TreeNode, bool> predicate = null, bool recursive = true)
        {
            foreach (TreeNode node in nodes)
            {
                if (predicate == null || predicate(node))
                {
                    return node;
                }
                if (recursive && node.Nodes.Count > 0)
                {
                    TreeNode child = First(node.Nodes, predicate);
                    if (child != null)
                        return child;
                }
            }

            return null;
        }
    }
}
