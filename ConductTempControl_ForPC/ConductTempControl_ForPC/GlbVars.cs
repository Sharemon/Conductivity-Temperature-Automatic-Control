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
    static class GlbVars
    {
        #region Define
        /// <summary>
        /// List all parameters.
        /// </summary>
        public enum Paras_t
        {
            TempSet = 0,
            TempCorrect,
            LeadAdjust,
            Fuzzy,
            Ratio,
            Integral,
            Power,
            FlucThr,
            TempThr
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

        public static List<float> temperatures = new List<float>();

        public static float[] paraValues  = { 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f, 0.0f };
        public static string[] paraFormat = { "0.000", "0.000", "0.000", "0", "0", "0", "0", "0.000", "0.000" };
        public static bool firstReadPara = true;

        // Todo: Need to be Initialized at the start of Main Form;
        public static UartProtocol uartCom;
        public static string portName = "";
        #endregion

        #region Contructor -- Init variables
        /// <summary>
        /// Do not use.
        /// </summary>
        static GlbVars()
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
            if(GlbVars.temperatures.Count == 0 || GlbVars.temperatures.Count < count)
            {
                // If there is not temperature data in list, output extreme max and min value
                tempMax = 10000;
                tempMin = -10000;

                return false;
            }
            else
            {
                tempMax = GlbVars.temperatures.GetRange(temperatures.Count - count, count).Max();
                tempMin = GlbVars.temperatures.GetRange(temperatures.Count - count, count).Min();
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
            if (GlbVars.temperatures.Count == 0 || GlbVars.temperatures.Count < count)
            {
                // If there is not temperature data in list, output extreme fluctuation
                fluctuation = -1;
                return false;
            }
            else
            {
                fluctuation = GlbVars.temperatures.GetRange(temperatures.Count - count, count).Max() -
                    GlbVars.temperatures.GetRange(temperatures.Count - count, count).Min();
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
