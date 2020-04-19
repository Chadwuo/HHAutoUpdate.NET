using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HHUpdate.Test
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
            string _updateAppPath = textBox1.Text;

            if (File.Exists(_updateAppPath))
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = _updateAppPath,
                    Arguments = "HHUpdate.Test "
                };
                Process proc = Process.Start(processStartInfo);
                if (proc != null)
                {
                    proc.WaitForExit();
                }
            }
        }
    }
}
