// Undone: 1.update button implement
// Undone: 2.Temperature and Operation save and load class
// Undone: 3.Textbox handler (if input is not number) 

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
        private TextBox[] TxtParas = new TextBox[8];

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
                if (i == (int)GlbVars.Paras_t.FlucThr ||
                    i == (int)GlbVars.Paras_t.TempThr)
                {
                    paraValues[i] = GlbVars.paraValues[i];
                    continue;
                }

                GlbVars.uartCom.ReadData((UartProtocol.Commands_t)i, out paraValues[i]);
            }

            return paraValues;
        }
        #endregion

        private void ParameterSet_Load(object sender, EventArgs e)
        {
            if (GlbVars.firstReadPara)
            {
                GlbVars.paraValues = readParas();
            }
            
            for(int i=0; i<GlbVars.paraValues.Length; i++)
            {
                TxtParas[i].Text = GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]);
            }
        }

        private void BntRead_Click(object sender, EventArgs e)
        {
            GlbVars.paraValues = readParas();

            for (int i = 0; i < GlbVars.paraValues.Length; i++)
            {
                TxtParas[i].Text = GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]);
            }
        }

        private void BntUpdate_Click(object sender, EventArgs e)
        {

        }
    }
}
