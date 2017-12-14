using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AForge;
using AForge.Math;
namespace Final_422
{

    /// <summary>
    /// Global variables used to store important data and to be useable across the GUI
    /// </summary>
    public class Globals
    {
        public static byte scale = 1;
        public static short Vert_offset = new short();
        public static double SamplingFreq = new double();
        public static byte Trigger = new byte();
        public static Int16 NumOfSamples = new short();
        public static UInt16 Period = 0;

        public static string LPF_100 = @"        9,      7,     -6,    -22,    -18,     14,     49,     38,    -31,
      -96,    -70,     57,    170,    118,   -101,   -284,   -191,    170,
      457,    297,   -279,   -727,   -463,    462,   1188,    755,   -828,
    -2191,  -1486,   2003,   6910,  10471,  10471,   6910,   2003,  -1486,
    -2191,   -828,    755,   1188,    462,   -463,   -727,   -279,    297,
      457,    170,   -191,   -284,   -101,    118,    170,     57,    -70,
      -96,    -31,     38,     49,     14,    -18,    -22,     -6,      7,
        9"; //Sample Freq 1000 //period value = 3250

        public static string LPF_200 = @"        9,      7,     -6,    -22,    -18,     14,     49,     38,    -31,
      -96,    -70,     57,    170,    118,   -101,   -284,   -191,    170,
      457,    297,   -279,   -727,   -463,    462,   1188,    755,   -828,
    -2191,  -1486,   2003,   6910,  10471,  10471,   6910,   2003,  -1486,
    -2191,   -828,    755,   1188,    462,   -463,   -727,   -279,    297,
      457,    170,   -191,   -284,   -101,    118,    170,     57,    -70,
      -96,    -31,     38,     49,     14,    -18,    -22,     -6,      7,
        9";//Sample Freq: 1500 // period value = 1525

        public static string LPF_300 = @"9,      7,     -6,    -22,    -18,     14,     49,     38,    -31,
      -96,    -70,     57,    170,    118,   -101,   -284,   -191,    170,
      457,    297,   -279,   -727,   -463,    462,   1188,    755,   -828,
    -2191,  -1486,   2003,   6910,  10471,  10471,   6910,   2003,  -1486,
    -2191,   -828,    755,   1188,    462,   -463,   -727,   -279,    297,
      457,    170,   -191,   -284,   -101,    118,    170,     57,    -70,
      -96,    -31,     38,     49,     14,    -18,    -22,     -6,      7,
        9"; //Sample Freq: 2000 // period value = 200;


        public static UInt16 LPF_300_Period = 200;
        public static UInt16 LPF_200_Period = 1525;
        public static UInt16 LPF_100_Period = 3250;

        public static string BPF_100;

        public static string BPF_200;

        public static string BPF_300 = @"5,    -49,    -59,    -14,     86,    156,     91,   -115,   -305,
     -263,     70,    464,    538,    108,   -559,   -879,   -451,    500,
     1194,    931,   -223,  -1363,  -1452,   -269,   1284,   1873,    893,
     -922,  -2056,  -1499,    336,   1924,   1924,    336,  -1499,  -2056,
     -922,    893,   1873,   1284,   -269,  -1452,  -1363,   -223,    931,
     1194,    500,   -451,   -879,   -559,    108,    538,    464,     70,
     -263,   -305,   -115,     91,    156,     86,    -14,    -59,    -49,
        5";


        public static UInt16 BPF_300_Period = 50;
        public static UInt16 BPF_200_Period = 25;
        public static UInt16 BPF_100_Period = 17;

        public static Int64 DataCounter = 0;
        /// <summary>
        /// Serial COM Port for GUI
        /// </summary>
        public static string COMPort = "COM4";

        /// <summary>
        /// Serial Port object
        /// </summary>
        public static System.IO.Ports.SerialPort Serial = new System.IO.Ports.SerialPort();

        //Frequency Control//

        /// <summary>
        /// Start Frequency
        /// </summary>
        public static uint StartFreq = 10000;

        /// <summary>
        /// Freq Increment
        /// </summary>
        public static uint FreqInc = 10000;

        /// <summary>
        /// Number of Increments
        /// </summary>
        public static ushort NumOfInc = 2;

        /// <summary>
        /// Settling Time Cycles
        /// </summary>
        public static ushort SettlingCycles = 60;

        /// <summary>
        /// Calculated end freq
        /// </summary>
        public static uint EndFreq; //Not passed just calced


        //Output Voltage Variable//

        /// <summary>
        /// Output Voltage Variable
        /// </summary>
        public static byte OutputVoltage = 0x3;  //This is the outgoing one

        /// <summary>
        /// 2vpp  Const
        /// </summary>
        public const byte OutputVoltage2Vpp = 0x0;

        /// <summary>
        /// 200mvpp const
        /// </summary>
        public const byte OutputVoltage200mVpp = 0x1;

        /// <summary>
        /// 400mvpp const
        /// </summary>
        public const byte OutputVoltage400mVpp = 0x2;

        /// <summary>
        /// 1vpp const
        /// </summary>
        public const byte OutputVoltage1Vpp = 0x3;

        //Switching Variables//

        /// <summary>
        /// Tp switch Variable
        /// </summary>
        public static byte SwitchTp = 1;

        /// <summary>
        /// Tn switch variable
        /// </summary>
        public static byte SwitchTn = 7;

        /// <summary>
        /// A switch variable
        /// </summary>
        public static byte SwitchA = 3;

        /// <summary>
        /// B switch variable
        /// </summary>
        public static byte SwitchB = 5;

        /// <summary>
        /// Temperature variable
        /// </summary>
        public static float Temperature;

        /// <summary>
        /// Increments Completed Variable
        /// </summary>
        public static short IncCompleted = new short();

        /// <summary>
        /// timeout variable
        /// </summary>
        public static int timeout = new byte();

        /// <summary>
        /// Samples variable
        /// </summary>
        public static int Samples = 100;

    }


}
