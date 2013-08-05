using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TreeViewEx.Lib
{
    public class TreeViewWrapper
    {
        private TreeViewRepository _treeViewRepository;
        private ImageList _stateImageList;

        private TreeView _treeView;
        public virtual TreeView TreeView
        {
            get { return _treeView; }
        }

        private bool _triStateCheckBoxes;
        public bool TriStateCheckBoxes
        {
            get { return _triStateCheckBoxes; }
            set
            {
                _triStateCheckBoxes = value;
                if (value)
                {
                    _treeView.CheckBoxes = false;
                    _treeView.StateImageList = _stateImageList;
                }
                else
                    _treeView.StateImageList = null;
            }
        }

        public TreeViewWrapper()
        {
            _treeViewRepository = new TreeViewRepository();
            _treeView = _treeViewRepository.TreeView;
            _stateImageList = _treeView.StateImageList;
            _treeView.StateImageList = null;

            _treeView.AfterExpand += TreeView_AfterExpand;
            _treeView.AfterCollapse += TreeView_AfterCollapse;
            _treeView.KeyDown += TreeView_KeyDown;
        }

        protected virtual void TreeView_AfterExpand(object sender, TreeViewEventArgs e)
        {
            ToggleFolderNodeImageKey(e.Node);
        }

        protected virtual void TreeView_AfterCollapse(object sender, TreeViewEventArgs e)
        {
            ToggleFolderNodeImageKey(e.Node);
        }

        void TreeView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == (Keys.Control | Keys.A))
                SelectAll();
        }

        protected virtual void ToggleFolderNodeImageKey(TreeNode node)
        {
            if (node == null)
                return;

            if (node.ImageKey == TreeViewWrapperImageListConstants.Folder)
                node.SelectedImageKey = node.ImageKey = TreeViewWrapperImageListConstants.FolderOpened;
            else if (node.ImageKey == TreeViewWrapperImageListConstants.FolderOpened)
                node.SelectedImageKey = node.ImageKey = TreeViewWrapperImageListConstants.Folder;
        }

        private void SelectAll()
        {
            if (!_triStateCheckBoxes || _treeView.Nodes.Count == 0)
                return;

            foreach (TreeNode node in _treeView.Nodes)
            {
                if (node is TriStateTreeNode)
                {
                    TriStateTreeNode triStateTreeNode = node as TriStateTreeNode;
                    triStateTreeNode.Checked = true;
                    triStateTreeNode.CheckState = CheckState.Checked;
                    TriStateTreeViewNodeUtils.ToggleState(node.Nodes, CheckState.Checked);
                }
            }
        }
    }
}
