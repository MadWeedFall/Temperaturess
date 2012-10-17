namespace WDN
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.readBtn = new System.Windows.Forms.Button();
            this.weiboBtn = new System.Windows.Forms.Button();
            this.statTxt = new System.Windows.Forms.Label();
            this.arduinoSerial = new System.IO.Ports.SerialPort(this.components);
            this.WeiboUpTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // readBtn
            // 
            this.readBtn.Location = new System.Drawing.Point(77, 252);
            this.readBtn.Name = "readBtn";
            this.readBtn.Size = new System.Drawing.Size(132, 36);
            this.readBtn.TabIndex = 0;
            this.readBtn.Text = "开始读取串口数据";
            this.readBtn.UseVisualStyleBackColor = true;
            this.readBtn.Click += new System.EventHandler(this.readBtn_Click);
            // 
            // weiboBtn
            // 
            this.weiboBtn.Location = new System.Drawing.Point(294, 252);
            this.weiboBtn.Name = "weiboBtn";
            this.weiboBtn.Size = new System.Drawing.Size(140, 36);
            this.weiboBtn.TabIndex = 1;
            this.weiboBtn.Text = "将数据发送至微薄";
            this.weiboBtn.UseVisualStyleBackColor = true;
            this.weiboBtn.Click += new System.EventHandler(this.weiboBtn_Click);
            // 
            // statTxt
            // 
            this.statTxt.AutoSize = true;
            this.statTxt.Location = new System.Drawing.Point(106, 60);
            this.statTxt.Name = "statTxt";
            this.statTxt.Size = new System.Drawing.Size(77, 12);
            this.statTxt.TabIndex = 2;
            this.statTxt.Text = "系统状态信息";
            // 
            // arduinoSerial
            // 
            this.arduinoSerial.PortName = "COM4";
            this.arduinoSerial.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.arduinoSerial_DataReceived);
            // 
            // WeiboUpTimer
            // 
            this.WeiboUpTimer.Interval = 600000;
            this.WeiboUpTimer.Tick += new System.EventHandler(this.WeiboUpTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(638, 325);
            this.Controls.Add(this.statTxt);
            this.Controls.Add(this.weiboBtn);
            this.Controls.Add(this.readBtn);
            this.Name = "Form1";
            this.Text = "交大1119温度娘v0.1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button readBtn;
        private System.Windows.Forms.Button weiboBtn;
        private System.Windows.Forms.Label statTxt;
        private System.IO.Ports.SerialPort arduinoSerial;
        private System.Windows.Forms.Timer WeiboUpTimer;
    }
}

