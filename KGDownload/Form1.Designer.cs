﻿namespace KGDownload
{
    partial class Form1
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
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labState = new System.Windows.Forms.Label();
            this.labPercent = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPersonDownload = new System.Windows.Forms.Button();
            this.txtArtistPage = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txtUrl
            // 
            this.txtUrl.Font = new System.Drawing.Font("宋体", 12F);
            this.txtUrl.Location = new System.Drawing.Point(133, 21);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(418, 26);
            this.txtUrl.TabIndex = 0;
            // 
            // btnDownload
            // 
            this.btnDownload.Font = new System.Drawing.Font("宋体", 12F);
            this.btnDownload.Location = new System.Drawing.Point(133, 53);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(86, 29);
            this.btnDownload.TabIndex = 1;
            this.btnDownload.Text = "下载";
            this.btnDownload.UseVisualStyleBackColor = true;
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(23, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "单首歌曲地址";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(433, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "状态";
            // 
            // labState
            // 
            this.labState.AutoSize = true;
            this.labState.Font = new System.Drawing.Font("宋体", 12F);
            this.labState.Location = new System.Drawing.Point(479, 59);
            this.labState.Name = "labState";
            this.labState.Size = new System.Drawing.Size(72, 16);
            this.labState.TabIndex = 4;
            this.labState.Text = "准备就绪";
            // 
            // labPercent
            // 
            this.labPercent.AutoSize = true;
            this.labPercent.Font = new System.Drawing.Font("宋体", 12F);
            this.labPercent.Location = new System.Drawing.Point(479, 139);
            this.labPercent.Name = "labPercent";
            this.labPercent.Size = new System.Drawing.Size(40, 16);
            this.labPercent.TabIndex = 9;
            this.labPercent.Text = "100%";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(417, 139);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "完成度";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(23, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 7;
            this.label5.Text = "个人主页地址";
            // 
            // btnPersonDownload
            // 
            this.btnPersonDownload.Font = new System.Drawing.Font("宋体", 12F);
            this.btnPersonDownload.Location = new System.Drawing.Point(133, 133);
            this.btnPersonDownload.Name = "btnPersonDownload";
            this.btnPersonDownload.Size = new System.Drawing.Size(86, 29);
            this.btnPersonDownload.TabIndex = 6;
            this.btnPersonDownload.Text = "下载";
            this.btnPersonDownload.UseVisualStyleBackColor = true;
            this.btnPersonDownload.Click += new System.EventHandler(this.btnPersonDownload_Click);
            // 
            // txtArtistPage
            // 
            this.txtArtistPage.Font = new System.Drawing.Font("宋体", 12F);
            this.txtArtistPage.Location = new System.Drawing.Point(133, 101);
            this.txtArtistPage.Name = "txtArtistPage";
            this.txtArtistPage.Size = new System.Drawing.Size(418, 26);
            this.txtArtistPage.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 172);
            this.Controls.Add(this.labPercent);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnPersonDownload);
            this.Controls.Add(this.txtArtistPage);
            this.Controls.Add(this.labState);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.txtUrl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "姥姥听歌用的";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label labState;
        private System.Windows.Forms.Label labPercent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnPersonDownload;
        private System.Windows.Forms.TextBox txtArtistPage;
    }
}

