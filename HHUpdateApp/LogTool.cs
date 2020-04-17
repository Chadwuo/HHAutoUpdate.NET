using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace HHUpdateApp
{
    public static class LogTool
    {
        static string temp = AppDomain.CurrentDomain.BaseDirectory;
        public static void AddLog(String value)
        {
            Debug.WriteLine(value);
            if (Directory.Exists(Path.Combine(temp, @"HHUpdatelog\")) == false)
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Path.Combine(temp, @"HHUpdatelog\"));
                directoryInfo.Create();
            }
            using (StreamWriter sw = File.AppendText(Path.Combine(temp, @"HHUpdatelog\update.log")))
            {
                sw.WriteLine(value);
            }
        }
    }
}
