namespace ConductTempControl_ForPC
{
    partial class ComSet
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
            this.CmbPorts = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.BntRefresh = new System.Windows.Forms.Button();
            this.BntOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CmbPorts
            // 
            this.CmbPorts.FormattingEnabled = true;
            this.CmbPorts.Location = new System.Drawing.Point(28, 49);
            this.CmbPorts.Name = "CmbPorts";
            this.CmbPorts.Size = new System.Drawing.Size(121, 20);
            this.CmbPorts.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "请选择串口号：";
            // 
            // BntRefresh
            // 
            this.BntRefresh.Location = new System.Drawing.Point(28, 83);
            this.BntRefresh.Name = "BntRefresh";
            this.BntRefresh.Size = new System.Drawing.Size(56, 23);
            this.BntRefresh.TabIndex = 2;
            this.BntRefresh.Text = "刷新";
            this.BntRefresh.UseVisualStyleBackColor = true;
            this.BntRefresh.Click += new System.EventHandler(this.BntRefresh_Click);
            // 
            // BntOK
            // 
            this.BntOK.Location = new System.Drawing.Point(100, 83);
            this.BntOK.Name = "BntOK";
            this.BntOK.Size = new System.Drawing.Size(49, 23);
            this.BntOK.TabIndex = 2;
            this.BntOK.Text = "确定";
            this.BntOK.UseVisualStyleBackColor = true;
            this.BntOK.Click += new System.EventHandler(this.BntOK_Click);
            // 
            // ComSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(181, 118);
            this.Controls.Add(this.BntOK);
            this.Controls.Add(this.BntRefresh);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CmbPorts);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComSet";
            this.Text = "ComSet";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComSet_FormClosing);
            this.Load += new System.EventHandler(this.ComSet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CmbPorts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button BntRefresh;
        private System.Windows.Forms.Button BntOK;
    }
}