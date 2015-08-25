using System;
using System.IO;

namespace ldj
{
    public static class TraceLog
    {
        public const string GLOBALLOG = "Global_log.txt";
        public const string strLogFile = "zhuanli.log";

        public static void Print(string filename, string msg)
        {
            DateTime dt = System.DateTime.Now.ToLocalTime();
            string str = string.Format("[{0}]: ", dt);

            WriteToConsole(str, msg, ConsoleColor.Gray, ConsoleColor.Green);

            WriteToLogFile(str);
            WriteToLogFile( msg + "\r\n");
        }

        public static void Error(string filename, string msg)
        {
            DateTime dt = System.DateTime.Now.ToLocalTime();
            string str = string.Format("[{0}]: {1}", dt, msg);

            WriteToConsole(str, ConsoleColor.Red);
            WriteToLogFile(str + "\r\n");
        }

        private static void WriteToConsole(string msg, ConsoleColor color)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            lock (typeof(Console))
            {
                Console.ForegroundColor = color;
                Console.WriteLine(msg);
                Console.ForegroundColor = consoleColor;
            }
        }

        private static void WriteToConsole(string time, string msg, ConsoleColor timecolor, ConsoleColor msgcolor)
        {
            ConsoleColor consoleColor = Console.ForegroundColor;
            lock (typeof(Console))
            {
                Console.ForegroundColor = timecolor;
                Console.Write(time);
                Console.ForegroundColor = msgcolor;
                Console.WriteLine(msg);
                Console.ForegroundColor = consoleColor;
            }
        }

        #region WriteToLogFile
        public static void WriteToLogFile(string strWrite)
        {
            if (string.IsNullOrEmpty(strWrite))
            {
                return;
            }
            string strLogFileFullName;
            string strYear, strMonth, strDay;
            strYear = DateTime.Now.Year.ToString();
            strMonth = DateTime.Now.Month.ToString();
            strDay = DateTime.Now.Day.ToString();
            if (strMonth.Length == 1) strMonth = "0" + strMonth;
            if (strDay.Length == 1) strDay = "0" + strDay;
            if(!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "log"))
            {
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "log");
            }
            strLogFileFullName = AppDomain.CurrentDomain.BaseDirectory + "log\\" + strYear + strMonth + strDay + strLogFile;
            StreamWriter myWriter = null;
            try
            {
                myWriter = new StreamWriter(strLogFileFullName, true);
                myWriter.WriteLine(DateTime.Now.ToString()+" "+ strWrite);
                myWriter.Flush();
                myWriter.Close();
            }
            catch { };
        }
        #endregion

    }
}
