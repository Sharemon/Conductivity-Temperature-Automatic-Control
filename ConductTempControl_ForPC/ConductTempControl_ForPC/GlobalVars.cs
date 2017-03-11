using System;
using System.Collections.Generic;
using System.Data;
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
        public static DateTime ctrlStartTime;
        public static int readTempInterval = 1000;
        private const int tempMaxLen       = 1000; 

        // The length of temperature data to calculate fluctuation
        // !!! Must > DrawChart.tempChartFixLen !!!
        public static int tempFlucLen_15min = 15 *60 / (readTempInterval / 1000);
        public static int tempFlucLen_10min = 10 * 60 / (readTempInterval / 1000);
        public static int tempFlucLen_5min  = 5 * 60 / (readTempInterval / 1000);
        public static int tempFlucLen_2min  = 2 * 60 / (readTempInterval / 1000);

        public static List<float> temperatures  = new List<float>();

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

        #region Methods
        /// <summary>
        /// Get the max value and min value of temperature list
        /// </summary>
        /// <param name="count">Counts to calculate</param>
        /// <param name="tempMax">Max of temperature</param>
        /// <param name="tempMin">Min of temperature</param>
        /// <returns>If the max and min can be trusted</returns>
        public static bool GetMaxMin(int count, out float tempMax, out float tempMin)
        {
            if(GlobalVars.temperatures.Count == 0 || GlobalVars.temperatures.Count < count)
            {
                // If there is not temperature data in list, output extreme max and min value
                tempMax = 10000;
                tempMin = -10000;

                return false;
            }
            else
            {
                tempMax = GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Max();
                tempMin = GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Min();
                return true;
            }
        }

        /// <summary>
        /// Get fluctuation of temperature list
        /// </summary>
        /// <param name="count">Counts to calculate</param>
        /// <param name="fluctuation">Fluctuation of temperature</param>
        /// <returns>If the max and min can be trusted</returns>
        public static bool GetFluc(int count, out float fluctuation)
        {
            if (GlobalVars.temperatures.Count == 0 || GlobalVars.temperatures.Count < count)
            {
                // If there is not temperature data in list, output extreme fluctuation
                fluctuation = -1;
                return false;
            }
            else
            {
                fluctuation = GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Max() -
                    GlobalVars.temperatures.GetRange(temperatures.Count - count, count).Min();
                return true;
            }
        }

        /// <summary>
        /// Add temperature data into temperature list
        /// </summary>
        /// <param name="data"></param>
        public static void AddTemperature(float data)
        {
            if(temperatures.Count == tempMaxLen)
            {
                temperatures.RemoveAt(0);
            }
            temperatures.Add(data);
        }
        #endregion
    }
}
