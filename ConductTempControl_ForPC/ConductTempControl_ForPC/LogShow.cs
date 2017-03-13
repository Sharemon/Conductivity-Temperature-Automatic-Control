using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ConductTempControl_ForPC
{
    public partial class LogShow : Form
    {
        public LogShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Convert log file name to date & time
        /// </summary>
        /// <param name="filename">File name</param>
        /// <returns>Date and time as string</returns>
        string Name2Time(string filename)
        {
            // Insert ':' between hour, minute and second
            filename = filename.Insert(13, ":");
            filename = filename.Insert(11, ":");

            // Insert '/' between yeat, month and day
            filename = filename.Insert(6, "/");
            filename = filename.Insert(4, "/");

            filename = filename.Replace('_', ' ');

            return filename;
        }

        /// <summary>
        /// Convert data & time to file name
        /// </summary>
        /// <param name="time">Date and time</param>
        /// <returns>File name</returns>
        string Time2Name(string time)
        {
            time = time.Replace(":", "");
            time = time.Replace(" ", "_");
            time = time.Replace("/", "");

            return time;
        }

        private void LogShow_Load(object sender, EventArgs e)
        {
            Data2File.CheckDirs();

            string[] filenames = Directory.GetFiles(Data2File.GetOperFolder());
            foreach(string filename in filenames)
            {
                LstLogs.Items.Add(Name2Time(Path.GetFileNameWithoutExtension(filename)));
            }
        }

        private void LstLogs_DoubleClick(object sender, EventArgs e)
        {
            string selected = LstLogs.SelectedItem as string;
            if(selected == null || selected == "")
            {
                return;
            }

            using (StreamReader sr = new StreamReader
                (Data2File.GetOperFolder() + "\\" + Time2Name(selected) + ".log"))
            {
                TxtLog.Text = sr.ReadToEnd();
            }
        }
    }
}
