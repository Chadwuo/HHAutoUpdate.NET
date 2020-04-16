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
            this.updateBar = new System.Windows.Forms.ProgressBar();
            this.LBTitle = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnExit = new HHUpdateApp.HHBtn();
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
            this.LBTitle.Text = "新版本";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(94, 247);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(407, 19);
            this.label1.TabIndex = 26;
            this.label1.Text = "正在升级...";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnExit.EnterImage = null;
            this.btnExit.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.btnExit.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.btnExit.IsColorChange = true;
            this.btnExit.IsFontChange = false;
            this.btnExit.Location = new System.Drawing.Point(219, 346);
            this.btnExit.MoveColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnExit.MoveFontColor = System.Drawing.Color.White;
            this.btnExit.Name = "btnExit";
            this.btnExit.NormalColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(173)))), ((int)(((byte)(25)))));
            this.btnExit.NormalFontColor = System.Drawing.Color.White;
            this.btnExit.Size = new System.Drawing.Size(141, 45);
            this.btnExit.TabIndex = 29;
            this.btnExit.Text = "确定";
            this.btnExit.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UpdateForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(588, 428);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LBTitle);
            this.Controls.Add(this.updateBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UpdateForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "UpdateForm";
            this.Load += new System.EventHandler(this.UpdateForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar updateBar;
        private System.Windows.Forms.Label LBTitle;
        private System.Windows.Forms.Label label1;
        private HHBtn btnExit;
    }
}