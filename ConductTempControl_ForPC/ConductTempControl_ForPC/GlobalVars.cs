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
        public enum ParameterNames_t
        {
            TempSet = 0,
            TempCorrect,
            LeadAdjust,
            Fuzzy,
            Ratio,
            Integral,
            Power,
            Fluctation
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
    }
}
