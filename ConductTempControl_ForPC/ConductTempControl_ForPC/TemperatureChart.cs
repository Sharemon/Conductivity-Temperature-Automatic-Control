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
    public partial class TemperatureChart : Form
    {
        #region Members
        Timer tempShowTimer;
        Timer ctrlTimer;
        DrawChart mDrawChart;
        #endregion

        public TemperatureChart()
        {
            InitializeComponent();
            mDrawChart = new DrawChart(TempPic.Height, TempPic.Width, 11, 7);

            // Init Temperature Show Timer
            tempShowTimer = new Timer();
            tempShowTimer.Tick += TempShowTimer_Tick;

            // Init Control Time Timer
            ctrlTimer = new Timer();
            ctrlTimer.Tick += CtrlTimer_Tick;
        }

        private void TemperatureChart_Load(object sender, EventArgs e)
        {
            ctrlTimer.Interval = 1000;
            ctrlTimer.Enabled = true;

            // Stagger two timers
            System.Threading.Thread.Sleep(500);

            tempShowTimer.Interval = 1000;
            tempShowTimer.Enabled = true;
        }

        /// <summary>
        /// Update temperature to chart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TempShowTimer_Tick(object sender, EventArgs e)
        {
            TempPic.Image = mDrawChart.Draw();
        }

        /// <summary>
        /// Update control time
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CtrlTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan ts = DateTime.Now - GlobalVars.ctrlStartTime;
            LblCtrlTimeShow.Text = String.Format("{0}:{1}:{2}", ts.Hours, ts.Minutes, ts.Seconds);

            float fluc = 0;
            if (GlobalVars.GetFluc(GlobalVars.tempFlucLen_10min, out fluc))
            {
                LblFlucShow.Text = fluc.ToString("0.000");
            }
            else
            {
                LblFlucShow.Text = "N/A";
            }
        }

        private void BtnClear_Click(object sender, EventArgs e)
        {
            GlobalVars.temperatures.Clear();
        }

        private void TemperatureChart_FormClosing(object sender, FormClosingEventArgs e)
        {
            tempShowTimer.Dispose();
            ctrlTimer.Dispose();
            mDrawChart.Dispose();
        }
    }
}
