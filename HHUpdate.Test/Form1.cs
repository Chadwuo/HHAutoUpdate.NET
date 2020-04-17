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

        private void button1_Click(object sender, EventArgs e)
        {
            string _updateAppPath = AppDomain.CurrentDomain.BaseDirectory +"HHUpdateApp\\HHUpdateApp.exe";
            
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
