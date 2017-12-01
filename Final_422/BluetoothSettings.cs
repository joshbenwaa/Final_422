using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace Final_422
{
    /// <summary>
    /// Bluetooth Settings Class
    /// </summary>
    public partial class BluetoothSettings : Form
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public BluetoothSettings()
        {
            InitializeComponent();
            string[] Coms = SerialPort.GetPortNames();
            List<string> COMs = Coms.OfType<string>().ToList();
            COM_list.DataSource = COMs;

        }

        private void COM_list_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Updates the list of com ports
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void COM_list_Click(object sender, EventArgs e)
        {
            string[] Coms = SerialPort.GetPortNames();
            List<string> COMs = Coms.OfType<string>().ToList();
            COM_list.DataSource = COMs;
        }

        /// <summary>
        /// Event handler for clicking the connect button
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (Globals.Serial.IsOpen)
            {
                Globals.Serial.Close();
            }
            Globals.Serial.PortName = string.Concat(COM_list.SelectedItem);
            try
            {
                Globals.Serial.Open();
            }
            catch (Exception)
            {
                Program.form1Instance.OutputLabel.Text = ">> ERROR: Connection Timed Out.\n";
            }
            Program.form1Instance.connectedflag = false;
            if (Globals.Serial.IsOpen)
            {
                Program.form1Instance.connectedflag = true;
            }
            else
            {
                Program.form1Instance.connectedflag = false;
            }
            if (Program.form1Instance.connectedflag == true)
            {
                Globals.Serial.ReadTimeout = Globals.timeout * 1000;
                Program.form1Instance.BlutoothStatusLabel.Text = string.Format("Bluetooth Connection: {0}", Program.form1Instance.connectedflag);
                Program.form1Instance.BlutoothStatusLabel.ForeColor = System.Drawing.Color.FromArgb(0, 128, 0);
                Program.form1Instance.OutputLabel.Text = ">> Bluetooth Connection Made.\n";
            }
            else
            {
                Program.form1Instance.BlutoothStatusLabel.Text = string.Format("Bluetooth Connection: {0}", Program.form1Instance.connectedflag);
                Program.form1Instance.BlutoothStatusLabel.ForeColor = Color.FromArgb(255, 0, 0);
            }

            this.Close();
        }

    }
}
