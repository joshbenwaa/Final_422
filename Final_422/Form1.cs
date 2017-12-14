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
using AForge;

namespace Final_422
{
    public partial class Main : Form
    {
        #region Variables
        public bool connectedflag = false;
        public ChartValues<ObservableByte> Chart_Values;
        public ChartValues<ObservablePoint> DFT_Values;
        public ChartValues<ObservablePoint> Phase_Values;
        #endregion

        #region Main

        public Main()
        {

            InitializeComponent();
            Chart_Values = new ChartValues<ObservableByte>();
            DFT_Values = new ChartValues<ObservablePoint>();
            Phase_Values = new ChartValues<ObservablePoint>();
            for (int j = 0; j < 200; j++)
            {
                Chart_Values.Add(new ObservableByte(0));
            }
            for (int k = 0; k < 9; k++)
            {
                DFT_Values.Add(new ObservablePoint(k, 0));
            }
            for (int i = 0; i < 200; i++)
            {
                Phase_Values.Add(new ObservablePoint(i, 0));
            }
            var mapper = Mappers.Xy<ObservableByte>()
            .X((value, index) => index) //use the index as X
            .Y((value, index) => value.Value); //use the value as Y1
            var DFT_mapper = Mappers.Xy<ObservablePoint>()
            .X((value, index) => value.X) //use the index as X
            .Y((value, index) => value.Y); //use the value as Y1

            //lets save the mapper globally.
            Charting.For<ObservableByte>(mapper);
            Charting.For<ObservablePoint>(DFT_mapper);
            cartesianChart1.AxisX.Add(new Axis
            {
                DisableAnimations = true,
                Separator = new Separator
                {
                    Step = 10
                }
            });

            cartesianChart_DFT.AxisX.Add(new Axis
            {
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                DisableAnimations = true,
                LabelFormatter = value => String.Format("{0,6}", value.ToString())
            });

            cartesianChart_phase.AxisX.Add(new Axis
            {
                Separator = new Separator // force the separator step to 1, so it always display all labels
                {
                    Step = 1,
                    IsEnabled = false //disable it to make it invisible.
                },
                DisableAnimations = true,
            });

            cartesianChart1.Series.Add(new LineSeries
            {
                Fill = System.Windows.Media.Brushes.Transparent,
                Values = Chart_Values,
                Title = "Measurement"
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

            cartesianChart_DFT.Series.Add(new ColumnSeries
            {
                Values = DFT_Values,
                Title = "Magnitude"
            });
            cartesianChart_DFT.AnimationsSpeed = TimeSpan.FromMilliseconds(.1);

            cartesianChart_phase.Series.Add(new LineSeries
            {
                Values = Phase_Values,
                PointGeometry = null,
                Fill = System.Windows.Media.Brushes.Transparent,
                Title = "Phase"


            });
            cartesianChart_phase.AnimationsSpeed = TimeSpan.FromMilliseconds(.1);

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
            TempFreq.Data = new List<byte>() { trigger, Rising_Falling };
            TempFreq.CreateHDLC();
            Globals.Serial.Write(TempFreq.Buffer, 0, TempFreq.Buffer.Length);
            return Aknowledged();
        }

        private bool Send_RequestData()
        {
            List<byte> TempData = new List<byte> { Globals.Trigger };
            HDLC_tx TempFreq = new HDLC_tx();
            TempFreq.cmd = 0x05;
            if (radioButton_falling.Checked)
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
            Globals.Serial.ReadTimeout = 2000;
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
                        break;
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
                        Plot_Series(DataRx.Data.GetRange(0, 200));
                        Update_SamplingFreqLabel(BitConverter.ToUInt16(DataRx.Data.GetRange(200, 2).ToArray(), 0));
                        Calc_And_Plot_DFT(DataRx.Data.GetRange(0, 200));
                        break;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_FE:
                        Append_Output(">> An error in the calibration data frame.\n"); break;
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

            for (int i = 0; i < values.Count; i++)
            {
                Chart_Values[i] = new ObservableByte(values[i]);
            }
        }

        public void Update_SamplingFreqLabel(UInt16 value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<UInt16>(Update_SamplingFreqLabel), new object[] { value });
                return;
            }
            Globals.SamplingFreq = ((1.0 / ((double)value / 200.0)) * 70000000.0);
            label_SamplingFreq.Text = "Sampling Frequency: " + Globals.SamplingFreq.ToString() + " hz";
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
            //Otherwise the system is already stopped
            button_RunStop.BackColor = System.Drawing.SystemColors.Control;
            button_single.BackColor = System.Drawing.Color.Yellow;
            HDLC_Rx DataRx = new HDLC_Rx();
            List<byte> Buffer = new List<byte>();
            HDLC_Rx.DPA_RX_STATE state = new HDLC_Rx.DPA_RX_STATE();
            DataRx = new HDLC_Rx();
            state = new HDLC_Rx.DPA_RX_STATE();
            Globals.Serial.DiscardInBuffer();
            bool success = false;
            while (success == false)
            {
                while (!Send_RequestData())
                {
                    FailedCounter++;
                    if (FailedCounter >= 3)
                    {
                        Append_Output(">> Sending Request For Data Failed\n");
                        break;
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
                        Replace_Output(">> trig'd?\n");
                        break;
                    }
                }
                switch (state)
                {
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_OK:
                        //Was a success, add code here
                        Replace_Output(">> trig'd\n");
                        Plot_Series(DataRx.Data.GetRange(0, 200));
                        Update_SamplingFreqLabel(BitConverter.ToUInt16(DataRx.Data.GetRange(200, 2).ToArray(), 0));
                        Calc_And_Plot_DFT(DataRx.Data.GetRange(0, 200));
                        button_single.BackColor = System.Drawing.Color.Transparent;
                        button_RunStop.BackColor = System.Drawing.Color.Red;
                        success = true;
                        break;
                    case HDLC_Rx.DPA_RX_STATE.DPA_RX_FE:
                        Append_Output(">> An error in the calibration data frame.\n"); break;
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
            if (button_RunStop.BackColor == System.Drawing.Color.LimeGreen)
            {
                OutputLabel.Text = ">> Please turn Scope of first.\n";
                return;
            }
            Globals.Serial.ReadTimeout = -1;
            if (Globals.Serial.IsOpen)
            {
                byte Rising_Falling = 1;
                if (radioButton_falling.Checked)
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
            Globals.Trigger = (byte)trackBar_trigger.Value;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Calc_And_Plot_DFT(List<byte> values)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<List<byte>>(Calc_And_Plot_DFT), new object[] { values });
                return;
            }
            byte[] values_Array = values.ToArray();
            double[] Input = new double[values.Count + 2];
            double[] FreqScale = MathNet.Numerics.IntegralTransforms.Fourier.FrequencyScale(200, Globals.SamplingFreq);
            string[] FreqScale_labels = new string[FreqScale.Length];
            for (int i = 0; i < FreqScale.Length; i++)
            {
                FreqScale_labels[i] = FreqScale[i].ToString("F");
            }
            MathNet.Numerics.Complex32[] complex32 = new MathNet.Numerics.Complex32[200];
            for (int i = 0; i < 200; i++)
            {
                complex32[i] = new MathNet.Numerics.Complex32(Convert.ToSingle((values_Array[i])), 0);
            }

            MathNet.Numerics.IntegralTransforms.Fourier.Forward(complex32, MathNet.Numerics.IntegralTransforms.FourierOptions.Matlab);

            for (int i = 0; i < 9; i++)
            {
                DFT_Values[i] = new ObservablePoint(i, complex32[i].Magnitude);
            }

            for (int i = 0; i < 200; i++)
            {
                Phase_Values[i] = new ObservablePoint(i, complex32[i].Phase);
            }
            cartesianChart_DFT.AxisX[0].Labels = FreqScale_labels;

            label_Vpp.Text = string.Format("Vpp = {0}", ((values.Max() - values.Min()) / 255.0) * 3.2);
            List<double> FreqScaleList = new List<double>(FreqScale);
            int SLI = SecondLargestIndex(complex32);
            label_Freq.Text = string.Format("Frequency = {0}", Math.Abs(FreqScaleList[SLI]));
            label_phase.Text = string.Format("Phase = {0}", complex32[SLI].Phase);
        }

        private static int SecondLargestIndex(MathNet.Numerics.Complex32[] cn)
        {
            double[] mag = new double[cn.Length];
            for (int i = 0; i < cn.Length; i++)
            {
                mag[i] = cn[i].Magnitude;
            }
            double secondHighest = (from number in mag
                                    orderby number descending
                                    select number).Skip(1).First();

            return Array.IndexOf(mag, secondHighest);

        }

        private void trackBar_Vertical_Scroll(object sender, EventArgs e)
        {
            cartesianChart1.AxisY[0].MaxValue = 255 / trackBar_Vertical.Value;
        }

        private void trackBar_offset_Scroll(object sender, EventArgs e)
        {
            Globals.Vert_offset = trackBar_Vertical.Value;
        }
    }

}
