using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConductTempControl_ForPC
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        StepControl autoStep;

        public MainForm()
        {
            InitializeComponent();

            // Check and create folders for data saving
            Data2File.CheckDirs();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Todo: The first thing is to initialize uartCom.portName
            // Todo: The second thing is to read FlucThr and TempThr from .ini file
            //GlobalVars.InitGlobalVars();
            GlbVars.uartCom = new UartProtocol("com9");
            this.StaCom.Text = GlbVars.portName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //GlobalVars.AddTemperature(0.0f);

            bool formExist = false;
            foreach(Form fm in Application.OpenForms)
            {
                if (fm.Name == "ParameterSet")
                {
                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                ParameterSet fm = new ParameterSet();
                fm.Show();
            }
        }

        private void timer1_tick(object sender, EventArgs e)
        {
            float data = 0;
            GlbVars.uartCom.ReadData(UartProtocol.Commands_t.TempShow, out data);
            GlbVars.AddTemperature(data);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GlbVars.ctrlStartTime = DateTime.Now;

            System.Timers.Timer t1 = GlbVars.tempReadTimer;
            t1.Interval = GlbVars.readTempInterval;
            t1.Elapsed += timer1_tick;
            t1.Enabled = true;

            bool formExist = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "TemperatureChart")
                {
                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                TemperatureChart fm = new TemperatureChart();
                fm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool formExist = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "LogShow")
                {
                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                LogShow fm = new LogShow();
                fm.Show();
            }
        }

        /// <summary>
        /// Redraw picture box to circle shape
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FlucShow_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
                new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle newRectangle = FlucShow.ClientRectangle;

            // Decrease the size of the rectangle.
            newRectangle.Inflate(-10, -10);

            // Draw the button's border.
            e.Graphics.DrawEllipse(System.Drawing.Pens.Transparent, newRectangle);

            // Increase the size of the rectangle to include the border.
            newRectangle.Inflate(1, 1);

            // Create a circle within the new rectangle.
            buttonPath.AddEllipse(newRectangle);

            // Set the button's Region property to the newly created 
            // circle region.
            FlucShow.Region = new System.Drawing.Region(buttonPath);
        }

        private void BntRunAuto_Click(object sender, EventArgs e)
        {

        }

        #region Txt Parse
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            float noUse = 0;

            if (txt.Text != "-" && txt.Text != "+" /*&& txt.Text != "."*/ && txt.Text != "" &&
                !float.TryParse(txt.Text, out noUse))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1);
                txt.Select(txt.Text.Length, 0);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            float noUse = 0;

            if (txt.Text != "-" && txt.Text != "+" /*&& txt.Text != "."*/ && txt.Text != "" &&
                !float.TryParse(txt.Text, out noUse))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1);
                txt.Select(txt.Text.Length, 0);
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            int noUse = 0;

            if (txt.Text != "+" && txt.Text != "" &&
                !int.TryParse(txt.Text, out noUse))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1);
                txt.Select(txt.Text.Length, 0);
            }
        }
        #endregion

        private void MenuComSet_Click(object sender, EventArgs e)
        {
            Form ChooseCom = new ComSet();
            ChooseCom.ShowDialog();
            if (ChooseCom.DialogResult == DialogResult.OK)
                GlbVars.uartCom.SetPort(GlbVars.portName);
            else
            {
                MessageBox.Show("串口选择未成功，请检查连接并重启软件");
            }

            ChooseCom.Dispose();
            this.StaCom.Text = GlbVars.portName;
        }
    }
}
