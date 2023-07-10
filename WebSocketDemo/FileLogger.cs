using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace WebSocketDemo
{
    public class FileLogger
    {
        public static void FileWorkerLogToFile(string FileName, string information)
        {
            DateTime localTime = DateTime.Now.ToLocalTime();
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path1 = path + "\\Logs\\";
            if (!Directory.Exists(path1))
                Directory.CreateDirectory(path1);

            string str1 = localTime.ToString("yyyy-MM-dd");
            string path2 = path1 + str1 + "\\";

            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);
            // Guid guid = Guid.NewGuid();
            string str2 = FileName + "_" + localTime.ToString("yyyyMMdd") + ".txt";

            if (!File.Exists(path2 + str2))
            {
                File.WriteAllText(path2 + str2, localTime.ToString("yyyyMMdd_hhmmss") + System.Environment.NewLine + information, Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(path2 + str2, System.Environment.NewLine + localTime.ToString("yyyyMMdd_hhmmss") + System.Environment.NewLine + information, Encoding.UTF8);
            }

            
        }
        public static void SaveHl7ToFile(string FileName, string information)
        {
            DateTime localTime = DateTime.Now.ToLocalTime();
            var path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string path2 = path + "\\HL7\\";
            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);

          
            if (!Directory.Exists(path2))
                Directory.CreateDirectory(path2);
            // Guid guid = Guid.NewGuid();
            string str2 = FileName +Guid.NewGuid() + localTime.ToString("yyyyMMdd") + ".hl7";

            if (!File.Exists(path2 + str2))
            {
                File.WriteAllText(path2 + str2, information, Encoding.UTF8);
            }
            else
            {
                File.AppendAllText(path2 + str2,information, Encoding.UTF8);
            }


        }

    }
}
