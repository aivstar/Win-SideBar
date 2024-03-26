namespace SideBar
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.MenuTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tool_top_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_Left_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_Right_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_setting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_Update = new System.Windows.Forms.ToolStripMenuItem();
            this.tool_About = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tool_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuTools.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.MenuTools;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SideBar";
            this.notifyIcon1.Visible = true;
            // 
            // MenuTools
            // 
            this.MenuTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_top_Menu,
            this.tool_Left_Menu,
            this.tool_Right_Menu,
            this.toolStripSeparator1,
            this.tool_setting,
            this.toolStripSeparator2,
            this.tool_Update,
            this.tool_About,
            this.toolStripSeparator3,
            this.tool_exit});
            this.MenuTools.Name = "contextMenuStrip1";
            this.MenuTools.Size = new System.Drawing.Size(181, 198);
            // 
            // tool_top_Menu
            // 
            this.tool_top_Menu.CheckOnClick = true;
            this.tool_top_Menu.Name = "tool_top_Menu";
            this.tool_top_Menu.Size = new System.Drawing.Size(180, 22);
            this.tool_top_Menu.Text = global::SideBar.Resources.strings.t_t_menu;
            this.tool_top_Menu.Click += new System.EventHandler(this.tool_Top_Menu_Click);
            // 
            // tool_Left_Menu
            // 
            this.tool_Left_Menu.CheckOnClick = true;
            this.tool_Left_Menu.Name = "tool_Left_Menu";
            this.tool_Left_Menu.Size = new System.Drawing.Size(180, 22);
            this.tool_Left_Menu.Text = global::SideBar.Resources.strings.t_l_menu;
            this.tool_Left_Menu.Click += new System.EventHandler(this.tool_Left_Menu_Click);
            // 
            // tool_Right_Menu
            // 
            this.tool_Right_Menu.CheckOnClick = true;
            this.tool_Right_Menu.Name = "tool_Right_Menu";
            this.tool_Right_Menu.Size = new System.Drawing.Size(180, 22);
            this.tool_Right_Menu.Text = global::SideBar.Resources.strings.t_r_menu;
            this.tool_Right_Menu.Click += new System.EventHandler(this.tool_Right_Menu_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // tool_setting
            // 
            this.tool_setting.Name = "tool_setting";
            this.tool_setting.Size = new System.Drawing.Size(180, 22);
            this.tool_setting.Text = global::SideBar.Resources.strings.t_set;
            this.tool_setting.Click += new System.EventHandler(this.tool_setting_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(177, 6);
            // 
            // tool_Update
            // 
            this.tool_Update.Name = "tool_Update";
            this.tool_Update.Size = new System.Drawing.Size(180, 22);
            this.tool_Update.Text = global::SideBar.Resources.strings.t_c_up;
            // 
            // tool_About
            // 
            this.tool_About.Name = "tool_About";
            this.tool_About.Size = new System.Drawing.Size(180, 22);
            this.tool_About.Text = global::SideBar.Resources.strings.t_about;
            this.tool_About.Click += new System.EventHandler(this.tool_About_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(177, 6);
            // 
            // tool_exit
            // 
            this.tool_exit.Name = "tool_exit";
            this.tool_exit.Size = new System.Drawing.Size(180, 22);
            this.tool_exit.Text = global::SideBar.Resources.strings.t_exit;
            this.tool_exit.Click += new System.EventHandler(this.ToolStripMenuItem1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(129, 27);
            this.ControlBox = false;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main Form";
            this.Load += new System.EventHandler(this.Main_Form_Load);
            this.MenuTools.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip MenuTools;
        private System.Windows.Forms.ToolStripMenuItem tool_exit;
        private System.Windows.Forms.ToolStripMenuItem tool_top_Menu;
        private System.Windows.Forms.ToolStripMenuItem tool_Left_Menu;
        private System.Windows.Forms.ToolStripMenuItem tool_Right_Menu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tool_Update;
        private System.Windows.Forms.ToolStripMenuItem tool_About;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem tool_setting;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
    }
}

