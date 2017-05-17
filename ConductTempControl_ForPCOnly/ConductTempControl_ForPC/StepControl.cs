using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConductTempControl_ForPC
{
    class StepControl
    {

        #region Members
        //private const float flucThr   = 0.005f;
        //private const float tempThr   = 0.005f;
        //private const int repeatTimes = 8;

        private float tempSetCurrent  = 0;
        private float tempSetInit     = 0;
        private float tempSetInterval = 0;
        //private float tempSetLast     = 0;
        private bool tempSetOrient    = true;      // True for +, false for -

        // Init the check count to 1min
        // Todo: check it should be changed?
        private int checkCount = 1 * 60 / (GlbVars.readTempInterval/1000);
        // Replaced by GlbVars.uartCom
        //private UartProtocol uartCom = new UartProtocol(GlobalVars.portName);
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
            // Calculate next temperature target value
            if (this.tempSetOrient)
            {
                this.tempSetCurrent = this.tempSetCurrent + this.tempSetInterval;
            }
            else
            {
                this.tempSetCurrent = this.tempSetCurrent - this.tempSetInterval;
            }

            // Improve: Need remove all uart error judgement?
            // Set temperature target
            if (GlbVars.uartCom.SendData(UartProtocol.Commands_t.TempSet, tempSetCurrent)
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
            // Improve: Need remove all uart error judgement?
            // Set temperature target
            if (GlbVars.uartCom.SendData(UartProtocol.Commands_t.TempSet, tempSetCurrent)
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
        public bool CheckFluc(out float temperature)
        {
            // Improve: Need remove all uart error judgement?
            if (GlbVars.uartCom.ReadData(UartProtocol.Commands_t.TempShow, out temperature)
                != UartProtocol.Errors_t.NoError)
            {
                Exception e = new Exception(" Communication command is in error !!!");
                throw e;
            }

            // Add temperature data into list
            GlbVars.AddTemperature(temperature);

            float fluctuation = 0;

            // If there not enough temperature point to check fluctuation, consider it not in range
            if ( !GlbVars.GetFluc(checkCount, out fluctuation))
            {
                return false;
            }

            // If temperature and fluctuation are both in range, return true
            if (Math.Abs(temperature - this.tempSetCurrent) < GlbVars.paraValues[(int)GlbVars.Paras_t.TempThr] &&
                fluctuation < GlbVars.paraValues[(int)GlbVars.Paras_t.FlucThr])
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Inform conduct equipment to start to measure
        /// </summary>
        /// <returns>If conduct measurement is over</returns>
        public bool InformCondMeas()
        {
            // Now we don't have any interface with conduct measurement
            // So just delay for 2 minutes

            System.Threading.Thread.Sleep(1000 * 60 * 2);

            return true;
        }

        #endregion

    }
}
