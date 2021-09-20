using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 检查更新按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo()
            {
                FileName = @"F:\MyGitHub\HHUpdateApp\HHUpdateApp\bin\Debug\HHUpdateApp.exe",//参数:【升级程序】HHUpdateApp.exe程序所在路径
                Arguments = "sss " + "1", //参数1:【应用程序】的名词，例如：LOLClient；参数1:检查更新模式
            };
            
            Process proc = Process.Start(processStartInfo);
            if (proc != null)
            {
                proc.WaitForExit();
            }
        }
    }
}
