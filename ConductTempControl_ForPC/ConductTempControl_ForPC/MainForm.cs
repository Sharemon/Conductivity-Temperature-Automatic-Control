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
        UartProtocol uart;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 
            //GlobalVars.InitGlobalVars();
            uart = new UartProtocol("COM1");
            char a = 'a';
            this.Text = a.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GlobalVars.ctrlStartTime = DateTime.Now;

            Timer t1 = new Timer();
            t1.Interval = GlobalVars.readTempInterval;
            t1.Tick += timer1_tick;
            t1.Enabled = true;
            //GlobalVars.AddTemperature(0.0f);

            bool formExist = false;
            foreach(Form fm in Application.OpenForms)
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

        private void timer1_tick(object sender, EventArgs e)
        {
            Random rn = new Random();
            GlobalVars.AddTemperature((float)rn.NextDouble());
        }

        private void test(GlobalVars.Parameters_t arg1)
        {

        }
    }
}
