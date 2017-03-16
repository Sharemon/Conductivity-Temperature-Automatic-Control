//Undone: form show of every menu
//Undone: Test the auto control functino
//Undone: .ini file read/wire & initial configuration
//Undone: write temperature and power into data file
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
            GlbVars.uartCom = new UartProtocol("detect");
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
            // Disable auto run button to avoid run repeatedly
            this.BntRunAuto.Enabled = false;

            // Disable manual menu to avoid 
            this.MenuManual.Enabled = false;

            // Init auto control
            float initTemp = float.Parse(TxtInitTemp.Text);
            float intervalTemp = float.Parse(TxtIntervalTemp.Text);
            autoStep = new StepControl(initTemp, intervalTemp, intervalTemp > 0);

            // Init check timer
            System.Timers.Timer checkTimer = GlbVars.tempReadTimer;
            checkTimer.Interval = GlbVars.readTempInterval;
            checkTimer.Elapsed += CheckTimer_Tick;

            // Init blink timer
            System.Timers.Timer blinkTimer = new System.Timers.Timer();
            blinkTimer.Interval = 500;
            blinkTimer.Elapsed += BlinkTimer_Elapsed;

            // Record the start time
            GlbVars.ctrlStartTime = DateTime.Now;
            // Run
            blinkTimer.Enabled = true;
            autoStep.ThisTurn();
            checkTimer.Enabled = true;
        }

        /// <summary>
        /// Timer to blink PicFlucShow to show the system is working
        /// </summary>
        private void BlinkTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            this.PicFlucShow.Visible = !this.PicFlucShow.Visible;
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
                this.LblTempShowAuto.Text = temperature.ToString("0.000");

                // Update fluc flag 
                if (steady)
                    this.PicFlucShow.BackColor = Color.Green;
                else
                    this.PicFlucShow.BackColor = Color.Red;
            }));

            // If steady, inform conductivity measurement equipment
            if (steady)
            {
                autoStep.InformCondMeas();
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
                    GlbVars.tempReadTimer.Enabled = false;
                    MessageBox.Show("所有测试结束");

                    this.Invoke(new EventHandler(delegate
                    {
                        this.BntRunAuto.Enabled = true;
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
