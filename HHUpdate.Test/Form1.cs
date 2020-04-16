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
            string path = AppDomain.CurrentDomain.BaseDirectory + "HHUpdateApp.exe";
            
            if (File.Exists(path))
            {
                ProcessStartInfo processStartInfo = new ProcessStartInfo()
                {
                    FileName = "HHUpdateApp.exe",
                    Arguments = "HHUpdate.Test 0"
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
