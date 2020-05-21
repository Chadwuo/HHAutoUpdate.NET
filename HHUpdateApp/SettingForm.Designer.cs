namespace HHUpdateApp
{
    partial class SettingForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnOk = new HHUpdateApp.HHBtn();
            this.btnCancel = new HHUpdateApp.HHBtn();
            this.LBTitle = new System.Windows.Forms.Label();
            this.lblLaunchDirectory = new System.Windows.Forms.Label();
            this.txtLaunchAppName = new System.Windows.Forms.TextBox();
            this.txtServerUpdateUrl = new System.Windows.Forms.TextBox();
            this.lblServerUpdateUrl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.EnterImage = null;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOk.IsColorChange = true;
            this.btnOk.IsFontChange = false;
            this.btnOk.Location = new System.Drawing.Point(288, 274);
            this.btnOk.MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.MoveFontColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.NormalFontColor = System.Drawing.Color.White;
            this.btnOk.Size = new System.Drawing.Size(125, 35);
            this.btnOk.TabIndex = 28;
            this.btnOk.Text = "确定";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.EnterImage = null;
            this.btnCancel.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnCancel.ForeColor = System.Drawing.Color.Black;
            this.btnCancel.IsColorChange = true;
            this.btnCancel.IsFontChange = false;
            this.btnCancel.Location = new System.Drawing.Point(116, 274);
            this.btnCancel.MoveColor = System.Drawing.Color.White;
            this.btnCancel.MoveFontColor = System.Drawing.Color.Black;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.NormalColor = System.Drawing.Color.White;
            this.btnCancel.NormalFontColor = System.Drawing.Color.Black;
            this.btnCancel.Size = new System.Drawing.Size(125, 35);
            this.btnCancel.TabIndex = 29;
            this.btnCancel.Text = "取消";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LBTitle
            // 
            this.LBTitle.AutoSize = true;
            this.LBTitle.BackColor = System.Drawing.Color.Transparent;
            this.LBTitle.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.LBTitle.ForeColor = System.Drawing.Color.DimGray;
            this.LBTitle.Location = new System.Drawing.Point(12, 9);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(39, 19);
            this.LBTitle.TabIndex = 25;
            this.LBTitle.Text = "设置";
            // 
            // lblLaunchDirectory
            // 
            this.lblLaunchDirectory.BackColor = System.Drawing.Color.Transparent;
            this.lblLaunchDirectory.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblLaunchDirectory.ForeColor = System.Drawing.Color.DimGray;
            this.lblLaunchDirectory.Location = new System.Drawing.Point(64, 99);
            this.lblLaunchDirectory.Name = "lblLaunchDirectory";
            this.lblLaunchDirectory.Size = new System.Drawing.Size(118, 19);
            this.lblLaunchDirectory.TabIndex = 30;
            this.lblLaunchDirectory.Text = "用户软件名称";
            this.lblLaunchDirectory.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLaunchAppName
            // 
            this.txtLaunchAppName.Location = new System.Drawing.Point(229, 97);
            this.txtLaunchAppName.Name = "txtLaunchAppName";
            this.txtLaunchAppName.Size = new System.Drawing.Size(232, 21);
            this.txtLaunchAppName.TabIndex = 31;
            // 
            // txtServerUpdateUrl
            // 
            this.txtServerUpdateUrl.Location = new System.Drawing.Point(229, 147);
            this.txtServerUpdateUrl.Name = "txtServerUpdateUrl";
            this.txtServerUpdateUrl.Size = new System.Drawing.Size(232, 21);
            this.txtServerUpdateUrl.TabIndex = 33;
            // 
            // lblServerUpdateUrl
            // 
            this.lblServerUpdateUrl.BackColor = System.Drawing.Color.Transparent;
            this.lblServerUpdateUrl.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblServerUpdateUrl.ForeColor = System.Drawing.Color.DimGray;
            this.lblServerUpdateUrl.Location = new System.Drawing.Point(64, 149);
            this.lblServerUpdateUrl.Name = "lblServerUpdateUrl";
            this.lblServerUpdateUrl.Size = new System.Drawing.Size(118, 19);
            this.lblServerUpdateUrl.TabIndex = 32;
            this.lblServerUpdateUrl.Text = "升级信息路径";
            this.lblServerUpdateUrl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(525, 330);
            this.Controls.Add(this.txtServerUpdateUrl);
            this.Controls.Add(this.lblServerUpdateUrl);
            this.Controls.Add(this.txtLaunchAppName);
            this.Controls.Add(this.lblLaunchDirectory);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.LBTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SettingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "设置";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBTitle;
        private HHBtn btnOk;
        private HHBtn btnCancel;
        private System.Windows.Forms.Label lblLaunchDirectory;
        private System.Windows.Forms.TextBox txtLaunchAppName;
        private System.Windows.Forms.TextBox txtServerUpdateUrl;
        private System.Windows.Forms.Label lblServerUpdateUrl;
    }
}