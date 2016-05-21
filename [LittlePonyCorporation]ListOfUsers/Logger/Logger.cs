using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logger
{
    public static class Logger
    {
        static private void ReadAndWriteToFileException(Exception e, string logFile)
        {
            if (e.InnerException != null)
            {
                ReadAndWriteToFileException(e.InnerException, logFile);
            }

            StreamWriter stream = new StreamWriter(logFile, true);
            stream.WriteLine("Ошибка: " + e.Message);
            stream.WriteLine("Объект: " + e.Source);
            stream.WriteLine("Метод, вызвавший исключение: " + e.TargetSite);
            stream.WriteLine();
            stream.Close();
        }

        static public void CreateLog(Exception e)
        {
            if (!Directory.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs")))
            {
                Directory.CreateDirectory(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs"));
            }

            string logFile = DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss-ff") + ".txt";
            ReadAndWriteToFileException(e, Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", logFile));
        }
    }
}
