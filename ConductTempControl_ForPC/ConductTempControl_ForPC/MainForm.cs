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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            uart.SendCommand(UartProtocol.CommandNames_t.TempSet, 0.01f);
        }

        private void test(GlobalVars.ParameterNames_t arg1)
        {

        }
    }
}
