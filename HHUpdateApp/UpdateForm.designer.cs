namespace HHUpdateApp
{
    partial class UpdateForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UpdateForm));
            this.updateBar = new System.Windows.Forms.ProgressBar();
            this.LBTitle = new System.Windows.Forms.Label();
            this.lblMsg = new System.Windows.Forms.Label();
            this.btnWelcome = new HHUpdateApp.HHBtn();
            this.lblAd = new System.Windows.Forms.Label();
            this.BGWorkerUpdate = new System.ComponentModel.BackgroundWorker();
            this.SuspendLayout();
            // 
            // updateBar
            // 
            this.updateBar.BackColor = System.Drawing.Color.Lime;
            this.updateBar.Location = new System.Drawing.Point(41, 291);
            this.updateBar.Name = "updateBar";
            this.updateBar.Size = new System.Drawing.Size(509, 28);
            this.updateBar.TabIndex = 24;
            // 
            // LBTitle
            // 
            this.LBTitle.AutoSize = true;
            this.LBTitle.BackColor = System.Drawing.Color.Transparent;
            this.LBTitle.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.LBTitle.ForeColor = System.Drawing.Color.DimGray;
            this.LBTitle.Location = new System.Drawing.Point(12, 9);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(54, 19);
            this.LBTitle.TabIndex = 25;
            this.LBTitle.Text = "升级";
            // 
            // lblMsg
            // 
            this.lblMsg.BackColor = System.Drawing.Color.Transparent;
            this.lblMsg.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.lblMsg.ForeColor = System.Drawing.Color.DimGray;
            this.lblMsg.Location = new System.Drawing.Point(94, 247);
            this.lblMsg.Name = "lblMsg";
            this.lblMsg.Size = new System.Drawing.Size(407, 19);
            this.lblMsg.TabIndex = 26;
            this.lblMsg.Text = "正在升级...";
            this.lblMsg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnWelcome
            // 
            this.btnWelcome.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnWelcome.EnterImage = null;
            this.btnWelcome.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnWelcome.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnWelcome.IsColorChange = true;
            this.btnWelcome.IsFontChange = false;
            this.btnWelcome.Location = new System.Drawing.Point(219, 346);
            this.btnWelcome.MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnWelcome.MoveFontColor = System.Drawing.Color.White;
            this.btnWelcome.Name = "btnWelcome";
            this.btnWelcome.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnWelcome.NormalFontColor = System.Drawing.Color.White;
            this.btnWelcome.Size = new System.Drawing.Size(141, 45);
            this.btnWelcome.TabIndex = 29;
            this.btnWelcome.Text = "欢迎使用";
            this.btnWelcome.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnWelcome.Click += new System.EventHandler(this.btnWelcome_Click);
            // 
            // lblAd
            // 
            this.lblAd.BackColor = System.Drawing.Color.Transparent;
            this.lblAd.Font = new System.Drawing.Font("微软雅黑", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblAd.ForeColor = System.Drawing.Color.DimGray;
            this.lblAd.Location = new System.Drawing.Point(94, 71);
            this.lblAd.Name = "lblAd";
            this.lblAd.Size = new System.Drawing.Size(407, 115);
            this.lblAd.TabIndex = 30;
            this.lblAd.Text = "广告位招租";
            this.lblAd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAd.Visible = false;
            // 
            // BGWorkerUpdate
            // 
            this.BGWorkerUpdate.WorkerReportsProgress = true;
            this.BGWorkerUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.BGWorkerUpdate_DoWork);
            this.BGWorkerUpdate.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.BGWorkerUpdate_ProgressChanged);
            this.BGWorkerUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.BGWorkerUpdate_RunWorkerCompleted);
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 428);
            this.Controls.Add(this.lblAd);
            this.Controls.Add(this.btnWelcome);
            this.Controls.Add(this.lblMsg);
            this.Controls.Add(this.LBTitle);
            this.Controls.Add(this.updateBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "升级";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.Shown += new System.EventHandler(this.UpdateForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar updateBar;
        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.Label lblMsg;
        private HHBtn btnWelcome;
        private System.Windows.Forms.Label lblAd;
        private System.ComponentModel.BackgroundWorker BGWorkerUpdate;
    }
}