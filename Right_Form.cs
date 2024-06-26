﻿using IWshRuntimeLibrary;
using System;

using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SideBar
{
    public partial class RightForm : Form
    {
        funtion n_funtion = new funtion();
        string type = "right";
        public RightForm()
        {
            InitializeComponent();
        }

        new bool Hide = false;       //用来表示当前隐藏状态，例如Hide=false就是 不在隐藏状态



        private void Right_Form_Load(object sender, EventArgs e)
        {
            this.Opacity = 0.5;
            Screen screen = Screen.PrimaryScreen;
            int width = screen.Bounds.Width;
            this.Left = width - 3;            //隐藏窗口，窗口宽度加3取反(为负数)
            Hide = true;

            Right_timer.Interval = 1;//1毫秒
            Right_timer.Start();     //启动定时器2 
            update_btn();   //刷新辅助任务栏按钮

        }

        private void update_btn()
        {
            Controls.Clear();

            string[,] up_list = n_funtion.Shortcut_List(type);
            if (up_list != null)
            {
                int up_coun = up_list.GetLength(1);
                for (int i = 0; i < up_coun; i++)
                {
                    Create_btn(up_list[0, i], up_list[1, i], i, up_list[2, i]);
                }
            }
        }


        private void Right_Tick(object sender, EventArgs e)
        {
            //this.TopMost = false;        //窗体不显示在所有软件最前面
            Point pt = new Point(Form.MousePosition.X, Form.MousePosition.Y);//获得当前鼠标位置 
            Screen screen = Screen.PrimaryScreen;
            int width = screen.Bounds.Width;            //获取屏幕的宽度     
            if (!this.Bounds.Contains(pt))              //判断鼠标是否在窗体内 
            {   //如果不在窗体内
                if (Hide == false)
                {
                    if (width - this.Location.X - this.Width < 10)//窗口右边碰到屏幕最右边
                    {
                        this.Left = width - 3;            //隐藏窗口，窗口宽度加3取反(为负数)
                        Hide = true;

                    }

                }

            }
            else
            {    //如果在窗体内
                if (width - this.Location.X - this.Width > 20)
                {
                    Hide = false;
                }

                //如果在窗体内且之前是隐藏状态
                if (Hide == true)
                {
                    this.TopMost = true;        //窗体显示在所有软件最前面
                    this.Left = width - this.Width;
                    Hide = false;
                }
            }
        }

        private void Right_Form_DragEnter(object sender, DragEventArgs e)                                         //获得“信息”
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;                                                              //重要代码：表明是所有类型的数据，比如文件路径
            else
                e.Effect = DragDropEffects.None;
        }
        private void Right_Form_DragDrop(object sender, DragEventArgs e)                                          //解析信息
        {
            string tname = "";
            int con_num = this.Controls.Count;
            if (con_num < 8)
            {


                string[] path = (string[])e.Data.GetData(DataFormats.FileDrop);       //获得路径
                for (int i = 0; i < path.Length; i++)
                {
                    string tpath;
                    string one_path = path[i];


                    if (Path.GetExtension(one_path) == ".lnk")
                    {
                        WshShell shell = new WshShell();
                        IWshShortcut shortcut = (IWshShortcut)shell.CreateShortcut(one_path);
                        tpath = n_funtion.Validate_Shortcut_Path(shortcut.TargetPath);

                    }
                    else
                    {
                        tpath = one_path;
                    }
                    if (Directory.Exists(tpath))
                    { MessageBox.Show("暂不支持文件夹"); }
                    else
                    {


                        tname = Path.GetFileNameWithoutExtension(one_path);
                        string id = DateTime.Now.Ticks.ToString();
                        Create_btn(tname, tpath, con_num, id);
                        n_funtion.save_Shortcut(type, tname, tpath, id);
                        con_num = this.Controls.Count;
                        if (con_num == 8)
                        {
                            break;
                        }
                    }
                }
            }
        }

        private void Create_btn(string name, string link, int con_num, string id)
        {
            Point location = new Point();
            Point old_l = new Point();
            String old_name = "";
            Image img = System.Drawing.Icon.ExtractAssociatedIcon(link).ToBitmap();

            Button button = new Button();
            button.BackgroundImage = img;
            button.Name = id;
            button.Size = new Size(48, 48);
            button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            int l_point = 10 + con_num * 58;
            button.Location = new Point(2, l_point);
            ToolTip toolTip1 = new ToolTip();
            ContextMenuStrip RightItem = new ContextMenuStrip();

            ToolStripMenuItem tool_del = new ToolStripMenuItem();
            tool_del.Text = SideBar.Resources.strings.t_del;
            tool_del.Click += delegate
            {
                Tool_del_Click();
            };
            RightItem.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { tool_del });
            button.ContextMenuStrip = RightItem;

            button.MouseHover += delegate { Button_MouseHover(); };
            button.MouseLeave += delegate { Button_MouseLeave(); };
            button.MouseDown += delegate (object sender, MouseEventArgs e) { Button_MouseDown(e); };
            button.MouseMove += delegate (object sender, MouseEventArgs e) { Button_MouseMove(sender, e); };
            button.MouseUp += delegate (object sender, MouseEventArgs e) { Button_MouseUp(e); };
            this.Controls.Add(button);

            void Button_MouseHover()
            {
                button.Location = new Point(0, l_point - 2);
                button.Size = new Size(52, 52);
                toolTip1.ShowAlways = true;
                toolTip1.SetToolTip(button, name);
            }
            void Button_MouseLeave()
            {
                button.Location = new Point(2, l_point);
                button.Size = new Size(50, 50);
            }
            void Tool_del_Click()
            {
                n_funtion.del_Shortcut(type, id);
                update_btn();
            }
            void Button_MouseUp(MouseEventArgs e)
            {

                if (button.Location == old_l && e.Button == MouseButtons.Left)
                { System.Diagnostics.Process.Start(link); }
                else if (button.Location.Y < Height)
                {
                    int btn_id = Convert.ToInt32((button.Location.Y - 5) / 58);

                    n_funtion.move_Shortcut(type, old_name, btn_id);
                    update_btn();
                }


            }
            void Button_MouseDown(MouseEventArgs e)
            {
                old_l = button.Location;
                location = e.Location;
                old_name = GetChildAtPoint(old_l).Name;
            }
            void Button_MouseMove(object sender, MouseEventArgs e)
            {

                if (e.Button == MouseButtons.Left)
                {
                    Button b = sender as Button;
                    b.Location = new Point(b.Location.X + (e.X - location.X), b.Location.Y + (e.Y - location.Y));
                }
            }



        }








        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_EX_APPWINDOW = 0x40000;
                const int WS_EX_TOOLWINDOW = 0x80;
                CreateParams cp = base.CreateParams;
                cp.ExStyle &= (~WS_EX_APPWINDOW);    // 不显示在TaskBar
                cp.ExStyle |= WS_EX_TOOLWINDOW;      // 不显示在Alt-Tab
                return cp;
            }
        }
    }
}

