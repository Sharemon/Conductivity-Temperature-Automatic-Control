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
    public partial class ParameterSet : Form
    {
        private TextBox[] TxtParas = new TextBox[GlbVars.paraValues.Length];

        public ParameterSet()
        {
            InitializeComponent();

            // Put all textbox control into TxtParas array
            // It will be easy to manage and control these controls
            TxtParas[0] = TxtTempSet;
            TxtParas[1] = TxtTempCorrect;
            TxtParas[2] = TxtLeadAdjust;
            TxtParas[3] = TxtFuzzy;
            TxtParas[4] = TxtRatio;
            TxtParas[5] = TxtIntegral;
            TxtParas[6] = TxtPower;
            TxtParas[7] = TxtFlucThr;
            TxtParas[8] = TxtTempThr;
        }

        #region Non-Control Methods
        /// <summary>
        /// Read parameters from MCU
        /// </summary>
        /// <returns>Array of parameters</returns>
        private float[] readParas()
        {
            float[] paraValues = new float[GlbVars.paraValues.Length];

            // Loop to read parameters from MCU
            for (int i = 0; i < paraValues.Length; i++)
            {
                // FlucThr & TempThr cannot be read from MCU
                // They will be read from file and save to memory at the beginning of Main Form
                if (i == (int)GlbVars.Paras_t.FlucThr || i == (int)GlbVars.Paras_t.TempThr)
                {
                    paraValues[i] = GlbVars.paraValues[i];
                    continue;
                }

                GlbVars.uartCom.ReadData((UartProtocol.Commands_t)i, out paraValues[i]);
            }

            return paraValues;
        }
        #endregion

        #region Control Methods
        private void ParameterSet_Load(object sender, EventArgs e)
        {
            // Todo: Think of if it's needed to close timer
            // Disable read temperature timer to avoid serial port conflict
            //GlbVars.tempReadTimer.Enabled = false;

            // Load parameters and update UI;
            if (GlbVars.firstReadPara)
            {
                GlbVars.paraValues = readParas();
                GlbVars.firstReadPara = false;
            }
            
            for(int i=0; i<GlbVars.paraValues.Length; i++)
            {
                TxtParas[i].Text = GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]);
            }
        }

        private void BntRead_Click(object sender, EventArgs e)
        {
            // Enter non-timer region to avoid uart conflict
            GlbVars.tempReadTimer.Enabled = false;

            GlbVars.paraValues = readParas();

            for (int i = 0; i < GlbVars.paraValues.Length; i++)
            {
                TxtParas[i].Text = GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]);
            }

            // Exit non-timer region
            GlbVars.tempReadTimer.Enabled = true;
        }

        private void BntUpdate_Click(object sender, EventArgs e)
        {
            // Enter non-timer region to avoid uart conflict
            GlbVars.tempReadTimer.Enabled = false;

            bool noError = true;

            // Write old parameters to file
            Data2File.Operation2File(true);

            // Loop to check and update paramters
            for (int i=0; i<GlbVars.paraValues.Length; i++)
            {
                float newValue = float.Parse(TxtParas[i].Text);

                // Update only when current value is different from previous one
                // Use **abs(x-y) > margin** to compare two inequal float vars 
                if (Math.Abs(newValue - GlbVars.paraValues[i]) >　10e-5)   
                {
                    // If update fluctuation and temperature threshold, just update the global variables
                    if (i == (int)GlbVars.Paras_t.FlucThr || i == (int)GlbVars.Paras_t.TempThr)
                    {
                        GlbVars.paraValues[i] = newValue;
                        Data2File.AddParaChanged(i);
                        continue;
                    }

                    // For other parameters, send cmd to MCU to update 
                    if (GlbVars.uartCom.SendData((UartProtocol.Commands_t)i, newValue) != UartProtocol.Errors_t.NoError)
                    {
                        noError = false;
                    }
                    else
                    {
                        GlbVars.paraValues[i] = newValue;
                        Data2File.AddParaChanged(i);
                    }
                }
            }

            if (noError)
                MessageBox.Show("参数更新成功！");
            else
                MessageBox.Show("参数更新失败！");

            // Write new paramters to file
            Data2File.Operation2File(false);

            // Exit non-timer region
            GlbVars.tempReadTimer.Enabled = true;
        }
        
        /// <summary>
        /// To make sure all input value is valid
        /// Use one delegate for all textboxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TxtPara_TextChanged(object sender, EventArgs e)
        {
            TextBox txt = sender as TextBox;
            float noUse = 0;

            if(txt.Text != "-" && txt.Text != "+" /*&& txt.Text != "."*/ && txt.Text != "" &&
                !float.TryParse(txt.Text, out noUse))
            {
                txt.Text = txt.Text.Remove(txt.Text.Length - 1, 1);
                txt.Select(txt.Text.Length, 0);
            }
        }

        private void ParameterSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            ;
        }
        #endregion
    }
}
