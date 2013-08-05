namespace TreeViewEx.Lib
{
    partial class TreeViewRepository
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TreeViewRepository));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmiExpandAll = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCollapseAll = new System.Windows.Forms.ToolStripMenuItem();
            this.imageList2 = new System.Windows.Forms.ImageList(this.components);
            this.customStateTreeView1 = new CustomStateTreeView();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Default");
            this.imageList1.Images.SetKeyName(1, "Folder");
            this.imageList1.Images.SetKeyName(2, "FolderOpened");
            this.imageList1.Images.SetKeyName(3, "File");
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiExpandAll,
            this.tsmiCollapseAll});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(125, 48);
            // 
            // tsmiExpandAll
            // 
            this.tsmiExpandAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmiExpandAll.Image")));
            this.tsmiExpandAll.Name = "tsmiExpandAll";
            this.tsmiExpandAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiExpandAll.Text = "全部展开";
            this.tsmiExpandAll.Click += new System.EventHandler(this.tsmiExpandAll_Click);
            // 
            // tsmiCollapseAll
            // 
            this.tsmiCollapseAll.Image = ((System.Drawing.Image)(resources.GetObject("tsmiCollapseAll.Image")));
            this.tsmiCollapseAll.Name = "tsmiCollapseAll";
            this.tsmiCollapseAll.Size = new System.Drawing.Size(124, 22);
            this.tsmiCollapseAll.Text = "全部折叠";
            this.tsmiCollapseAll.Click += new System.EventHandler(this.tsmiCollapseAll_Click);
            // 
            // imageList2
            // 
            this.imageList2.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList2.ImageStream")));
            this.imageList2.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList2.Images.SetKeyName(0, "icon11.png");
            this.imageList2.Images.SetKeyName(1, "icon22.png");
            this.imageList2.Images.SetKeyName(2, "icon33.png");
            // 
            // customStateTreeView1
            // 
            this.customStateTreeView1.ContextMenuStrip = this.contextMenuStrip1;
            this.customStateTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.customStateTreeView1.HideSelection = false;
            this.customStateTreeView1.ImageIndex = 0;
            this.customStateTreeView1.ImageList = this.imageList1;
            this.customStateTreeView1.Location = new System.Drawing.Point(0, 0);
            this.customStateTreeView1.Name = "customStateTreeView1";
            this.customStateTreeView1.SelectedImageIndex = 0;
            this.customStateTreeView1.ShowNodeToolTips = true;
            this.customStateTreeView1.Size = new System.Drawing.Size(300, 400);
            this.customStateTreeView1.StateImageList = this.imageList2;
            this.customStateTreeView1.TabIndex = 4;
            // 
            // TreeViewRepository
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.customStateTreeView1);
            this.Name = "TreeViewRepository";
            this.Size = new System.Drawing.Size(300, 400);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiExpandAll;
        private System.Windows.Forms.ToolStripMenuItem tsmiCollapseAll;
        private System.Windows.Forms.ImageList imageList2;
        private CustomStateTreeView customStateTreeView1;
    }
}
