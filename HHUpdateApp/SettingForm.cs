using HHUpdateApp.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HHUpdateApp
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            InitializeComponent();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtLaunchAppName.Text))
            {
                HHMessageBox.Show("请填写正确的应用程序名称", "提示");
                return;
            }
            if (string.IsNullOrEmpty(txtServerUpdateUrl.Text))
            {
                HHMessageBox.Show("请填写正确的升级信息路径", "提示");
                return;
            }
            Program.LaunchAppName = txtLaunchAppName.Text;
            Program.ServerUpdateUrl = txtServerUpdateUrl.Text;

            this.DialogResult = DialogResult.OK;
            return;
        }

        private void SettingForm_Load(object sender, EventArgs e)
        {
            txtLaunchAppName.Text = Settings.Default.LaunchAppName;
            txtServerUpdateUrl.Text = Settings.Default.ServerUpdateUrl;
        }
    }
}
