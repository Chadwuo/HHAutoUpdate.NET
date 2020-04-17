using System;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HHUpdateApp
{
    public partial class UpdateForm : Form
    {

        private UpdateWork work;

        public UpdateForm(UpdateWork _work)
        {
            InitializeComponent();
            work = _work;
        }

        private void UpdateForm_Load(object sender, EventArgs e)
        {
            btnWelcome.Visible = false;
        }

        private void btnWelcome_Click(object sender, EventArgs e)
        {
            work.AppStart();
            this.DialogResult = DialogResult.OK;
        }

        private void UpdateForm_Shown(object sender, EventArgs e)
        {
            BGWorkerUpdate.RunWorkerAsync();
        }


        private void backgroundWorkerUpdate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            lblAd.Text = "用心让交管业务更便捷";
            lblAd.Visible = true;
            lblMsg.Text = string.Format("{0}:{1}", work.ProgramName, work.RemoteVerInfo.ReleaseVersion);
            btnWelcome.Visible = true;
            btnWelcome.Text = "欢迎使用";
            updateBar.Visible = false;
        }

        private void BGWorkerUpdate_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            BGWorkerUpdate.ReportProgress(5, "检测升级环境...");
            Thread.Sleep(400);
            if (work.CheckProcessExist())
            {
                Thread.Sleep(400);
                BGWorkerUpdate.ReportProgress(10, "正在升级...");
                work.KillProcessExist();
            }
            Thread.Sleep(400);
            BGWorkerUpdate.ReportProgress(50, "正在升级...");
            work.Bak();

            Thread.Sleep(400);
            BGWorkerUpdate.ReportProgress(80, "正在下载更新文件...");
            work.DownLoad();

            Thread.Sleep(400);
            BGWorkerUpdate.ReportProgress(80, "正在配置更新...");
            work.Update();
        }

        private void BGWorkerUpdate_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            //修改进度条的显示。
            this.updateBar.Value = e.ProgressPercentage;

            //如果有更多的信息需要传递，可以使用 e.UserState 传递一个自定义的类型。
            //这是一个 object 类型的对象，您可以通过它传递任何类型。
            //我们仅把当前 sum 的值通过 e.UserState 传回，并通过显示在窗口上。
            this.lblMsg.Text = e.UserState.ToString();
        }

        private void BGWorkerUpdate_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                this.Close();
            }

            btnWelcome.Visible = true;
            

            //过程中的异常会被抓住，在这里可以进行处理。
            if (e.Error != null)
            {
                lblMsg.Text = e.Error.Message;
                btnWelcome.Text = "确定";
                //Type errorType = e.Error.GetType();
                //switch (errorType.Name)
                //{
                //    case "ArgumentNullException":
                //    case "MyException":
                //        //do something.
                //        break;
                //    default:
                //        //do something.
                //        break;
                //}
            }
            else
            {
                btnWelcome.Text = "欢迎使用";
                lblAd.Visible = true;
            }
        }
    }
}
