namespace AutoController
{
    partial class MainForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPortName = new System.Windows.Forms.ComboBox();
            this.bntStart = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtInitTemp = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtIntervalTemp = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtTimesTemp = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "串口号:";
            // 
            // cmbPortName
            // 
            this.cmbPortName.FormattingEnabled = true;
            this.cmbPortName.Location = new System.Drawing.Point(90, 23);
            this.cmbPortName.Name = "cmbPortName";
            this.cmbPortName.Size = new System.Drawing.Size(100, 20);
            this.cmbPortName.TabIndex = 1;
            // 
            // bntStart
            // 
            this.bntStart.Location = new System.Drawing.Point(30, 207);
            this.bntStart.Name = "bntStart";
            this.bntStart.Size = new System.Drawing.Size(160, 31);
            this.bntStart.TabIndex = 2;
            this.bntStart.Text = "启动";
            this.bntStart.UseVisualStyleBackColor = true;
            this.bntStart.Click += new System.EventHandler(this.bntStart_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(28, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "起始温度:";
            // 
            // txtInitTemp
            // 
            this.txtInitTemp.Location = new System.Drawing.Point(90, 68);
            this.txtInitTemp.Name = "txtInitTemp";
            this.txtInitTemp.Size = new System.Drawing.Size(100, 21);
            this.txtInitTemp.TabIndex = 3;
            this.txtInitTemp.Text = "5";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(28, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "温度间隔:";
            // 
            // txtIntervalTemp
            // 
            this.txtIntervalTemp.Location = new System.Drawing.Point(90, 114);
            this.txtIntervalTemp.Name = "txtIntervalTemp";
            this.txtIntervalTemp.Size = new System.Drawing.Size(100, 21);
            this.txtIntervalTemp.TabIndex = 3;
            this.txtIntervalTemp.Text = "5";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 164);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "控温次数:";
            // 
            // txtTimesTemp
            // 
            this.txtTimesTemp.Location = new System.Drawing.Point(90, 160);
            this.txtTimesTemp.Name = "txtTimesTemp";
            this.txtTimesTemp.Size = new System.Drawing.Size(100, 21);
            this.txtTimesTemp.TabIndex = 3;
            this.txtTimesTemp.Text = "8";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 261);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(223, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(53, 17);
            this.lblStatus.Text = "初始化...";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(223, 283);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtTimesTemp);
            this.Controls.Add(this.txtIntervalTemp);
            this.Controls.Add(this.txtInitTemp);
            this.Controls.Add(this.bntStart);
            this.Controls.Add(this.cmbPortName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPortName;
        private System.Windows.Forms.Button bntStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtInitTemp;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtIntervalTemp;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtTimesTemp;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
    }
}

