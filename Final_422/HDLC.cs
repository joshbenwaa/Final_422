using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;


namespace Final_422
{
    /// <summary>
    /// Class to create and store information in a HDLC frame that is to be transmitted
    /// </summary>
    public class HDLC_tx
    {
        #region Variables

        /// <summary>
        /// HDLC_tx command variable
        /// </summary>
        public byte cmd;

        /// <summary>
        /// HDLC_tx crc variable
        /// </summary>
        public byte crc;

        /// <summary>
        /// HDLC_tx Data variable
        /// </summary>
        public List<byte> Data;

        /// <summary>
        /// HDLC_tx Length Variable
        /// </summary>
        public byte Length;

        /// <summary>
        /// HDLC_tx Buffer
        /// </summary>
        public byte[] Buffer;

        #endregion

        #region Contructor

        /// <summary>
        /// Constructor for HDLC_tx
        /// </summary>
        public HDLC_tx()
        {
            cmd = 0;
            crc = 0;
            Data = new List<byte>();
            Length = 0;
        }

        #endregion

        #region Create HDLC word

        /// <summary>
        /// Creates the HDLC frame and stores it into buffer
        /// </summary>
        public void CreateHDLC()
        {
            byte temp;
            List<byte> tmpBuffer = new List<byte>();
            List<byte> tmpBuffer2 = new List<byte>();

            // Clear buffer
            tmpBuffer.Clear();

            // Add cmd
            tmpBuffer.Add(cmd);

            // Add Length
            Length = (byte)Data.Count;
            tmpBuffer.Add((byte)Data.Count);

            // Add Data
            for (byte i = 0; i < Length; i++)
                tmpBuffer.Add(Data[i]);

            // Add CRC
            crc = DPA_UTILS.CalcCRC(tmpBuffer);
            tmpBuffer.Add(crc);

            // Make a HDLC frame
            tmpBuffer2.Clear();
            tmpBuffer2.Add((byte)0x7E);    // Flag sequence
            foreach (byte tmp in tmpBuffer)
            {
                temp = tmp;
                // If there is Flag sequence or Control escape
                if ((temp == (byte)0x7D) || (temp == (byte)0x7E))
                {
                    tmpBuffer2.Add((byte)0x7D);
                    tmpBuffer2.Add((byte)(temp ^ 0x20));
                }
                else
                {
                    tmpBuffer2.Add((byte)temp);
                }
            }
            tmpBuffer2.Add((byte)0x7E);    // Flag sequence

            // Copy result to Buffer
            Buffer = new byte[tmpBuffer2.Count];
            tmpBuffer2.CopyTo(Buffer);
        }

        #endregion
    }

    /// <summary>
    /// Class to create and store information in a HDLC fram that is to be recieved
    /// </summary>
    public class HDLC_Rx
    {

        /// <summary>
        /// States that are returned from parsing an incoming HDLC frame
        /// </summary>
        public enum DPA_RX_STATE
        {
            /// <summary>
            /// Default state
            /// </summary>
            DPA_RX_NOERR,       // default state

            /// <summary>
            /// OK, message Parsed
            /// </summary>
            DPA_RX_OK,          // OK, message parsed

            /// <summary>
            /// Frame Error
            /// </summary>
            DPA_RX_FE,          // Frame error

            /// <summary>
            /// CRC error
            /// </summary>
            DPA_RX_CRCERR       // CRC error
        }

        #region Variables

        byte cmd;

        /// <summary>
        /// Data variable for HDLC_rx
        /// </summary>
        public List<byte> Data;
        byte Length;



        private bool HDLC_CE;           // control escape flag
        private byte CRC;               // HDLC CRC

        /// <summary>
        /// HDLC_Rx recieve buffer
        /// </summary>
        public List<byte> Buffer;        // Input buffer

        /// <summary>
        /// HDLC Flag Sequence (0x7E)
        /// </summary>
        public const byte HDLC_FLAG_SEQUENCE = 0x7e;    // Flag sequence constant

        /// <summary>
        /// HDLC Control Escape (0x7d)
        /// </summary>
        public const byte HDLC_CONTROL_ESCAPE = 0x7d;   // Control escape constant

        /// <summary>
        /// HDLC Escape Bit (0x20)
        /// </summary>
        public const byte HDLC_ESCAPE_BIT = 0x20;       // Escape bit constant

