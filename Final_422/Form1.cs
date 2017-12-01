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

namespace Final_422
{
    public partial class Main : Form
    {
        #region Variables

        public bool connectedflag = false;
        public ChartValues<MeasureModel> ChartValues1 { get; set; }
        public ChartValues<MeasureModel> ChartValues2 { get; set; }
        #endregion

        #region Main

        public Main()
        {
            InitializeComponent();
            Globals.Serial.ReadTimeout = -1;

            var mapper = Mappers.Xy<MeasureModel>()
                .X(model => model.SampleNum)   //use DateTime.Ticks as X
                .Y(model => model.Value);           //use the value property as Y

            //lets save the mapper globally.
            Charting.For<MeasureModel>(mapper);

            //the ChartValues property will store our values array
            ChartValues1 = new ChartValues<MeasureModel>();
            ChartValues2 = new ChartValues<MeasureModel>();
            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Values = ChartValues1,
                    PointGeometrySize = 9,
                    StrokeThickness = 2,
                    Fill = System.Windows.Media.Brushes.Transparent
                },
                new LineSeries
                {
                    Values = ChartValues2,
                    PointGeometrySize = 9,
                    StrokeThickness = 2,
                    Fill = System.Windows.Media.Brushes.Transparent
                }
            };
            cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                Separator = new Separator
                {
                    Step = 1
                }
            });
            cartesianChart1.AnimationsSpeed = TimeSpan.FromMilliseconds(.1);
            SetAxisLimits(0);

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

        /// <summary>
        /// Check for the acknowledgement flags
        /// </summary>
        /// <returns>True if the PIC acknowledges the command</returns>
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

        /// <summary>
        /// Send Settling Time Cycles
        /// </summary>
        /// <returns>Returns true if the PIC acknowledges the command</returns>
        private bool SendCoef(byte[] coef)
        {
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x01;
            TempFreq.Data = new List<byte>(coef);
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

        /// <summary>
        /// Sends the switching variables
        /// </summary>
        /// <returns>Returns true if the PIC acknowledges the command</returns>
        private bool SendStop()
        {
            List<byte> TempData = new List<byte> { };
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x03;
            TempFreq.Data = TempData;
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        /// <summary>
        /// Send Output Voltage Range Variable
        /// </summary>
        /// <returns>Returns true if the PIC Acknowledges</returns>
        private bool SendStart()
        {
            List<byte> TempData = new List<byte> { };
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x02;
            TempFreq.Data = TempData;
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool SendPeriod(UInt16 Period)
        {
            byte[] TempData = BitConverter.GetBytes(Globals.Period);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x04;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool SendPeriod_LPF(UInt16 Period)
        {
            byte[] TempData = BitConverter.GetBytes(Period);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x07;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool SendPeriod_BPF(UInt16 Period)
        {
            byte[] TempData = BitConverter.GetBytes(Period);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x08;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool SendOffset()
        {
            byte[] TempData = BitConverter.GetBytes(Globals.offset);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x05;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool SendScale(Byte s)
        {
            byte[] TempData = BitConverter.GetBytes(s);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x06;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool Send_Write_to_GUI(byte flag)
        {
            byte[] TempData = BitConverter.GetBytes(flag);
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0xFF;
            TempFreq.Data = new List<byte>(TempData);
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        #endregion

        #region BacnkgroundWorker1

        private void backgroundWorker1_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            //Globals.Serial.ReadTimeout = -1;
            HDLC_Rx DataRx = new HDLC_Rx();
            List<byte> Buffer = new List<byte>();
            HDLC_Rx.DPA_RX_STATE state = new HDLC_Rx.DPA_RX_STATE();

            while (backgroundWorker1.CancellationPending == false)
            {
                DataRx = new HDLC_Rx();
                state = new HDLC_Rx.DPA_RX_STATE();
                byte value1 = 0, value2 = 0;
                #region Parse through Data

                try
                {
                    Buffer.Add((byte)Globals.Serial.ReadByte());
                    //value1 = (byte)Globals.Serial.ReadByte();
                    //value2 = (byte)Globals.Serial.ReadByte();
                }
                catch
                {

                }
                if (Buffer.Contains(0xFF))
                {
                    try
                    {
                        value1 = Buffer[Buffer.IndexOf(0xFF) - 2];
                    }
                    catch
                    {
                        break;
                    }
                    value2 = Buffer[Buffer.IndexOf(0xFF) - 1];
                    Buffer.RemoveRange(Buffer.IndexOf(0xFF) - 2, 3);
                    Plot_Point(value1, value2);
                    //System.Threading.Thread.Sleep(1);
                }
            }
            #endregion
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {

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

        public void Plot_Point(byte value1, byte value2)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<byte, byte>(Plot_Point), new object[] { value1, value2 });
                return;
            }

            var now = (int)Globals.DataCounter++;

            ChartValues1.Add(new MeasureModel
            {
                SampleNum = now,
                Value = value1
            });

            ChartValues2.Add(new MeasureModel
            {
                SampleNum = now,
                Value = value2
            });

            SetAxisLimits(now);

            if (ChartValues1.Count > 16)
            {
                ChartValues1.RemoveAt(0);
                ChartValues2.RemoveAt(0);
            }


        }

        private void SetAxisLimits(int now)
        {
            cartesianChart1.AxisX[0].MaxValue = now + 1;
            cartesianChart1.AxisX[0].MinValue = now - 16;
        }

        #endregion
    }

    public class MeasureModel
    {
        public int SampleNum { get; set; }
        public double Value { get; set; }
    }


}
