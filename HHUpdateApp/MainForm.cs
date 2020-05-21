using HHUpdateApp.Properties;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HHUpdateApp
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// 需要更新的业务应用程序,稍后如果需要更新,根据这个名字把相应进程关闭
        /// </summary>
        private string launchAppName;

        /// <summary>
        /// 需要更新的业务应用程序所在目录
        /// </summary>
        private string launchAppDirectoryName;

        /// <summary>
        /// 需要更新的业务应用程序版本号
        /// </summary>
        private string launchAppVer;

        /// <summary>
        /// 需要更新的业务应用程序关联的进程
        /// </summary>
        private Process[] launchProcess;

        /// <summary>
        /// 检查更新模式：0,自动更新；1，手动检查（区别就是，自动更新的状态下，除非有新版本更新，才会显示提示框）
        /// </summary>
        private string checkMode;

        /// <summary>
        /// 服务器上的版本信息
        /// </summary>
        private RemoteVersionInfo verInfo;

        public MainForm(string _launchAppName, string _checkMode)
        {
            InitializeComponent();
            launchAppName = _launchAppName;
            checkMode = _checkMode;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            //通过业务应用程序名，获取其进程信息
            launchProcess = Process.GetProcessesByName(launchAppName);

            if (launchProcess.Length > 0)
            {
                launchAppDirectoryName = Path.GetDirectoryName(launchProcess[0].MainModule.FileName);
                launchAppVer = launchProcess[0].MainModule.FileVersionInfo.ProductVersion;
            }
            else
            {
                HHMessageBox.Show("应用程序未启动: _" + launchAppName);
                Application.Exit();
            }

            //下载服务器上版本更新信息
            verInfo = DownloadUpdateInfo(Program.ServerUpdateUrl);

            if (verInfo != null)
            {
                //比较版本号
                if (VersionCompare(launchAppVer, verInfo.ReleaseVersion) >= 0)
                {
                    //this.Hide();//隐藏当前窗口

                    if (checkMode == "1")
                    {
                        HHMessageBox.Show("当前版本已经是最新版本");
                    }

                    Application.Exit();
                }
                else
                {
                    this.lblContent.Text = verInfo.VersionDesc;
                }

            }
            else
            {
                Application.Exit();
            }
        }

        /// <summary>
        /// 如果以后更新,则将更新程序关闭
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateLater_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        /// <summary>
        /// 立即更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUpdateNow_Click(object sender, EventArgs e)
        {
            this.Hide();//隐藏当前窗口

            UpdateWork work = new UpdateWork(launchAppDirectoryName, verInfo);

            //关闭业务应用程序关联的进程
            foreach (Process p in launchProcess)
            {
                p.Kill();
                p.Close();
            }

            UpdateForm updateForm = new UpdateForm(work);
            if (updateForm.ShowDialog() == DialogResult.OK)
            {
                Application.Exit();
            }
        }
        /// <summary>
        /// 忽略本次版本更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnIgnore_Click(object sender, EventArgs e)
        {
            //忽略这个版本更新，后面版本在做吧
            Application.Exit();
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


        #region 私有方法
        /// <summary>
        /// 下载服务器上版本信息
        /// </summary>
        /// <param name="serverUrl"></param>
        /// <returns></returns>
        private RemoteVersionInfo DownloadUpdateInfo(string serverUrl)
        {
            string updateJson = "";
            using (WebClient updateClt = new WebClient())
            {

                try
                {
                    byte[] bJson = updateClt.DownloadData(serverUrl);
                    updateJson = System.Text.Encoding.UTF8.GetString(bJson);
                }
                catch (Exception ex)
                {
                    LogManger.Instance.Error("下载服务器上版本信息错误", ex);
                    HHMessageBox.Show(string.Format("升级信息从 {0} 下载失败：{1}", serverUrl, ex.Message), "错误");
                    return null;
                }
                try
                {
                    RemoteVersionInfo info = new RemoteVersionInfo();
                    info = JsonConvert.DeserializeObject<RemoteVersionInfo>(updateJson);
                    return info;
                }
                catch (Exception ex)
                {
                    LogManger.Instance.Error("升级 json 文件错误", ex);
                    HHMessageBox.Show(string.Format("升级 json 文件错误：{0}\r\n{0}", ex.Message, updateJson), "错误");
                    return null;
                }
            }
        }

        /// <summary>
        /// 比较两个版本号的大小。
        /// </summary>
        /// <param name="ver1">版本 1。</param>
        /// <param name="ver2">版本 2。</param>
        /// <returns>大于 0，则 ver1 大；小于 0，则 ver2 大；0，则相等。</returns>
        /// <remarks>通过将版本号中的数字点拆分为字符串数组进行比较，比较每个字符串的大小，如果字符串可以转换为数字，则使用数字比较。
        /// </remarks>
        private static int VersionCompare(string ver1, string ver2)
        {
            string[] item1 = ver1.Split('.');
            string[] item2 = ver2.Split('.');
            int len = item1.Length > item2.Length ? item1.Length : item2.Length;
            int i_item1, i_item2, i = 0;
            int cmpValue = 0;
            while (i < len && cmpValue == 0)
            {
                i_item1 = 0; i_item2 = 0;
                if (int.TryParse(item1[i], out i_item1) && int.TryParse(item2[i], out i_item2))
                {
                    cmpValue = i_item1 - i_item2;
                }
                else
                {
                    cmpValue = string.Compare(item1[i], item2[i]);
                }
                i++;
            }
            // 两个版本长度不一致，但是前一部分相同的，以长度长的为大。
            if (cmpValue == 0 && item1.Length != item2.Length)
            {
                cmpValue = item1.Length - item2.Length;
            }
            return cmpValue;
        }
        #endregion

    }
}
