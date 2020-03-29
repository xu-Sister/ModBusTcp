namespace ModBusTcp
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
            this.IPBox = new System.Windows.Forms.TextBox();
            this.IpLabel = new System.Windows.Forms.Label();
            this.portLabel = new System.Windows.Forms.Label();
            this.portBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.startBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.addBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.LengthBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.orderBox = new System.Windows.Forms.TextBox();
            this.connectBtn = new System.Windows.Forms.Button();
            this.OutPutText = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // IPBox
            // 
            this.IPBox.Location = new System.Drawing.Point(88, 22);
            this.IPBox.Multiline = true;
            this.IPBox.Name = "IPBox";
            this.IPBox.Size = new System.Drawing.Size(130, 25);
            this.IPBox.TabIndex = 0;
            // 
            // IpLabel
            // 
            this.IpLabel.AutoSize = true;
            this.IpLabel.Location = new System.Drawing.Point(12, 27);
            this.IpLabel.Name = "IpLabel";
            this.IpLabel.Size = new System.Drawing.Size(68, 15);
            this.IpLabel.TabIndex = 1;
            this.IpLabel.Text = "IP地址：";
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Location = new System.Drawing.Point(226, 27);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(67, 15);
            this.portLabel.TabIndex = 3;
            this.portLabel.Text = "端口号：";
            // 
            // portBox
            // 
            this.portBox.Location = new System.Drawing.Point(301, 22);
            this.portBox.Multiline = true;
            this.portBox.Name = "portBox";
            this.portBox.Size = new System.Drawing.Size(59, 25);
            this.portBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "起始位：";
            // 
            // startBox
            // 
            this.startBox.Location = new System.Drawing.Point(95, 57);
            this.startBox.Multiline = true;
            this.startBox.Name = "startBox";
            this.startBox.Size = new System.Drawing.Size(59, 25);
            this.startBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(368, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 15);
            this.label2.TabIndex = 5;
            this.label2.Text = "Modbus地址：";
            // 
            // addBox
            // 
            this.addBox.Location = new System.Drawing.Point(476, 22);
            this.addBox.Multiline = true;
            this.addBox.Name = "addBox";
            this.addBox.Size = new System.Drawing.Size(59, 25);
            this.addBox.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(170, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "长度：";
            // 
            // LengthBox
            // 
            this.LengthBox.Location = new System.Drawing.Point(238, 57);
            this.LengthBox.Multiline = true;
            this.LengthBox.Name = "LengthBox";
            this.LengthBox.Size = new System.Drawing.Size(59, 25);
            this.LengthBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(313, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 11;
            this.label4.Text = "命令位：";
            // 
            // orderBox
            // 
            this.orderBox.Location = new System.Drawing.Point(396, 57);
            this.orderBox.Multiline = true;
            this.orderBox.Name = "orderBox";
            this.orderBox.Size = new System.Drawing.Size(59, 25);
            this.orderBox.TabIndex = 10;
            // 
            // connectBtn
            // 
            this.connectBtn.Location = new System.Drawing.Point(471, 58);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(75, 38);
            this.connectBtn.TabIndex = 13;
            this.connectBtn.Text = "链接";
            this.connectBtn.UseVisualStyleBackColor = true;
            // 
            // OutPutText
            // 
            this.OutPutText.Location = new System.Drawing.Point(13, 103);
            this.OutPutText.Margin = new System.Windows.Forms.Padding(4);
            this.OutPutText.Multiline = true;
            this.OutPutText.Name = "OutPutText";
            this.OutPutText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.OutPutText.Size = new System.Drawing.Size(533, 329);
            this.OutPutText.TabIndex = 14;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(554, 447);
            this.Controls.Add(this.OutPutText);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.orderBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.LengthBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.addBox);
            this.Controls.Add(this.portLabel);
            this.Controls.Add(this.portBox);
            this.Controls.Add(this.IpLabel);
            this.Controls.Add(this.IPBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox IPBox;
        private System.Windows.Forms.Label IpLabel;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox portBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox startBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox addBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox LengthBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox orderBox;
        private System.Windows.Forms.Button connectBtn;
        public System.Windows.Forms.TextBox OutPutText;
    }
}

