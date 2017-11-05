namespace SurveillanceAnalyserX
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ConvertBtn = new System.Windows.Forms.Button();
            this.BrowseBtn = new System.Windows.Forms.Button();
            this.vFileNameTextBox = new System.Windows.Forms.TextBox();
            this.axWindowsMediaPlayer2 = new AxWMPLib.AxWindowsMediaPlayer();
            this.BlockList = new System.Windows.Forms.ListBox();
            this.AnalyseBtn = new System.Windows.Forms.Button();
            this.PersonList = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SettingBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).BeginInit();
            this.SuspendLayout();
            // 
            // ConvertBtn
            // 
            this.ConvertBtn.Enabled = false;
            this.ConvertBtn.Location = new System.Drawing.Point(656, 9);
            this.ConvertBtn.Name = "ConvertBtn";
            this.ConvertBtn.Size = new System.Drawing.Size(103, 30);
            this.ConvertBtn.TabIndex = 0;
            this.ConvertBtn.Text = "转换";
            this.ConvertBtn.UseVisualStyleBackColor = true;
            this.ConvertBtn.Click += new System.EventHandler(this.button1_ClickAsync);
            // 
            // BrowseBtn
            // 
            this.BrowseBtn.Location = new System.Drawing.Point(485, 14);
            this.BrowseBtn.Name = "BrowseBtn";
            this.BrowseBtn.Size = new System.Drawing.Size(106, 25);
            this.BrowseBtn.TabIndex = 1;
            this.BrowseBtn.Text = "选择视频文件";
            this.BrowseBtn.UseVisualStyleBackColor = true;
            this.BrowseBtn.Click += new System.EventHandler(this.button2_Click);
            // 
            // vFileNameTextBox
            // 
            this.vFileNameTextBox.Location = new System.Drawing.Point(12, 14);
            this.vFileNameTextBox.Name = "vFileNameTextBox";
            this.vFileNameTextBox.Size = new System.Drawing.Size(467, 25);
            this.vFileNameTextBox.TabIndex = 2;
            this.vFileNameTextBox.TextChanged += new System.EventHandler(this.vFileNameTextBox_TextChanged);
            // 
            // axWindowsMediaPlayer2
            // 
            this.axWindowsMediaPlayer2.Enabled = true;
            this.axWindowsMediaPlayer2.Location = new System.Drawing.Point(12, 62);
            this.axWindowsMediaPlayer2.Name = "axWindowsMediaPlayer2";
            this.axWindowsMediaPlayer2.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer2.OcxState")));
            this.axWindowsMediaPlayer2.Size = new System.Drawing.Size(645, 423);
            this.axWindowsMediaPlayer2.TabIndex = 4;
            this.axWindowsMediaPlayer2.Enter += new System.EventHandler(this.axWindowsMediaPlayer2_Enter);
            // 
            // BlockList
            // 
            this.BlockList.FormattingEnabled = true;
            this.BlockList.ItemHeight = 15;
            this.BlockList.Location = new System.Drawing.Point(776, 118);
            this.BlockList.Name = "BlockList";
            this.BlockList.Size = new System.Drawing.Size(120, 214);
            this.BlockList.TabIndex = 5;
            // 
            // AnalyseBtn
            // 
            this.AnalyseBtn.Enabled = false;
            this.AnalyseBtn.Location = new System.Drawing.Point(765, 9);
            this.AnalyseBtn.Name = "AnalyseBtn";
            this.AnalyseBtn.Size = new System.Drawing.Size(111, 28);
            this.AnalyseBtn.TabIndex = 6;
            this.AnalyseBtn.Text = "分析";
            this.AnalyseBtn.UseVisualStyleBackColor = true;
            this.AnalyseBtn.Click += new System.EventHandler(this.button3_Click);
            // 
            // PersonList
            // 
            this.PersonList.FormattingEnabled = true;
            this.PersonList.ItemHeight = 15;
            this.PersonList.Location = new System.Drawing.Point(943, 118);
            this.PersonList.Name = "PersonList";
            this.PersonList.Size = new System.Drawing.Size(262, 214);
            this.PersonList.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(773, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "图像信息变动节点";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(989, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "人脸";
            // 
            // SettingBtn
            // 
            this.SettingBtn.Location = new System.Drawing.Point(959, 502);
            this.SettingBtn.Name = "SettingBtn";
            this.SettingBtn.Size = new System.Drawing.Size(92, 39);
            this.SettingBtn.TabIndex = 10;
            this.SettingBtn.Text = "设置";
            this.SettingBtn.UseVisualStyleBackColor = true;
            this.SettingBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1282, 609);
            this.Controls.Add(this.SettingBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PersonList);
            this.Controls.Add(this.AnalyseBtn);
            this.Controls.Add(this.BlockList);
            this.Controls.Add(this.axWindowsMediaPlayer2);
            this.Controls.Add(this.vFileNameTextBox);
            this.Controls.Add(this.BrowseBtn);
            this.Controls.Add(this.ConvertBtn);
            this.Name = "Form1";
            this.Text = "SurveillanceAnalyser";
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConvertBtn;
        private System.Windows.Forms.Button BrowseBtn;
        private System.Windows.Forms.TextBox vFileNameTextBox;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer2;
        private System.Windows.Forms.ListBox BlockList;
        private System.Windows.Forms.Button AnalyseBtn;
        private System.Windows.Forms.ListBox PersonList;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button SettingBtn;
    }
}

