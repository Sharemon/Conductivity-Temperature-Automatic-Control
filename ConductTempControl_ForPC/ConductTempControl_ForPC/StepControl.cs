using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConductTempControl_ForPC
{
    class StepControl
    {

        #region Members
        private const float flucThr   = 0.005f;
        private const float tempThr   = 0.005f;
        //private const int repeatTimes = 8;

        private float tempSetCurrent  = 0;
        private float tempSetInit     = 0;
        private float tempSetInterval = 0;
        //private float tempSetLast     = 0;
        private bool tempSetOrient    = true;      // True for +, false for -

        private UartProtocol uartCom = new UartProtocol(GlobalVars.portName);
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="initTemp">Initial temperature</param>
        /// <param name="intervalTemp">Temperature interval to be changed</param>
        /// <param name="changeOrient">Change orientation, true for +, false for -</param>
        public StepControl(float initTemp, float intervalTemp, bool changeOrient)
        {
            this.tempSetInit     = initTemp;
            this.tempSetInterval = intervalTemp;
            //this.tempSetLast = this.tempSetInit - (repeatTimes - 1) * this.tempSetInterval;
            this.tempSetOrient   = changeOrient;

            this.tempSetCurrent = this.tempSetInit;
        }
        #endregion

        #region Methods

        /// <summary>
        /// Start next turn to auto-control temperature
        /// </summary>
        public void NextTurn()
        {
            if (this.tempSetOrient)
            {
                this.tempSetCurrent = tempSetCurrent + tempSetInterval;
            }
            else
            {
                this.tempSetCurrent = tempSetCurrent - tempSetInterval;
            }

            // Todo: Need remove all uart error judgement?
            if (uartCom.SendData(UartProtocol.Commands_t.TempSet, tempSetCurrent)
                != UartProtocol.Errors_t.NoError)
            {
                Exception e = new Exception(" Communication command is in error !!!");
                throw e;
            }
        }

        /// <summary>
        /// Pause to auto-control temperature
        /// </summary>
        public void Pause()
        {
            // Improve: Need pause in this class?
            ;
        }

        /// <summary>
        /// Repeat this turn to auto-control temperature
        /// </summary>
        public void ThisTurn()
        {
            // Todo: Need remove all uart error judgement?
            if (uartCom.SendData(UartProtocol.Commands_t.TempSet, tempSetCurrent)
                != UartProtocol.Errors_t.NoError)
            {
                Exception e = new Exception(" Communication command is in error !!!");
                throw e;
            }
        }

        /// <summary>
        /// Reload parameter for auto-control
        /// </summary>
        /// <param name="initTemp">Initial temperature</param>
        /// <param name="intervalTemp">Temperature interval to be changed</param>
        /// <param name="changeOrient">Change orientation, true for +, false for -</param>
        public void Reload(float initTemp, float intervalTemp, bool changeOrient)
        {
            this.tempSetInit = initTemp;
            this.tempSetInterval = intervalTemp;
            //this.tempSetLast = this.tempSetInit - (repeatTimes - 1) * this.tempSetInterval;
            this.tempSetOrient = changeOrient;

            this.tempSetCurrent = this.tempSetInit;
        }

        /// <summary>
        /// Check if the fluctuation is in range
        /// </summary>
        /// <param name="count">Count used to calculate fluctuation</param>
        /// <returns>If in range</returns>
        public bool CheckFluc(int count)
        {
            float tempareture = 0;

            // Todo: Need remove all uart error judgement?
            if (uartCom.ReadData(UartProtocol.Commands_t.TempSet, out tempareture)
                != UartProtocol.Errors_t.NoError)
            {
                Exception e = new Exception(" Communication command is in error !!!");
                throw e;
            }

            float fluctuation = 0;

            // If there not enough temperature point to check fluctuation, consider it not in range
            if ( !GlobalVars.GetFluc(count, out fluctuation))
            {
                return false;
            }

            // If temperature and fluctuation are both in range, return true
            if (Math.Abs(tempareture - this.tempSetCurrent) < tempThr ||
                fluctuation < flucThr)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inform conduct equipment to start to measure
        /// </summary>
        /// <returns>If conduct measurement is over</returns>
        public bool InformConduct()
        {
            // Now we don't have any interface with conduct measurement
            // So just delay for 2 minutes

            System.Threading.Thread.Sleep(1000 * 60 * 2);

            return true;
        }

        /// <summary>
        /// Change serial port for auto-control mode
        /// </summary>
        /// <param name="portName">Port Name</param>
        public void SetPort(string portName)
        {
            uartCom.SetPort(portName);
        }

        #endregion

    }
}
