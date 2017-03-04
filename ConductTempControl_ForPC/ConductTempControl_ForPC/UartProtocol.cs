using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;
using System.Threading;

namespace ConductTempControl_ForPC
{
    /// <summary>
    /// Class for implement communication protocolq
    /// </summary>
    class UartProtocol
    {
        #region Members

        #region Serial Port
        private const int baudrate        = 2400;
        private const int dataBits        = 8;
        private const StopBits stopBits   = StopBits.One;
        private const Parity parity       = Parity.None;
        private const int readBufferSize  = 64;
        private const int writeBufferSize = 64;
        private const int readTimeout     = 5000;
        private SerialPort sp = new SerialPort()
        {
            // Init all parameters except portname, as other parameter should not be easily changed.
            BaudRate = baudrate,
            DataBits = dataBits,
            StopBits = stopBits,
            Parity = parity,
            ReadBufferSize = readBufferSize,
            WriteBufferSize = writeBufferSize,
            ReadTimeout = readTimeout
        };

        private const int intervalOfWR = 200;
        #endregion

        #region Command 
        public enum Errors_t
        {
            NoError = 0,
            NotInRange,
            UnknownCmd,
            IncompleteCmd,
            BCCError
        };
        private readonly string[] errorWords = { "A", "B", "C", "D"};
        private const char errorFlag = 'E';

        /// <summary>
        /// List all commands
        /// </summary>
        public enum Commands_t
        {
            TempSet = 0,
            TempCorrect,
            LeadAdjust,
            Fuzzy,
            Ratio,
            Integral,
            Power,
            TempShow,
            PowerShow
        };
        
        private const string commandHead_W          = "@35W";
        private const string commandHead_R          = "@35R";
        private readonly string[] commandWords      = { "A", "B", "C", "D", "E", "F", "G", "H", "I"};
        private readonly string[] commandFormats    = { "0.000", "0.000", "0.000", "0", "0", "0", "0", "0.000", "0" };
        private const string commandFinish          = ":";
        private const string commandEnd             = "\r"; // Todo: The endflag may be \r\n, check it.

        private readonly string[] commandRW         = { "w", "w", "w", "w", "w", "w", "w", "r", "r" };
        #endregion

        #endregion

        #region Constructor
        /// <summary>
        /// Constructor. Set the port name.
        /// </summary>
        /// <param name="portName"></param>
        public UartProtocol(string portName)
        {
            SetPortName(portName);          
        }
        #endregion


        #region Public Methods
        /// <summary>
        /// Set port name of serial port in this class and global variables.
        /// </summary>
        /// <param name="portName">Port name of serial port</param>
        public void SetPortName(string portName)
        {
            this.sp.PortName = portName;
            // Keep the GlobalVars.portName is always the latest.
            GlobalVars.portName = portName;
        }

        /// <summary>
        /// Send data to MCU
        /// </summary>
        /// <param name="commandName">Name of ommand</param>
        /// <param name="value">Value of Command</param>
        public Errors_t SendData(Commands_t commandName, float value)
        {
            // Todo: Check if can remove this and commandRW when development finishes.
            // If the command cannot be write, throw an exception
            if (commandRW[(int)commandName] != "w")
            {
                Exception e = new Exception
                    (String.Format("This parameter {0} cannot be write",Enum.GetName(commandName.GetType(), commandName)));
                throw e;
            }

            string command = ConstructCommand(commandName, value, true);

            #region Serial Port Open Section
            this.sp.Open();
            this.sp.Write(command);
            Errors_t error = IsError(this.ReadSP());
            this.sp.Close();
            #endregion

            return error;
        }

        /// <summary>
        /// Read data from MCU
        /// </summary>
        /// <param name="commandName">Name of command</param>
        /// <param name="readValue">Data read from MCU</param>
        /// <returns></returns>
        public Errors_t ReadData(Commands_t commandName, out float readValue)
        {
            // All command can be read
            string command = ConstructCommand(commandName, 0.0f, false);

            #region Serial Port Open Section
            this.sp.Open();
            this.sp.Write(command);

            string commandBack= this.ReadSP();
            this.sp.Close();
            #endregion

            Errors_t error = IsError(commandBack);
            if (error != Errors_t.NoError)
            {
                readValue = 0.0f;
            }
            else
            {
                readValue = float.Parse(commandBack.Substring(5));
            }

            return error;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Determine i there is any error in communication
        /// </summary>
        /// <returns>Is Error?</returns>
        private Errors_t IsError(string command)
        {
            Errors_t error = Errors_t.NoError;

            if (command[3] == errorFlag)
            {
                error = (Errors_t)(Array.IndexOf(errorWords, command[4].ToString()) + 1);
            }

            return error;
        }

        /// <summary>
        /// Read from serial port
        /// </summary>
        /// <returns>Command before ":"(finish flag of command)</returns>
        private string ReadSP()
        {
            //Improved: Consoder if it's necessary to use sub thread to read serial port data
            // ...
            Thread.Sleep(intervalOfWR);
            //Improved: Add exception handler for read timeout
            string readString = this.sp.ReadTo(commandFinish);
            //Improved: Add BCC checker
            sp.DiscardInBuffer();
            return readString;
        }

        /// <summary>
        /// Construct command using given name and value
        /// </summary>
        /// <param name="commandName">Name of command</param>
        /// <param name="value">Value of command</param>
        /// <param name="W_R">True for write, false for read</param>
        /// <returns></returns>
        private string ConstructCommand(Commands_t commandName, float value, bool W_R)
        {
            string command = "";

            if (W_R)
            {
                command += commandHead_W;
                command += commandWords[(int)commandName];
                command += value.ToString(commandFormats[(int)commandName]);
                command += commandFinish;
                command += BCCCal(command, false);
                command += commandEnd;
            }
            else
            {
                command += commandHead_R;
                command += commandWords[(int)commandName];
                command += commandFinish;
                command += BCCCal(command, false);
                command += commandEnd;
            }

            return command;
        }

        /// <summary>
        /// Calculate BCC (similiar with CRC) by given command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="cal">If true, calculate and return BCC. Otherwise, return ""</param>
        /// <returns></returns>
        private string BCCCal(string command, bool ifCal)
        {
            string BCC = "";

            if(ifCal)
            {
                // Do not implement as it isn't used in current project
                // ...
            }
            else
            {
                BCC = "";
            }

            return BCC;
        }

        /// <summary>
        /// Check if BCC is correct
        /// </summary>
        /// <param name="command">Command returned by MCU</param>
        /// <param name="ifCheck">If true, check and return result. Otherwise, return true.</param>
        /// <returns></returns>
        private bool CheckBCC(string command, bool ifCheck)
        {
            return true;
        }
        #endregion
    }
}
