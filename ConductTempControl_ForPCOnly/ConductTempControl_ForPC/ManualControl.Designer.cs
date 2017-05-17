namespace ConductTempControl_ForPC
{
    partial class ManualControl
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblTempShow = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BlinkBlink = new System.Windows.Forms.Label();
            this.BntRun = new System.Windows.Forms.Button();
            this.BntPlus5 = new System.Windows.Forms.Button();
            this.BntMinus5 = new System.Windows.Forms.Button();
            this.BntChart = new System.Windows.Forms.Button();
            this.LblPowerShow = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblTempShow);
            this.groupBox1.Controls.Add(this.BlinkBlink);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(236, 89);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前温度显示";
            // 
            // LblTempShow
            // 
            this.LblTempShow.BackColor = System.Drawing.SystemColors.Control;
            this.LblTempShow.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.LblTempShow.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTempShow.ForeColor = System.Drawing.Color.Red;
            this.LblTempShow.Location = new System.Drawing.Point(6, 19);
            this.LblTempShow.Name = "LblTempShow";
            this.LblTempShow.Size = new System.Drawing.Size(167, 64);
            this.LblTempShow.TabIndex = 6;
            this.LblTempShow.TabStop = false;
            this.LblTempShow.Text = "0.000";
            this.LblTempShow.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 155);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(84, 21);
            this.textBox1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 135);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "温度设定值：";
            // 
            // BlinkBlink
            // 
            this.BlinkBlink.AutoSize = true;
            this.BlinkBlink.BackColor = System.Drawing.Color.Transparent;
            this.BlinkBlink.Font = new System.Drawing.Font("Microsoft YaHei", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BlinkBlink.ForeColor = System.Drawing.Color.Red;
            this.BlinkBlink.Location = new System.Drawing.Point(169, 19);
            this.BlinkBlink.Name = "BlinkBlink";
            this.BlinkBlink.Size = new System.Drawing.Size(75, 62);
            this.BlinkBlink.TabIndex = 5;
            this.BlinkBlink.Text = "℃";
            // 
            // BntRun
            // 
            this.BntRun.Location = new System.Drawing.Point(14, 196);
            this.BntRun.Name = "BntRun";
            this.BntRun.Size = new System.Drawing.Size(232, 25);
            this.BntRun.TabIndex = 5;
            this.BntRun.Text = "运行";
            this.BntRun.UseVisualStyleBackColor = true;
            this.BntRun.Click += new System.EventHandler(this.BntRun_Click);
            // 
            // BntPlus5
            // 
            this.BntPlus5.Font = new System.Drawing.Font("Microsoft YaHei", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BntPlus5.Location = new System.Drawing.Point(103, 153);
            this.BntPlus5.Name = "BntPlus5";
            this.BntPlus5.Size = new System.Drawing.Size(25, 23);
            this.BntPlus5.TabIndex = 6;
            this.BntPlus5.Text = "+5";
            this.BntPlus5.UseVisualStyleBackColor = true;
            // 
            // BntMinus5
            // 
            this.BntMinus5.Font = new System.Drawing.Font("Microsoft YaHei", 5.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BntMinus5.Location = new System.Drawing.Point(134, 153);
            this.BntMinus5.Name = "BntMinus5";
            this.BntMinus5.Size = new System.Drawing.Size(24, 23);
            this.BntMinus5.TabIndex = 6;
            this.BntMinus5.Text = "-5";
            this.BntMinus5.UseVisualStyleBackColor = true;
            // 
            // BntChart
            // 
            this.BntChart.Location = new System.Drawing.Point(173, 153);
            this.BntChart.Name = "BntChart";
            this.BntChart.Size = new System.Drawing.Size(75, 23);
            this.BntChart.TabIndex = 7;
            this.BntChart.Text = "曲线图";
            this.BntChart.UseVisualStyleBackColor = true;
            this.BntChart.Click += new System.EventHandler(this.BntChart_Click);
            // 
            // LblPowerShow
            // 
            this.LblPowerShow.AutoSize = true;
            this.LblPowerShow.Font = new System.Drawing.Font("Microsoft YaHei", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblPowerShow.ForeColor = System.Drawing.Color.Green;
            this.LblPowerShow.Location = new System.Drawing.Point(200, 104);
            this.LblPowerShow.Name = "LblPowerShow";
            this.LblPowerShow.Size = new System.Drawing.Size(47, 21);
            this.LblPowerShow.TabIndex = 8;
            this.LblPowerShow.Text = "00 %";
            // 
            // ManualControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(258, 240);
            this.Controls.Add(this.LblPowerShow);
            this.Controls.Add(this.BntChart);
            this.Controls.Add(this.BntMinus5);
            this.Controls.Add(this.BntPlus5);
            this.Controls.Add(this.BntRun);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.Name = "ManualControl";
            this.Text = "手动控制界面";
            this.Load += new System.EventHandler(this.ManualControl_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox LblTempShow;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label BlinkBlink;
        private System.Windows.Forms.Button BntRun;
        private System.Windows.Forms.Button BntPlus5;
        private System.Windows.Forms.Button BntMinus5;
        private System.Windows.Forms.Button BntChart;
        private System.Windows.Forms.Label LblPowerShow;
    }
}