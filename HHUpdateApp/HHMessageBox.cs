using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace HHUpdateApp
{
    public partial class HHMessageBox : Form
    {
        public string TitleText { get; set; } = "提示";

        public string ContentText { get; set; } = "暂无信息!";

        public HHMessageBox(string text)
        {
            InitializeComponent();
            ContentText = text;
        }
        public HHMessageBox(string text, string caption)
        {
            InitializeComponent();
            ContentText = text;
            TitleText = caption;
        }
        public static DialogResult Show(string text)
        {
            HHMessageBox msgbox = new HHMessageBox(text);
            return msgbox.ShowDialog();
        }

        public static DialogResult Show(string text, string caption)
        {
            HHMessageBox msgbox = new HHMessageBox(text, caption);
            return msgbox.ShowDialog();
        }

        #region 让窗体变成可移动
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();
        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        [DllImport("User32.dll")]
        private static extern IntPtr WindowFromPoint(Point p);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        private IntPtr moveObject = IntPtr.Zero;    //拖动窗体的句柄

        private void PNTop_MouseDown(object sender, MouseEventArgs e)
        {
            if (moveObject == IntPtr.Zero)
            {
                if (this.Parent != null)
                {
                    moveObject = this.Parent.Handle;
                }
                else
                {
                    moveObject = this.Handle;
                }
            }
            ReleaseCapture();
            SendMessage(moveObject, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        #endregion

        private void lblContent_Click(object sender, EventArgs e)
        {

        }
    }
}
