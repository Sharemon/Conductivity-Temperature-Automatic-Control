//Undone: write temperature and power into data file
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConductTempControl_ForPC
{
    /// <summary>
    /// Main Form
    /// </summary>
    public partial class MainForm : Form
    {
        private StepControl autoStep;
        private bool runOrStop = true;      // Indicate the function of RUN button
        private System.Timers.Timer blinkTimer = new System.Timers.Timer();
        private const string configFilePath = @"./config.ini";
        private const string configSec = "CONFIG";

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // Check and create folders for data saving
            Data2File.CheckDirs();

            #region Load configuration .ini file
            // If there is no config file, create one and write default value to it
            if (!File.Exists(configFilePath))
            {
                IniReadWrite.INIWriteValue(configFilePath, configSec, "COM", "COM1");
                IniReadWrite.INIWriteValue(configFilePath, configSec, "TempThr", "0.01");
                IniReadWrite.INIWriteValue(configFilePath, configSec, "FlucThr", "0.01");
                IniReadWrite.INIWriteValue(configFilePath, configSec, "ReadInterval", "1000");
            }

            // Get COM port and set it
            GlbVars.uartCom = 
                new UartProtocol(IniReadWrite.INIGetStringValue(configFilePath, configSec, "COM", "COM1"));
            this.StaCom.Text = GlbVars.portName;

            // Get temperature and fluctuation threshold
            GlbVars.paraValues[(int)GlbVars.Paras_t.TempThr] =
                float.Parse(IniReadWrite.INIGetStringValue(configFilePath, configSec, "TempThr", "0.01"));

            GlbVars.paraValues[(int)GlbVars.Paras_t.FlucThr] =
                float.Parse(IniReadWrite.INIGetStringValue(configFilePath, configSec, "FlucThr", "0.01"));

            // Get read timer.interval
            GlbVars.readTempInterval =
                int.Parse(IniReadWrite.INIGetStringValue(configFilePath, configSec, "ReadInterval", "1000"));
            #endregion

            // Init check timer, use readTempTimer to replace
            GlbVars.tempReadTimer.Interval = GlbVars.readTempInterval;
            GlbVars.tempReadTimer.Elapsed += CheckTimer_Tick;

            // Init blink timer
            blinkTimer.Interval = 1000;
            blinkTimer.Elapsed += BlinkTimer_Elapsed;
        }

      

        /// <summary>
        /// Redraw picture box to circle shape
        /// </summary>
        private void FlucShow_Paint(object sender, PaintEventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath buttonPath =
                new System.Drawing.Drawing2D.GraphicsPath();

            System.Drawing.Rectangle newRectangle = PicFlucShow.ClientRectangle;

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
            PicFlucShow.Region = new System.Drawing.Region(buttonPath);
        }

        private void BntRunAuto_Click(object sender, EventArgs e)
        {
            // runOrStop, true for run, false for stop
            if (runOrStop)
            {
                // Change the button to Stop function
                this.BntRunAuto.Text = "终止";

                // Disable manual menu to avoid 
                this.MenuManual.Enabled = false;
                this.MenuParaSet.Enabled = false;
                this.MenuComSet.Enabled = false;

                // Init auto control
                float initTemp = float.Parse(TxtInitTemp.Text);
                float intervalTemp = float.Parse(TxtIntervalTemp.Text);
                autoStep = new StepControl(initTemp, intervalTemp, intervalTemp > 0);

                // Record the start time
                GlbVars.ctrlStartTime = DateTime.Now;
                // Run
                blinkTimer.Enabled = true;
                autoStep.ThisTurn();
                GlbVars.tempReadTimer.Enabled = true;
            }
            else
            {
                // Change the button to Stop function
                this.BntRunAuto.Text = "运行";

                // Enable all menus
                this.MenuManual.Enabled = true;
                this.MenuParaSet.Enabled = true;
                this.MenuComSet.Enabled = true;

                // Stop timer
                GlbVars.tempReadTimer.Enabled = false;
                blinkTimer.Enabled = false;

                // Fix flucShow to read and show
                PicFlucShow.BackColor = Color.Red;
                PicFlucShow.Visible = true;

                // Finish the temperature data file
                Data2File.FinishTempFile();
            }

            runOrStop = !runOrStop;
        }

        /// <summary>
        /// Timer to blink PicFlucShow to show the system is working
        /// </summary>
        private void BlinkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.Invoke(new EventHandler(delegate
            {
                this.PicFlucShow.Visible = !this.PicFlucShow.Visible;
            }));
        }

        /// <summary>
        /// Timer to check if this turn of run is over
        /// </summary>
        private void CheckTimer_Tick(object sender, System.Timers.ElapsedEventArgs e)
        {
            float temperature = 0;
            bool steady = autoStep.CheckFluc(out temperature);

            // Update UI
            this.Invoke(new EventHandler(delegate
            {
                // Update temperature show
                this.LblTempShowAuto.Text = temperature.ToString("0.000 ℃");
                // Save temperature data
                Data2File.Temp2File(temperature);

                // Update fluc flag 
                if (steady)
                    this.PicFlucShow.BackColor = Color.Green;
                else
                    this.PicFlucShow.BackColor = Color.Red;
            }));

            // If steady, inform conductivity measurement equipment
            if (steady)
            {
                // Create a critical region
                GlbVars.tempReadTimer.Enabled = false;
                autoStep.InformCondMeas();
                GlbVars.tempReadTimer.Enabled = true;

                int remainTimes = int.Parse(TxtTimes.Text);

                // Remain times dcrease 1
                remainTimes--;
                this.Invoke(new EventHandler(delegate
                {
                    this.TxtTimes.Text = remainTimes.ToString();
                }));

                // If there no remain times, finish all test
                if (remainTimes == 0)
                {
                    // Game over
                    GlbVars.tempReadTimer.Enabled = false;
                    MessageBox.Show("所有测试结束");

                    // Finish the temperature data file
                    Data2File.FinishTempFile();

                    // Click Run button to change the status to STOP status
                    this.Invoke(new EventHandler(delegate
                    {
                        this.BntRunAuto.PerformClick();
                    }));
                }
                // If there is, start next turn of run
                else
                {
                    autoStep.NextTurn();
                }
            }
        }

        #region Txt Parse
        private void TxtInitTemp_TextChanged(object sender, EventArgs e)
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

        private void TxtIntervalTemp_TextChanged(object sender, EventArgs e)
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

        private void TxtTimes_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            int noUse = 0;

            if (txt.Text != "+" && txt.Text != "" &&
                !int.TryParse(txt.Text, out noUse) && (int.Parse(txt.Text) > 0))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1);
                txt.Select(txt.Text.Length, 0);
            }
        }
        #endregion

        private void MenuComSet_Click(object sender, EventArgs e)
        {
            // Comset form will be topmost, do not need to check
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

        private void MenuParaSet_Click(object sender, EventArgs e)
        {
            // Check if there is hidden form with same name
            // If so, bring it to the front. If not, show a new one
            bool formExist = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "ParameterSet")
                {
                    // Avoid form being minimized
                    fm.WindowState = FormWindowState.Normal;

                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                Form fm = new ParameterSet();
                fm.Show();
            }
        }

        private void MenuManual_Click(object sender, EventArgs e)
        {
            // Comset form will be topmost, do not need to check
            Form fm = new ManualControl();
            fm.ShowDialog();
        }

        private void MenuChart_Click(object sender, EventArgs e)
        {
            // Check if there is hidden form with same name
            // If so, bring it to the front. If not, show a new one
            bool formExist = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "TemperatureChart")
                {
                    // Avoid form being minimized
                    fm.WindowState = FormWindowState.Normal;

                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                Form fm = new TemperatureChart();
                fm.Show();
            }
        }

        private void MenuOperation_Click(object sender, EventArgs e)
        {
            // Check if there is hidden form with same name
            // If so, bring it to the front. If not, show a new one
            bool formExist = false;
            foreach (Form fm in Application.OpenForms)
            {
                if (fm.Name == "LogShow")
                {
                    // Avoid form being minimized
                    fm.WindowState = FormWindowState.Normal;

                    fm.BringToFront();
                    formExist = true;
                }
            }
            if (!formExist)
            {
                Form fm = new LogShow();
                fm.Show();
            }
        }
    }
}
