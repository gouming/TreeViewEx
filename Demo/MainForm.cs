using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Demo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            TestTree testTree = new TestTree();
            testTree.BuildTree();
            testTree.TriStateCheckBoxes = true;
            Controls.Add(testTree.TreeView);
        }
    }
}
