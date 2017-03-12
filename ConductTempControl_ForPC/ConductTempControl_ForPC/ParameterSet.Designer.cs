namespace ConductTempControl_ForPC
{
    partial class ParameterSet
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.TxtTempSet = new System.Windows.Forms.TextBox();
            this.TxtTempCorrect = new System.Windows.Forms.TextBox();
            this.TxtLeadAdjust = new System.Windows.Forms.TextBox();
            this.TxtFuzzy = new System.Windows.Forms.TextBox();
            this.TxtRatio = new System.Windows.Forms.TextBox();
            this.TxtIntegral = new System.Windows.Forms.TextBox();
            this.TxtPower = new System.Windows.Forms.TextBox();
            this.TxtFlucThr = new System.Windows.Forms.TextBox();
            this.BntRead = new System.Windows.Forms.Button();
            this.BntUpdate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "温度设定值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "温度调整值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 113);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 1;
            this.label3.Text = "超前调整值：";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "模糊系数：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(42, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "比例系数：";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 233);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 1;
            this.label6.Text = "积分系数：";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 273);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 1;
            this.label7.Text = "功率系数：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 313);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 12);
            this.label8.TabIndex = 1;
            this.label8.Text = "波动度阈值：";
            // 
            // TxtTempSet
            // 
            this.TxtTempSet.Location = new System.Drawing.Point(130, 29);
            this.TxtTempSet.Name = "TxtTempSet";
            this.TxtTempSet.Size = new System.Drawing.Size(100, 21);
            this.TxtTempSet.TabIndex = 2;
            // 
            // TxtTempCorrect
            // 
            this.TxtTempCorrect.Location = new System.Drawing.Point(130, 69);
            this.TxtTempCorrect.Name = "TxtTempCorrect";
            this.TxtTempCorrect.Size = new System.Drawing.Size(100, 21);
            this.TxtTempCorrect.TabIndex = 2;
            // 
            // TxtLeadAdjust
            // 
            this.TxtLeadAdjust.Location = new System.Drawing.Point(130, 109);
            this.TxtLeadAdjust.Name = "TxtLeadAdjust";
            this.TxtLeadAdjust.Size = new System.Drawing.Size(100, 21);
            this.TxtLeadAdjust.TabIndex = 2;
            // 
            // TxtFuzzy
            // 
            this.TxtFuzzy.Location = new System.Drawing.Point(130, 149);
            this.TxtFuzzy.Name = "TxtFuzzy";
            this.TxtFuzzy.Size = new System.Drawing.Size(100, 21);
            this.TxtFuzzy.TabIndex = 2;
            // 
            // TxtRatio
            // 
            this.TxtRatio.Location = new System.Drawing.Point(130, 189);
            this.TxtRatio.Name = "TxtRatio";
            this.TxtRatio.Size = new System.Drawing.Size(100, 21);
            this.TxtRatio.TabIndex = 2;
            // 
            // TxtIntegral
            // 
            this.TxtIntegral.Location = new System.Drawing.Point(130, 229);
            this.TxtIntegral.Name = "TxtIntegral";
            this.TxtIntegral.Size = new System.Drawing.Size(100, 21);
            this.TxtIntegral.TabIndex = 2;
            // 
            // TxtPower
            // 
            this.TxtPower.Location = new System.Drawing.Point(130, 269);
            this.TxtPower.Name = "TxtPower";
            this.TxtPower.Size = new System.Drawing.Size(100, 21);
            this.TxtPower.TabIndex = 2;
            // 
            // TxtFlucThr
            // 
            this.TxtFlucThr.Location = new System.Drawing.Point(130, 309);
            this.TxtFlucThr.Name = "TxtFlucThr";
            this.TxtFlucThr.Size = new System.Drawing.Size(100, 21);
            this.TxtFlucThr.TabIndex = 2;
            // 
            // BntRead
            // 
            this.BntRead.Location = new System.Drawing.Point(32, 362);
            this.BntRead.Name = "BntRead";
            this.BntRead.Size = new System.Drawing.Size(88, 43);
            this.BntRead.TabIndex = 3;
            this.BntRead.Text = "查询参数";
            this.BntRead.UseVisualStyleBackColor = true;
            this.BntRead.Click += new System.EventHandler(this.BntRead_Click);
            // 
            // BntUpdate
            // 
            this.BntUpdate.Location = new System.Drawing.Point(149, 362);
            this.BntUpdate.Name = "BntUpdate";
            this.BntUpdate.Size = new System.Drawing.Size(86, 43);
            this.BntUpdate.TabIndex = 3;
            this.BntUpdate.Text = "更新参数";
            this.BntUpdate.UseVisualStyleBackColor = true;
            this.BntUpdate.Click += new System.EventHandler(this.BntUpdate_Click);
            // 
            // ParameterSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(275, 432);
            this.Controls.Add(this.BntUpdate);
            this.Controls.Add(this.BntRead);
            this.Controls.Add(this.TxtFlucThr);
            this.Controls.Add(this.TxtPower);
            this.Controls.Add(this.TxtIntegral);
            this.Controls.Add(this.TxtRatio);
            this.Controls.Add(this.TxtFuzzy);
            this.Controls.Add(this.TxtLeadAdjust);
            this.Controls.Add(this.TxtTempCorrect);
            this.Controls.Add(this.TxtTempSet);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ParameterSet";
            this.Text = "ParameterSet";
            this.Load += new System.EventHandler(this.ParameterSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox TxtTempSet;
        private System.Windows.Forms.TextBox TxtTempCorrect;
        private System.Windows.Forms.TextBox TxtLeadAdjust;
        private System.Windows.Forms.TextBox TxtFuzzy;
        private System.Windows.Forms.TextBox TxtRatio;
        private System.Windows.Forms.TextBox TxtIntegral;
        private System.Windows.Forms.TextBox TxtPower;
        private System.Windows.Forms.TextBox TxtFlucThr;
        private System.Windows.Forms.Button BntRead;
        private System.Windows.Forms.Button BntUpdate;
    }
}