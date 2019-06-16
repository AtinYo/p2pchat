using System;
using System.IO;
using System.Text;

namespace Core.Logger
{
    public static class Logger
    {
        private static StreamWriter logWriter = null;
        private static string timeStr = null;
        private static StringBuilder strBuilder = null;
        private static string seperate = "----------------------------------------------------";
        static Logger()
        {
            InitLogWriter();
        }

        private static void InitLogWriter()
        {
            string nowTimeStr = DateTime.Now.ToString("yyyy_MM_dd");
            var logPath = "log/";
            var logFileName = "log/log_" + nowTimeStr + ".txt";
            if (!File.Exists(logFileName))             //是否存在   
            {
                Directory.CreateDirectory(logPath);   //创建文件夹   
                logWriter = File.CreateText(logFileName);
            }
            else
            {
                logWriter = File.AppendText(logFileName);
            }

            timeStr = "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "]\t";

            strBuilder = new StringBuilder(512);
        }

        public static string getStr(bool line, params string[] strList)
        {
            if (strBuilder == null || strList == null)
                return null;
            strBuilder.Remove(0, strBuilder.Length);
            for (int i = 0; i < strList.Length; i++)
            {
                if (line)
                    strBuilder.AppendLine(strList[i]);
                else
                    strBuilder.Append(strList[i]);
            }
            return strBuilder.ToString();
        }

        public static void Log(Exception e)
        {
            if (e == null || logWriter == null)
                return;
            logWriter.WriteLine(getStr(true, seperate, timeStr, e.ToString(), seperate));
            logWriter.Flush();
        }

        public static void Log(params string[] strList)
        {
            if (logWriter == null)
                return;
            logWriter.WriteLine(getStr(true, strList));
            logWriter.Flush();
        }
    }
}
