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
    public partial class ComSet : Form
    {
        public ComSet()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Refresh port names and update the combox
        /// </summary>
        private void RefreshPort()
        {
            string[] portNames = System.IO.Ports.SerialPort.GetPortNames();
            CmbPorts.Items.Clear();
            CmbPorts.Items.AddRange(portNames);
            if(CmbPorts.Items.Count != 0)
            {
                CmbPorts.SelectedIndex = 0;
            }
        }

        private void ComSet_Load(object sender, EventArgs e)
        {
            RefreshPort();
        }

        private void BntRefresh_Click(object sender, EventArgs e)
        {
            RefreshPort();
        }

        private void BntOK_Click(object sender, EventArgs e)
        {
            if(CmbPorts.SelectedItem != null && (string)CmbPorts.SelectedItem != "")
            {
                GlbVars.portName = (string)CmbPorts.SelectedItem;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("所选不是有效串口，请重新选择");
                RefreshPort();
            }
        }

        private void ComSet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
