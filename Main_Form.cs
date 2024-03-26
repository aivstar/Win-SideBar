using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace SideBar
{
    public partial class MainForm : Form
    {
        funtion n_funtion = new funtion();
        private List<Thread> up_threadList = new List<Thread>();
        private List<Thread> left_threadList = new List<Thread>();
        private List<Thread> right_threadList = new List<Thread>();
        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Form_Load(object sender, EventArgs e)
        {
            n_funtion.Create_list();
            n_funtion.SetAutoRun(Application.ProductName, Application.ExecutablePath, true);

            if (Properties.Settings.Default.up_check)
            {
                tool_top_Menu.Checked = true;
                tool_UP_Menu_Click(sender, e);
            }
            if (Properties.Settings.Default.left_check)
            {
                tool_Left_Menu.Checked = true;
                tool_Left_Menu_Click(sender, e);
            }
            if (Properties.Settings.Default.right_check)
            {
                tool_Right_Menu.Checked = true;
                tool_Right_Menu_Click(sender, e);
            }

        }
        public static void ThreadProcUp()
        {
            TopForm form = new TopForm();
            form.ShowDialog();
        }
        public static void ThreadProcLeft()
        {
            LeftForm form = new LeftForm();
            form.ShowDialog();
        }
        public static void ThreadProcRight()
        {
            RightForm form = new RightForm();
            form.ShowDialog();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            // 设置隐藏
            this.Visible = false;
        }
        private void ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
            this.Dispose();
            this.Close();
        }


        private void tool_Left_Menu_Click(object sender, EventArgs e)
        {
            if (tool_Left_Menu.Checked)
            {
                Properties.Settings.Default.left_check = true;
                Thread t_left = new Thread(new ThreadStart(ThreadProcLeft));
                left_threadList.Add(t_left);
                t_left.SetApartmentState(ApartmentState.STA);
                t_left.Start();

            }
            else
            {

                Properties.Settings.Default.left_check = false;
                foreach (var t_left in left_threadList)
                {
                    t_left.Abort();
                }
                left_threadList.Clear();


            }
            Properties.Settings.Default.Save();
        }

        private void tool_UP_Menu_Click(object sender, EventArgs e)
        {
            if (tool_top_Menu.Checked)
            {
                Properties.Settings.Default.up_check = true;

                Thread t_up = new Thread(new ThreadStart(ThreadProcUp));
                up_threadList.Add(t_up);
                t_up.SetApartmentState(ApartmentState.STA);
                t_up.Start();
            }
            else
            {
                Properties.Settings.Default.up_check = false;
                foreach (var t_up in up_threadList)
                {
                    t_up.Abort();
                }
                up_threadList.Clear();
            }
            Properties.Settings.Default.Save();
        }

        private void tool_Right_Menu_Click(object sender, EventArgs e)
        {
            if (tool_Right_Menu.Checked)
            {
                Properties.Settings.Default.right_check = true;
                Thread t_right = new Thread(new ThreadStart(ThreadProcRight));
                right_threadList.Add(t_right);
                t_right.SetApartmentState(ApartmentState.STA);
                t_right.Start();
            }
            else
            {
                Properties.Settings.Default.right_check = false;
                foreach (var t_right in right_threadList)
                {

                    t_right.Abort();
                }
                right_threadList.Clear();

            }
            Properties.Settings.Default.Save();
        }

        private void tool_About_Click(object sender, EventArgs e)
        {
            AboutBox aboutbox = new AboutBox();
            aboutbox.Show();
        }

        private void tool_setting_Click(object sender, EventArgs e)
        {
            Configuration configuration = new Configuration();
            configuration.Show();
        }
    }
}
