//Undone: 1. IsError
//Undone: 2. Read data
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO.Ports;

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

        #endregion

        #region Command 
        /// <summary>
        /// List all commands
        /// </summary>
        public enum CommandNames_t
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
        
        private const string commandHead   = "@35W";
        private string[] commandWords      = { "A", "B", "C", "D", "E", "F", "G", "H", "I"};
        private string[] commandFormats    = { "0.000", "0.000", "0.000", "0", "0", "0", "0", "0.000", "0" };
        private const string commandFinish = ":";
        private const string commandEnd    = "\r"; // Todo: The endflag may be \r\n, check it.

        private string[] commandRW         = { "w", "w", "w", "w", "w", "w", "w", "r", "r" };
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
        public bool SendCommand(CommandNames_t commandName, float value)
        {
            // Todo: Check if can remove this and commandRW when development finishes.
            // If the command cannot be write, throw an exception
            if (commandRW[(int)commandName] != "w")
            {
                Exception e = new Exception
                    (String.Format("This parameter {0} cannot be write",Enum.GetName(commandName.GetType(), commandName)));
                throw e;
            }

            string command = ConstructCommand(commandName, value);

            #region Serial Port Open Section
            this.sp.Open();
            this.sp.Write(command);
            bool error = IsError();
            this.sp.Close();
            #endregion

            return error;
        }

        /// <summary>
        /// Read data from MCU
        /// </summary>
        /// <param name="commandName"></param>
        public float ReadData(string commandName)
        {
            return 0.0f;
        }

        #endregion

        #region Private Methods
        /// <summary>
        /// Determine i there is any error in communication
        /// </summary>
        /// <returns>Is Error?</returns>
        private bool IsError()
        {
            return false;
        }

        /// <summary>
        /// Construct command using given name and value
        /// </summary>
        /// <param name="commandName">Name of command</param>
        /// <param name="value">Value of command</param>
        /// <returns></returns>
        private string ConstructCommand(CommandNames_t commandName, float value)
        {
            string command = "";

            command += commandHead;
            command += commandWords[(int)commandName];
            command += value.ToString(commandFormats[(int)commandName]);
            command += BCCCal(command, false);
            command += commandEnd;

            return command;
        }

        /// <summary>
        /// Calculate BCC (similiar with CRC) by given command
        /// </summary>
        /// <param name="command">Command</param>
        /// <param name="cal">If true, calculate and return BCC. Otherwise, return ""</param>
        /// <returns></returns>
        private string BCCCal(string command, bool cal)
        {
            string BCC = "";

            if(cal)
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
        #endregion
    }
}
