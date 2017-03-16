namespace ConductTempControl_ForPC
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.MenuSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuComSet = new System.Windows.Forms.ToolStripMenuItem();
            this.参数设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuManual = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuChart = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuOperation = new System.Windows.Forms.ToolStripMenuItem();
            this.LblTempShowAuto = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.PicFlucShow = new System.Windows.Forms.PictureBox();
            this.TxtInitTemp = new System.Windows.Forms.TextBox();
            this.TxtIntervalTemp = new System.Windows.Forms.TextBox();
            this.TxtTimes = new System.Windows.Forms.TextBox();
            this.BntRunAuto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StaCom = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicFlucShow)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuSetting,
            this.显示ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(336, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // MenuSetting
            // 
            this.MenuSetting.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuComSet,
            this.参数设置ToolStripMenuItem});
            this.MenuSetting.Name = "MenuSetting";
            this.MenuSetting.Size = new System.Drawing.Size(44, 21);
            this.MenuSetting.Text = "设置";
            // 
            // MenuComSet
            // 
            this.MenuComSet.Name = "MenuComSet";
            this.MenuComSet.Size = new System.Drawing.Size(124, 22);
            this.MenuComSet.Text = "串口设置";
            this.MenuComSet.Click += new System.EventHandler(this.MenuComSet_Click);
            // 
            // 参数设置ToolStripMenuItem
            // 
            this.参数设置ToolStripMenuItem.Name = "参数设置ToolStripMenuItem";
            this.参数设置ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.参数设置ToolStripMenuItem.Text = "参数设置";
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MenuManual,
            this.MenuChart,
            this.MenuOperation});
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.显示ToolStripMenuItem.Text = "显示";
            // 
            // MenuManual
            // 
            this.MenuManual.Name = "MenuManual";
            this.MenuManual.Size = new System.Drawing.Size(124, 22);
            this.MenuManual.Text = "手动操作";
            // 
            // MenuChart
            // 
            this.MenuChart.Name = "MenuChart";
            this.MenuChart.Size = new System.Drawing.Size(124, 22);
            this.MenuChart.Text = "曲线图";
            // 
            // MenuOperation
            // 
            this.MenuOperation.Name = "MenuOperation";
            this.MenuOperation.Size = new System.Drawing.Size(124, 22);
            this.MenuOperation.Text = "操作日志";
            // 
            // LblTempShowAuto
            // 
            this.LblTempShowAuto.AutoSize = true;
            this.LblTempShowAuto.Dock = System.Windows.Forms.DockStyle.Right;
            this.LblTempShowAuto.Font = new System.Drawing.Font("Microsoft YaHei", 42F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.LblTempShowAuto.ForeColor = System.Drawing.Color.Red;
            this.LblTempShowAuto.Location = new System.Drawing.Point(59, 17);
            this.LblTempShowAuto.Name = "LblTempShowAuto";
            this.LblTempShowAuto.Size = new System.Drawing.Size(250, 75);
            this.LblTempShowAuto.TabIndex = 0;
            this.LblTempShowAuto.Text = "0.000 ℃";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.PicFlucShow);
            this.groupBox1.Controls.Add(this.LblTempShowAuto);
            this.groupBox1.Location = new System.Drawing.Point(12, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 100);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "当前温度显示";
            // 
            // PicFlucShow
            // 
            this.PicFlucShow.BackColor = System.Drawing.Color.Red;
            this.PicFlucShow.Location = new System.Drawing.Point(6, 34);
            this.PicFlucShow.Name = "PicFlucShow";
            this.PicFlucShow.Size = new System.Drawing.Size(40, 40);
            this.PicFlucShow.TabIndex = 5;
            this.PicFlucShow.TabStop = false;
            this.PicFlucShow.Paint += new System.Windows.Forms.PaintEventHandler(this.FlucShow_Paint);
            // 
            // TxtInitTemp
            // 
            this.TxtInitTemp.Location = new System.Drawing.Point(38, 186);
            this.TxtInitTemp.Name = "TxtInitTemp";
            this.TxtInitTemp.Size = new System.Drawing.Size(100, 21);
            this.TxtInitTemp.TabIndex = 2;
            this.TxtInitTemp.Text = "0";
            this.TxtInitTemp.TextChanged += new System.EventHandler(this.TxtInitTemp_TextChanged);
            // 
            // TxtIntervalTemp
            // 
            this.TxtIntervalTemp.Location = new System.Drawing.Point(176, 186);
            this.TxtIntervalTemp.Name = "TxtIntervalTemp";
            this.TxtIntervalTemp.Size = new System.Drawing.Size(100, 21);
            this.TxtIntervalTemp.TabIndex = 2;
            this.TxtIntervalTemp.Text = "0";
            this.TxtIntervalTemp.TextChanged += new System.EventHandler(this.TxtIntervalTemp_TextChanged);
            // 
            // TxtTimes
            // 
            this.TxtTimes.Location = new System.Drawing.Point(38, 237);
            this.TxtTimes.Name = "TxtTimes";
            this.TxtTimes.Size = new System.Drawing.Size(100, 21);
            this.TxtTimes.TabIndex = 2;
            this.TxtTimes.Text = "8";
            this.TxtTimes.TextChanged += new System.EventHandler(this.TxtTimes_TextChanged);
            // 
            // BntRunAuto
            // 
            this.BntRunAuto.Location = new System.Drawing.Point(177, 235);
            this.BntRunAuto.Name = "BntRunAuto";
            this.BntRunAuto.Size = new System.Drawing.Size(99, 23);
            this.BntRunAuto.TabIndex = 3;
            this.BntRunAuto.Text = "运行";
            this.BntRunAuto.UseVisualStyleBackColor = true;
            this.BntRunAuto.Click += new System.EventHandler(this.BntRunAuto_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "初始温度设定值：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(174, 171);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "每次温度调整值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 222);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "温度调整次数：";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StaCom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 279);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(336, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StaCom
            // 
            this.StaCom.Name = "StaCom";
            this.StaCom.Size = new System.Drawing.Size(0, 17);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(336, 301);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BntRunAuto);
            this.Controls.Add(this.TxtTimes);
            this.Controls.Add(this.TxtIntervalTemp);
            this.Controls.Add(this.TxtInitTemp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "自动控温系统";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PicFlucShow)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem MenuSetting;
        private System.Windows.Forms.ToolStripMenuItem MenuComSet;
        private System.Windows.Forms.ToolStripMenuItem 参数设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MenuManual;
        private System.Windows.Forms.ToolStripMenuItem MenuChart;
        private System.Windows.Forms.ToolStripMenuItem MenuOperation;
        private System.Windows.Forms.Label LblTempShowAuto;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox TxtInitTemp;
        private System.Windows.Forms.TextBox TxtIntervalTemp;
        private System.Windows.Forms.TextBox TxtTimes;
        private System.Windows.Forms.Button BntRunAuto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox PicFlucShow;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StaCom;
    }
}

