namespace HHUpdateApp
{
    partial class HHMessageBox
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
            this.LBTitle = new System.Windows.Forms.Label();
            this.lblContent = new System.Windows.Forms.Label();
            this.btnOk = new HHUpdateApp.HHBtn();
            this.SuspendLayout();
            // 
            // LBTitle
            // 
            this.LBTitle.AutoSize = true;
            this.LBTitle.BackColor = System.Drawing.Color.Transparent;
            this.LBTitle.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.LBTitle.ForeColor = System.Drawing.Color.DimGray;
            this.LBTitle.Location = new System.Drawing.Point(11, 13);
            this.LBTitle.Name = "LBTitle";
            this.LBTitle.Size = new System.Drawing.Size(39, 19);
            this.LBTitle.TabIndex = 22;
            this.LBTitle.Text = "提示";
            // 
            // lblContent
            // 
            this.lblContent.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lblContent.ForeColor = System.Drawing.Color.DimGray;
            this.lblContent.Location = new System.Drawing.Point(81, 67);
            this.lblContent.Name = "lblContent";
            this.lblContent.Size = new System.Drawing.Size(358, 159);
            this.lblContent.TabIndex = 24;
            this.lblContent.Text = "当前版本已经是最新版本";
            this.lblContent.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.EnterImage = null;
            this.btnOk.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnOk.IsColorChange = true;
            this.btnOk.IsFontChange = false;
            this.btnOk.Location = new System.Drawing.Point(193, 257);
            this.btnOk.MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.MoveFontColor = System.Drawing.Color.White;
            this.btnOk.Name = "btnOk";
            this.btnOk.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnOk.NormalFontColor = System.Drawing.Color.White;
            this.btnOk.Size = new System.Drawing.Size(126, 35);
            this.btnOk.TabIndex = 27;
            this.btnOk.Text = "确定";
            this.btnOk.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // HHMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(525, 331);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblContent);
            this.Controls.Add(this.LBTitle);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "HHMessageBox";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MainForm";
            this.TopMost = true;
            this.Shown += new System.EventHandler(this.HHMessageBox_Shown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PNTop_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.Label lblContent;
        private HHBtn btnOk;
    }
}