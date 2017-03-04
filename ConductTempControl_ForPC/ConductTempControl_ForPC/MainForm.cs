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
            UartProtocol.Errors_t error = uart.SendData(UartProtocol.Commands_t.TempSet, 0.01f);
            if ( error != UartProtocol.Errors_t.NoError)
            {
                string err = Enum.GetName(typeof(UartProtocol.Errors_t), error);
                Exception ex = new Exception(err);
                throw ex;
            }
            System.Threading.Thread.Sleep(1000);
            float value = -1;
            uart.ReadData(UartProtocol.Commands_t.PowerShow, out value);
            this.Text = value.ToString();
        }

        private void test(GlobalVars.Parameters_t arg1)
        {

        }
    }
}
