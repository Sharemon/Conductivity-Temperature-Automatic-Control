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
    public partial class ManualControl : Form
    {
        private bool runOrStop = true;      // Indicate the function of RUN button
        private System.Timers.Timer blinkTimer = new System.Timers.Timer();

        public ManualControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Redraw picture box to circle shape
        /// </summary>
        private void PicFlucShow_Paint(object sender, PaintEventArgs e)
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

        private void ManualControl_Load(object sender, EventArgs e)
        {
            // Init check timer, use readTempTimer to replace
            GlbVars.tempReadTimer.Interval = GlbVars.readTempInterval;
            GlbVars.tempReadTimer.Elapsed += Read_Tick;

            // Init blink timer
            blinkTimer.Interval = 1000;
            blinkTimer.Elapsed += Blink_Tick;
        }

        #region Timer
        /// <summary>
        /// Blink to show system is alive
        /// </summary>
        private void Blink_Tick(object sender, EventArgs e)
        {
            this.BlinkBlink.Visible = !this.BlinkBlink.Visible;
        }

        /// <summary>
        /// Timer to read data
        /// </summary>
        private void Read_Tick(object sender, EventArgs e)
        {

        }
        #endregion

        private void BntChart_Click(object sender, EventArgs e)
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

        private void BntRun_Click(object sender, EventArgs e)
        {
            // runOrStop, true for run, false for stop
            if (runOrStop)
            {
                // Change the button to Stop function
                this.BntRun.Text = "终止";

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
                this.BntRun.Text = "运行";

                // Stop timer
                GlbVars.tempReadTimer.Enabled = false;
                blinkTimer.Enabled = false;

                // Fix Blink to visible
                BlinkBlink .Visible = true;

                // Finish the temperature data file
                Data2File.FinishTempFile();
            }

            runOrStop = !runOrStop;
        }
    }
}
