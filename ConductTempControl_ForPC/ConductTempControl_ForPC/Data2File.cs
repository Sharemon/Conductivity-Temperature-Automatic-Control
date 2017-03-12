using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConductTempControl_ForPC
{
    /// <summary>
    /// Save temperature & operation data to file
    /// Temperature data: Data in one day will be saved in a log file, if not forced to create a new one
    /// Operation data: Data for one operation will be saved in a log file, named as current date and time
    /// </summary>
    static class Data2File
    {
        #region Memberes
        private static List<int> paraChangeds = new List<int>();

        private static string operFilePath = "";
        private static string operFolder   = "";
        private static string tempFilePath = "";
        private static string tempFolder   = "";
        private static string myDocPath    = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        private const string appName  = "自动控温系统";
        private const string operName = "操作日志";
        private const string tempName = "温度信息";

        private const string mark   = "* ";
        private const string unmark = "  ";
        #endregion

        #region Methods
        /// <summary>
        /// Create directory for operation and temperature saving
        /// </summary>
        //Todo: Create dirs at the beginning of Main Form
        public static void CheckDirs()
        {
            // Create main directory in "MyDocument"
            if(!Directory.Exists(myDocPath + "\\" + appName))
                Directory.CreateDirectory(myDocPath + "\\" + appName);

            // Create operation directory
            if (!Directory.Exists(myDocPath + "\\" + appName + "\\" + operName))
                Directory.CreateDirectory(myDocPath + "\\" + appName + "\\" + operName);

            // Create temperature directory
            if (!Directory.Exists(myDocPath + "\\" + appName + "\\" + tempName))
                Directory.CreateDirectory(myDocPath + "\\" + appName + "\\" + tempName);

            operFolder = myDocPath + "\\" + appName + "\\" + operName;
            tempFolder = myDocPath + "\\" + appName + "\\" + tempName;
        }


        /// <summary>
        /// Add changed para name(enum) to list which can be marked in operation log file
        /// </summary>
        /// <param name="para">Changed parameter</param>
        public static void AddParaChanged(int para)
        {
            paraChangeds.Add(para);
        }


        /// <summary>
        /// Save operation to log file
        /// </summary>
        /// <param name="old"></param>
        public static void Operation2File(bool old)
        {
            // Create dirs if necessary
            // Already checked at the start of application
            // CheckDirs();

            // If saving old parameters, just save them
            if (old)
            {
                operFilePath = operFolder + "\\" + DateTime.Now.ToString("yyMMdd_HHmmss") + ".log";

                // "using" will automatically CLOSE and DISPOSE the parameter created in bracket
                using (StreamWriter oper = new StreamWriter(operFilePath, false))
                {
                    for (int i = 0; i < GlbVars.paraValues.Length; i++)
                        oper.WriteLine(unmark + GlbVars.paraChNames[i] + "\t\t" + GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]));
                }
            }
            // If saving new parameters, add mark in front of changed value
            else
            {
                using (StreamWriter oper = new StreamWriter(operFilePath, true))
                {
                    oper.WriteLine("\r\n  ->\r\n");

                    for (int i = 0; i < GlbVars.paraValues.Length; i++)
                    {
                        // If parameter(s) is changed, set a mark in front of it.
                        if(paraChangeds.Contains(i))
                            oper.WriteLine(mark + GlbVars.paraChNames[i] + "\t\t" + GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]));
                        else
                            oper.WriteLine(unmark + GlbVars.paraChNames[i] + "\t\t" + GlbVars.paraValues[i].ToString(GlbVars.paraFormat[i]));
                    }
                }

                // Clear changed parameter list 
                paraChangeds.Clear();
            }
        }
        #endregion
    }
}
