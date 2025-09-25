using Nobody.MTHBLL;
using Nobody.MTHModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Nobody.MTHProject
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
            adminManager = new AdminManager();
        }
        private AdminManager adminManager;
        private void btn_login_Click(object sender, EventArgs e)
        {
            Login();
        }

       public void Login()
        {
            var loginName = this.txt_LoginName.Text;
            if (string.IsNullOrEmpty(loginName.Trim()))
            {
                new FrmMsgBoxWithoutAck("用户登录", "请输入用户名!").Show();
                return;
            }
            var loginPwd = this.txt_passwd.Text;
            if (string.IsNullOrEmpty(loginName.Trim()))
            {
                new FrmMsgBoxWithoutAck("用户登录", "请输入用户名!").Show();
                return;
            }
            //var admin = new SysAdmin() { LoginName = loginName, LoginPwd = loginPwd };
            var admin = adminManager.Login(loginName,loginPwd);
            if (admin.LoginId != null)
            {
                CommonMethods.CurrentUser = admin;
                new FrmMsgBoxWithoutAck("用户登录", "登录成功!").Show();
                this.DialogResult = DialogResult.OK;
            }else
            {
                new FrmMsgBoxWithoutAck("用户登录", "用户名或密码错误!").Show();
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt_passwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                Login();
            }
        }

        

        private void StartKeyBoard()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("软件盘可执行文件不存在！");
                    return;
                }

                softKey = System.Diagnostics.Process.Start(Environment.SystemDirectory + "\\osk.exe");
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private System.Diagnostics.Process softKey;

        private void Use_KeyBoard_DoubleClick(object sender, EventArgs e)
        {
            StartKeyBoard();
        }
    }
}
