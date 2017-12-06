using System;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using LiveCharts; //Core of the library
using LiveCharts.Wpf; //The WPF controls
using LiveCharts.WinForms; //the WinForm wrappers
using LiveCharts.Configurations;
using LiveCharts.Defaults;
using System.Linq;

namespace Final_422
{
    public partial class Main : Form
    {
        #region Variables
        public bool connectedflag = false;
        public ChartValues<ObservableByte> Chart_Values;
        #endregion

        #region Main

        public Main()
        {
            InitializeComponent();
            Chart_Values = new ChartValues<ObservableByte>();
            for(int j = 0; j < 200; j++)
            {
                Chart_Values.Add(new ObservableByte(0));
            }
            var mapper = Mappers.Xy<ObservableByte>()
            .X((value, index) => index) //use the index as X
            .Y((value, index) => value.Value); //use the value as Y1

            //lets save the mapper globally.
            Charting.For<ObservableByte>(mapper);

            cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                Separator = new Separator
                {
                    Step = 10
                }
            });

            cartesianChart1.Series.Add(new LineSeries
            {
                Values = Chart_Values
            });
            cartesianChart1.AnimationsSpeed = TimeSpan.FromMilliseconds(.1);
            cartesianChart1.AxisX[0].MinValue = 0;
            cartesianChart1.AxisX[0].MaxValue = 200;
            cartesianChart1.AxisY.Add(new Axis
            {
                Separator = new Separator
                {
                    Step = 10
                }
            });
            cartesianChart1.AxisY[0].MinValue = 0;
            cartesianChart1.AxisY[0].MaxValue = 255;

        }

        #endregion

        #region Bluetooth Event Handlers

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Globals.Serial.Close();
            connectedflag = false;
            BlutoothStatusLabel.Text = string.Format("Bluetooth Connection: {0}", connectedflag);
            BlutoothStatusLabel.ForeColor = System.Drawing.Color.FromArgb(255, 0, 0);
        }

        private void bluetoothSettingsToolStripMenuItem_Click(object sender, EventArgs e)
        {

            BluetoothSettings frm = new BluetoothSettings();
            frm.Show();
        }

        #endregion

        #region Button Event Handlers

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region Helper Functions
        /// <summary>
        /// Prints the byte array to the serial port
        /// </summary>
        /// <param name="bytes">the byte array to print</param>
        public void PrintByteArray(byte[] bytes)
        {
            var sb = new StringBuilder("new byte[] { ");
            foreach (var b in bytes)
            {
                sb.Append(b + ", ");
            }
            sb.Append("}");
            Console.WriteLine(sb.ToString());
        }

        byte[] CreateValueArray(string Values)
        {
            string tempValue;
            byte[] tempInt;
            List<byte> temp = new List<byte>();
            int OldComma = 0;
            Values = Values.Replace(" ", ""); //Remove spaces
            Values = Values.Replace("\r\n", ""); //Remove new line and return
            if (Values[Values.Length - 1] != ',')
            {
                Values += ',';
            }
            for (int i = 0; i < Values.Length; i++)
            {
                if (Values[i] == ',')
                {
                    tempValue = Values.Substring(OldComma, i - OldComma);
                    tempInt = BitConverter.GetBytes(Int16.Parse(tempValue));
                    temp.Add(tempInt[0]);
                    temp.Add(tempInt[1]);
                    OldComma = i + 1;
                }
            }
            return temp.ToArray();
        }
        #endregion

        #region Sending Data

        private bool Aknowledged()
        {
            byte flag = 0;
            while (flag < 2)
            {
                try
                {
                    if ((byte)Globals.Serial.ReadByte() == 0x7E)
                    {
                        flag++;
                    }
                    else
                    {
                        flag = 0;
                    }
                }
                catch (TimeoutException)
                {

                    return false;
                }
            }
            return true;

        }

        private bool SendRun_Stop(byte flag)
        {
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x01;
            TempFreq.Data = new List<byte> { flag };
            TempFreq.CreateHDLC();
            try
            {
                Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            }
            catch (Exception)
            {
                return false;
            }
            return Aknowledged();
        }

        private bool Send_Horizontal(byte hor)
        {
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x03;
            TempFreq.Data = new List<byte> { hor };
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool Send_Single()
        {
            List<byte> TempData = new List<byte> { };
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x02;
            TempFreq.Data = TempData;
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool Send_Trigger(byte trigger, byte Rising_Falling)
        {
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x04;
            TempFreq.Data = new List<byte>() { trigger, Rising_Falling};
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool Send_RequestData()
        {
            List<byte> TempData = new List<byte> { };
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x05;
            if(radioButton_falling.Checked)
            {
                TempFreq.cmd = 0x06;
            }
            TempFreq.Data = TempData;
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        #endregion

        #region BacnkgroundWorker1

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Globals.Serial.ReadTimeout = 1000;
            byte FailedCounter = 0;
            HDLC_Rx DataRx = new HDLC_Rx();
            List<byte> Buffer = new List<byte>();
            HDLC_Rx.DPA_RX_STATE state = new HDLC_Rx.DPA_RX_STATE();
            //System.Threading.Thread.Sleep(1);

            while (backgroundWorker1.CancellationPending == false)
            {
                DataRx = new HDLC_Rx();
                state = new HDLC_Rx.DPA_RX_STATE();
                Globals.Serial.DiscardInBuffer();
                while (!Send_RequestData())
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        Append_Output(">> Sending Request For Data Failed\n");
                        return;
                    }
                }

                #region Parse through Data
                
                while (state == HDLC_Rx.DPA_RX_STATE.DPA_RX_NOERR)
                {
                    try
                    {
                        state = DataRx.DPA_RX_Parse((byte)Globals.Serial.ReadByte());
                    }
                    catch (Exception excep)
                    {
                        Replace_Output(">> trig'd?\n");
                        break;
                    }
                }
                switch (state)
                {
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_OK:
                        //Was a success, add code here
                        Replace_Output(">> trig'd\n");
                        Plot_Series(DataRx.Data);
                        break;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_FE:
                        Append_Output(">> An error in the calibration data frame.\n"); return;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_CRCERR:
                        break;
                }
            }
            #endregion
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            byte FailedCounter = 0;
            while (!SendRun_Stop(0))
            {
                FailedCounter++;
                if (FailedCounter >= 3)
                {
                    OutputLabel.Text = ">> Sending Stop Signal Failed\n";
                    return;
                }
            }
            Globals.Serial.DiscardInBuffer();
            OutputLabel.Text = ">> Stopped.\n";
            button_RunStop.BackColor = System.Drawing.Color.Red;
        }

        #endregion

        #region LiveGraph

        public void Append_Output(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Append_Output), new object[] { value });
                return;
            }
            OutputLabel.Text += value;
        }

        public void Replace_Output(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Replace_Output), new object[] { value });
                return;
            }
            OutputLabel.Text = value;
        }

        public void Plot_Series(List<byte> values)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<byte>>(Plot_Series), new object[] { values });
                return;
            }

            for(int i = 0; i < values.Count; i++)
            {
                Chart_Values[i] = new ObservableByte(values[i]);
            }
        }

        private void SetAxisLimits(int now)
        {
            cartesianChart1.AxisX[0].MaxValue = now + 1;
            cartesianChart1.AxisX[0].MinValue = now - 16;
        }

        #endregion

        private void button_RunStop_Click(object sender, EventArgs e)
        {
            Globals.Serial.ReadTimeout = 2147483647;
            if (button_RunStop.BackColor == System.Drawing.Color.LimeGreen) //If the scope is running already, stop it
            {
                if (backgroundWorker1.IsBusy)
                {
                    backgroundWorker1.CancelAsync();
                }
                button_RunStop.BackColor = System.Drawing.Color.Red;
                OutputLabel.Text = ">> Scope is stopped.\n";
            }
            else //Otherwise it needs to run
            {
                Globals.Serial.DiscardInBuffer();
                backgroundWorker1.RunWorkerAsync();
                button_RunStop.BackColor = System.Drawing.Color.LimeGreen;
            }

        }

        private void button_single_Click(object sender, EventArgs e)
        {
            byte FailedCounter = 0;
            if (button_RunStop.BackColor == System.Drawing.Color.LimeGreen) //System is continuous, must stop and prepare for single shot
            {
                button_RunStop.BackColor = System.Drawing.SystemColors.Control;
            }
            //Otherwise the system is already stopped
            button_RunStop.BackColor = System.Drawing.SystemColors.Control;
            HDLC_Rx DataRx = new HDLC_Rx();
            List<byte> Buffer = new List<byte>();
            HDLC_Rx.DPA_RX_STATE state = new HDLC_Rx.DPA_RX_STATE();
            while (backgroundWorker1.CancellationPending == false)
            {
                DataRx = new HDLC_Rx();
                state = new HDLC_Rx.DPA_RX_STATE();
                while (!Send_Single())
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        OutputLabel.Text = ">> Sending Single Shot Signal Failed\n";
                        return;
                    }
                }

                while (!Send_RequestData())
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        OutputLabel.Text = ">> Sending Request For Data Failed\n";
                        return;
                    }
                }


                while (state == HDLC_Rx.DPA_RX_STATE.DPA_RX_NOERR)
                {
                    try
                    {
                        state = DataRx.DPA_RX_Parse((byte)Globals.Serial.ReadByte());
                    }
                    catch (Exception excep)
                    {
                        Append_Output(">> Scope failed to parse data\n>>Error: " + excep.Message + "\n");
                        return;
                    }
                }
                switch (state)
                {
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_OK:
                        //Was a success, add code here
                        Plot_Series(DataRx.Data);
                        break;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_FE:
                        Append_Output(">> An error in the calibration data frame.\n"); return;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_CRCERR:
                        break;
                }
            }
        }

        private void trackBar_Horizontal_Scroll(object sender, EventArgs e)
        {
        }

        private void button_horizontal_set_Click(object sender, EventArgs e)
        {
            if (Globals.Serial.IsOpen)
            {
                //Find the position of the trackbar and send it to the scope
                byte FailedCounter = 0;
                while (!Send_Horizontal((byte)trackBar_Horizontal.Value))
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        OutputLabel.Text = ">> Sending Scaling Signal Failed\n";
                        return;
                    }
                }
                OutputLabel.Text = ">> Horizontal Scale Set to " + trackBar_Horizontal.Value.ToString() + "\n";
            }
            else //Serial Port isnt open
            {
                OutputLabel.Text = ">> Need to connect to scope in order to set the horizontal scale.\n";
            }

        }

        private void button_set_trigger_Click(object sender, EventArgs e)
        {
            Globals.Serial.ReadTimeout = -1;
            if (Globals.Serial.IsOpen)
            {
                byte Rising_Falling = 1;
                if(radioButton_falling.Checked)
                {
                    Rising_Falling = 0;
                }
                //Find the position of the trackbar and send it to the scope
                byte FailedCounter = 0;
                while (!Send_Trigger((byte)trackBar_trigger.Value, Rising_Falling))
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        OutputLabel.Text = ">> Sending Trigger Level Failed\n";
                        return;
                    }
                }
                OutputLabel.Text = ">> Trigger Set to " + trackBar_trigger.Value.ToString() + "\n";
            }
            else //Serial Port isnt open
            {
                OutputLabel.Text = ">> Need to connect to scope in order to set the trigger level.\n";
            }
        }

        private void trackBar_trigger_Scroll(object sender, EventArgs e)
        {
            label_trigger.Text = trackBar_trigger.Value.ToString();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }
    }

}
