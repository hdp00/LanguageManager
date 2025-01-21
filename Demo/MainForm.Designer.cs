namespace Demo
{
    partial class MainForm
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("节点1");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("节点3");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("节点2", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("节点0", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3});
            this.btn_Button = new System.Windows.Forms.Button();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cmb_Language = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.工具栏CToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.工具栏DToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.group_Exclude = new System.Windows.Forms.GroupBox();
            this.btn_NewForm = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.toolStrip1.SuspendLayout();
            this.group_Exclude.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_Button
            // 
            this.btn_Button.Location = new System.Drawing.Point(9, 30);
            this.btn_Button.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_Button.Name = "btn_Button";
            this.btn_Button.Size = new System.Drawing.Size(231, 34);
            this.btn_Button.TabIndex = 0;
            this.btn_Button.Text = "收集文本";
            this.btn_Button.UseVisualStyleBackColor = true;
            this.btn_Button.Click += new System.EventHandler(this.btn_CollectText_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmb_Language,
            this.toolStripLabel1,
            this.toolStripDropDownButton1,
            this.toolStripComboBox1});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.toolStrip1.Size = new System.Drawing.Size(1676, 33);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cmb_Language
            // 
            this.cmb_Language.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmb_Language.Name = "cmb_Language";
            this.cmb_Language.Size = new System.Drawing.Size(180, 33);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(77, 28);
            this.toolStripLabel1.Text = "工具栏A";
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.工具栏CToolStripMenuItem,
            this.工具栏DToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(117, 28);
            this.toolStripDropDownButton1.Text = "工具栏B";
            // 
            // 工具栏CToolStripMenuItem
            // 
            this.工具栏CToolStripMenuItem.Name = "工具栏CToolStripMenuItem";
            this.工具栏CToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.工具栏CToolStripMenuItem.Text = "工具栏C";
            // 
            // 工具栏DToolStripMenuItem
            // 
            this.工具栏DToolStripMenuItem.Name = "工具栏DToolStripMenuItem";
            this.工具栏DToolStripMenuItem.Size = new System.Drawing.Size(178, 34);
            this.工具栏DToolStripMenuItem.Text = "工具栏D";
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "选项A",
            "选项B"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(180, 33);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "选项A",
            "选项B"});
            this.comboBox1.Location = new System.Drawing.Point(18, 70);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(180, 26);
            this.comboBox1.TabIndex = 2;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(18, 126);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 34);
            this.button1.TabIndex = 3;
            this.button1.Text = "收集文本";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(9, 74);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(229, 28);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "收集文本";
            // 
            // group_Exclude
            // 
            this.group_Exclude.Controls.Add(this.btn_NewForm);
            this.group_Exclude.Controls.Add(this.btn_Button);
            this.group_Exclude.Controls.Add(this.textBox1);
            this.group_Exclude.Location = new System.Drawing.Point(1406, 18);
            this.group_Exclude.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.group_Exclude.Name = "group_Exclude";
            this.group_Exclude.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.group_Exclude.Size = new System.Drawing.Size(252, 170);
            this.group_Exclude.TabIndex = 5;
            this.group_Exclude.TabStop = false;
            this.group_Exclude.Text = "排除";
            // 
            // btn_NewForm
            // 
            this.btn_NewForm.Location = new System.Drawing.Point(12, 114);
            this.btn_NewForm.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_NewForm.Name = "btn_NewForm";
            this.btn_NewForm.Size = new System.Drawing.Size(231, 34);
            this.btn_NewForm.TabIndex = 6;
            this.btn_NewForm.Text = "新建窗体";
            this.btn_NewForm.UseVisualStyleBackColor = true;
            this.btn_NewForm.Click += new System.EventHandler(this.btn_NewForm_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(18, 189);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(286, 44);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 28);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(278, 88);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "页面A";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 28);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(278, 12);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "页面B";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(22, 257);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "节点1";
            treeNode1.Text = "节点1";
            treeNode2.Name = "节点3";
            treeNode2.Text = "节点3";
            treeNode3.Name = "节点2";
            treeNode3.Text = "节点2";
            treeNode4.Name = "节点0";
            treeNode4.Text = "节点0";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode4});
            this.treeView1.Size = new System.Drawing.Size(282, 128);
            this.treeView1.TabIndex = 7;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1676, 1002);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.group_Exclude);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "MainForm";
            this.Text = "演示窗体";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.group_Exclude.ResumeLayout(false);
            this.group_Exclude.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Button;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripComboBox cmb_Language;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem 工具栏CToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 工具栏DToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox group_Exclude;
        private System.Windows.Forms.Button btn_NewForm;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TreeView treeView1;
    }
}

