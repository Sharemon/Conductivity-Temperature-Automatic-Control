using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace AutoController
{
    public partial class MainForm : Form
    {
        #region private members
        private SerialPort sp = new SerialPort();
        private float flucThr = 0.05f;
        private List<float> flucList = new List<float>();
        private float tempInit;
        private float tempCurrent;
        private float tempInterval;
        private int   tempTimes;
        private float tempLast;
        private System.Timers.Timer timerRead = new System.Timers.Timer();
        private System.Timers.Timer timerBlink = new System.Timers.Timer();
        private int blinkCnt = 0;

        #endregion

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // try and get all com port name
            for (int i = 1; i <= 16; i++)
            {
                try
                {
                    sp.PortName = "COM" + i;
                    sp.Open();
                    cmbPortName.Items.Add("COM" + i);
                    sp.Close();
                }
                catch (Exception)
                {
                    ;
                }
            }

            // other configuration
            cmbPortName.SelectedIndex = 0;
            sp.BaudRate = 115200;
            sp.ReadTimeout = 2000;

            timerRead.Interval = 2000;
            timerRead.Elapsed += TimerRead_Elapsed;
            timerBlink.Interval = 500;
            timerBlink.Elapsed += TimerBlink_Elapsed;

            lblStatus.Text = "初始化完成.";
        }

        private void TimerBlink_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            switch(blinkCnt)
            {
                case 0:
                    lblStatus.Text = "电导率测量中.";
                    break;
                case 1:
                    lblStatus.Text = "电导率测量中..";
                    break;
                case 2:
                    lblStatus.Text = "电导率测量中...";
                    break;
                default:
                    break;
            }

            blinkCnt++;
            if (blinkCnt == 3)
                blinkCnt = 0;
        }

        private void TimerRead_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            if(CheckFluc())
            {
                NextRun();
            }
        }

        /// <summary>
        /// Execute when fluctuation is less than threshold
        /// </summary>
        private void NextRun()
        {
            timerRead.Stop();

            // wait for conductivity measurement
            timerBlink.Start();
            System.Threading.Thread.Sleep(10 * 1000);
            timerBlink.Stop();

            // next turn
            if (tempCurrent != tempLast)    // current run is not the last run
            {
                tempCurrent += tempInterval;
                sp.Write(string.Format("TMSET {0:f3}!@", tempCurrent));
                lblStatus.Text = "设置温度： " + tempCurrent.ToString("0.000");
                timerRead.Start();
            }
            else       // current run is the last run
            {
                sp.Close();
                this.Invoke(new EventHandler(delegate
                {
                    bntStart.Enabled = true;
                    lblStatus.Text = "测量完成";
                }));
            }
        }

        /// <summary>
        /// Check if fluctuation is in range 
        /// </summary>
        /// <returns></returns>
        private bool CheckFluc()
        {
            sp.Write("FLUCT?@");
            string flucStr = sp.ReadTo("!");

            flucStr = flucStr.Remove(0, 6).Trim();
            lblStatus.Text = "当前波动度： " + flucStr;

            if (flucStr.ToUpper() == "NAN")
                return false;

            if (float.Parse(flucStr) > flucThr)
                return false;
            else
                return true;
        }

        private void bntStart_Click(object sender, EventArgs e)
        {
            // disable button
            bntStart.Enabled = false;

            // init com port name
            sp.PortName = (string)cmbPortName.SelectedItem;
            sp.Open();

            // init all temperature control relative variables
            tempInit = float.Parse(txtInitTemp.Text);
            tempInterval = float.Parse(txtIntervalTemp.Text);
            tempTimes = int.Parse(txtTimesTemp.Text);
            tempLast = tempInit + (tempTimes - 1) * tempInterval;

            tempCurrent = tempInit;
            sp.Write(string.Format("TMSET {0:f3}!@", tempCurrent));
            lblStatus.Text = "设置温度： " + tempCurrent.ToString("0.000");

            timerRead.Start();
        }
    }
}