        /// <summary>
        /// HDLC Min Length (0)
        /// </summary>
        public const byte HDLC_MIN_LEN = 0;          // Minimum length of response

        /// <summary>
        /// HDLC Max Length (0xFF)
        /// </summary>
        public const byte HDLC_MAX_LEN = 0xFF;          // Maximum length of buffer

        #endregion

        #region Constructor

        /// <summary>
        /// Construcor for HDLC_Rx
        /// </summary>
        public HDLC_Rx()
        {

            Data = new List<byte>();        // New DPA data array
            Length = 0;                   // Reset Data length
            CRC = 0x00;                 // Reset CRC          
            Buffer = new List<byte>();
        }

        #endregion

        #region This method try to parse DPA message against incomming character

        /// <summary>
        /// Method to parse through incoming bytes and create a HDLC frame
        /// </summary>
        /// <param name="character">the byte to check</param>
        /// <returns>Returns the state of the HDLC frame after checking one character</returns>
        public DPA_RX_STATE DPA_RX_Parse(byte character)
        {
            int i = 0;
            DPA_RX_STATE ret_val = DPA_RX_STATE.DPA_RX_NOERR;

            if (character == HDLC_FLAG_SEQUENCE)        // flag sequence
            {
                // first Flag sequnce
                if (Buffer.Count == 0)
                {
                    Buffer.Add((byte)character);
                    HDLC_CE = false;
                }
                else
                {
                    // It is error state - too short message
                    if (Buffer.Count < (HDLC_MIN_LEN - 1))
                    {
                        // Maybe it is start of new frame...
                        Buffer.Clear(); Buffer.Add(character);
                        return DPA_RX_STATE.DPA_RX_FE;
                    }
                    // Correct length
                    else
                    {
                        // Check CRC                        
                        Buffer.RemoveAt(0); // remove first Flag sequnce                       
                        byte crc = DPA_UTILS.CalcCRC(Buffer);
                        // CRC is OK
                        if (crc == 0)
                        {
                            byte[] tmpBuffer = new byte[Buffer.Count];
                            Buffer.CopyTo(tmpBuffer);
                            cmd = tmpBuffer[0];
                            Length = tmpBuffer[1];
                            for (i = 0; i < Length; i++)
                            {
                                Data.Add(tmpBuffer[i + 2]); //exception
                            }
                            CRC = tmpBuffer[Length + 2];
                            Buffer.Clear();
                            return DPA_RX_STATE.DPA_RX_OK;
                        }
                        // CRC is no OK
                        else
                        {
                            // Maybe it is start of new frame...
                            Buffer.Clear(); Buffer.Add((byte)0x7E);
                            return DPA_RX_STATE.DPA_RX_CRCERR;
                        }
                    }
                }

            }
            else // if another character received
            {
                // if it is not the first character and length is within borders
                if ((Buffer.Count > 0) && (Buffer.Count < HDLC_MAX_LEN))
                {
                    // if Control Esape received
                    if (character == HDLC_CONTROL_ESCAPE)
                        HDLC_CE = true;
                    else
                    {   // else insert character
                        if (HDLC_CE == false)
                            Buffer.Add((byte)character);
                        else
                        {
                            HDLC_CE = false;
                            Buffer.Add((byte)((byte)character ^ (byte)HDLC_ESCAPE_BIT));
                        }
                    }
                }
            }

            return ret_val;
        }

        #endregion

    }

    /// <summary>
    /// Class with methods shared between HDLC_tx and HDLC_rx
    /// </summary>
    class DPA_UTILS
    {

        #region CalcCRC

        /// <summary>
        /// Calculates the CRC of a frame
        /// </summary>
        /// <param name="buffer">the frame as a list of bytes</param>
        /// <returns>the CRC of that frame</returns>
        public static byte CalcCRC(List<byte> buffer)
        {
            byte crc = 0x00;
            byte[] temp = new byte[buffer.Count];
            buffer.CopyTo(temp);
            foreach (byte val in temp)
            {
                byte value = val;
                for (int bitLoop = 8; bitLoop != 0; --bitLoop, value >>= 1)
                    if (((crc ^ value) & 0x01) != 0)
                        crc = (byte)((crc >> 1) ^ 0x8C);
                    else
                        crc >>= 1;
            }
            return crc;
        }

        #endregion

    }
}
