using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConductTempControl_ForPC
{
    /// <summary>
    /// Class for saving global variables
    /// </summary>
    static class GlobalVars
    {
        #region Define
        /// <summary>
        /// List all parameters.
        /// </summary>
        public enum Parameters_t
        {
            TempSet = 0,
            TempCorrect,
            LeadAdjust,
            Fuzzy,
            Ratio,
            Integral,
            Power,
            Fluctuation
        };
        #endregion

        #region Members -- global variables
        public static List<float> temperatures = new List<float>();
        public static List<float> power        = new List<float>();

        public static float[] parameterValues  = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };  
         
        public static string portName          = "";
        #endregion

        #region Contructor -- Init variables
        /// <summary>
        /// Do not use.
        /// </summary>
        static GlobalVars()
        {
            ;
        }
        #endregion

        #region Members
        /// <summary>
        /// Get the max value and min value of temperature list
        /// </summary>
        /// <param name="count">Counts to calculate</param>
        /// <param name="tempMax">Max of temperature</param>
        /// <param name="tempMin">Min of temperature</param>
        /// <returns>If the max and min can be trusted</returns>
        public static bool GetMaxMin(int count, out float tempMax, out float tempMin, out float fluctuation)
        {
            if(GlobalVars.temperatures.Count == 0 || GlobalVars.temperatures.Count < count)
            {
                // If there is not temperature data in list, output extreme max and min value
                tempMax = 1000;
                tempMin = -1000;
                fluctuation = 2000;

                return false;
            }
            else
            {
                tempMax = GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Max();
                tempMin = GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Min();
                fluctuation = tempMax - tempMin;
                return true;
            }
        }
        #endregion
    }
}
