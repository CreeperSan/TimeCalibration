namespace TimeCalibration
{
    partial class MainWindow
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textLocalTimeTitle = new System.Windows.Forms.Label();
            this.textLocalTime = new System.Windows.Forms.Label();
            this.textNetworkTimeTitle = new System.Windows.Forms.Label();
            this.textNetworkTime = new System.Windows.Forms.Label();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.textVersion = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textLocalTimeTitle
            // 
            this.textLocalTimeTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textLocalTimeTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLocalTimeTitle.Location = new System.Drawing.Point(12, 9);
            this.textLocalTimeTitle.Name = "textLocalTimeTitle";
            this.textLocalTimeTitle.Size = new System.Drawing.Size(330, 20);
            this.textLocalTimeTitle.TabIndex = 0;
            this.textLocalTimeTitle.Text = "本地时间";
            this.textLocalTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textLocalTime
            // 
            this.textLocalTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textLocalTime.Location = new System.Drawing.Point(12, 32);
            this.textLocalTime.Name = "textLocalTime";
            this.textLocalTime.Size = new System.Drawing.Size(330, 45);
            this.textLocalTime.TabIndex = 1;
            this.textLocalTime.Text = "正在获取";
            this.textLocalTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textNetworkTimeTitle
            // 
            this.textNetworkTimeTitle.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNetworkTimeTitle.Location = new System.Drawing.Point(12, 83);
            this.textNetworkTimeTitle.Name = "textNetworkTimeTitle";
            this.textNetworkTimeTitle.Size = new System.Drawing.Size(330, 20);
            this.textNetworkTimeTitle.TabIndex = 2;
            this.textNetworkTimeTitle.Text = "网络时间";
            this.textNetworkTimeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textNetworkTime
            // 
            this.textNetworkTime.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textNetworkTime.Location = new System.Drawing.Point(12, 106);
            this.textNetworkTime.Name = "textNetworkTime";
            this.textNetworkTime.Size = new System.Drawing.Size(330, 45);
            this.textNetworkTime.TabIndex = 3;
            this.textNetworkTime.Text = "正在获取";
            this.textNetworkTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Font = new System.Drawing.Font("微软雅黑", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonConfirm.Location = new System.Drawing.Point(12, 175);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(330, 70);
            this.buttonConfirm.TabIndex = 4;
            this.buttonConfirm.Text = "设置时间";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // textVersion
            // 
            this.textVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textVersion.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.textVersion.Location = new System.Drawing.Point(10, 262);
            this.textVersion.Name = "textVersion";
            this.textVersion.Size = new System.Drawing.Size(330, 20);
            this.textVersion.TabIndex = 5;
            this.textVersion.Text = "版本 v1.0";
            this.textVersion.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 279);
            this.Controls.Add(this.textVersion);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.textNetworkTime);
            this.Controls.Add(this.textNetworkTimeTitle);
            this.Controls.Add(this.textLocalTime);
            this.Controls.Add(this.textLocalTimeTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "时间校准工具";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label textLocalTimeTitle;
        private System.Windows.Forms.Label textLocalTime;
        private System.Windows.Forms.Label textNetworkTimeTitle;
        private System.Windows.Forms.Label textNetworkTime;
        private System.Windows.Forms.Button buttonConfirm;
        private System.Windows.Forms.Label textVersion;
    }
}

