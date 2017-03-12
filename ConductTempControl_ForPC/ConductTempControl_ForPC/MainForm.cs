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
            //Todo: Create dirs at the beginning of Main Form
            //GlobalVars.InitGlobalVars();
            GlbVars.uartCom = new UartProtocol("COM1");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            GlbVars.ctrlStartTime = DateTime.Now;

            Timer t1 = new Timer();
            t1.Interval = GlbVars.readTempInterval;
            t1.Tick += timer1_tick;
            t1.Enabled = true;
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
            Random rn = new Random();
            GlbVars.AddTemperature((float)rn.NextDouble());
        }

        private void test(GlbVars.Paras_t arg1)
        {

        }
    }
}
