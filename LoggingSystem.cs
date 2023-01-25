using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class LoggingSystem
    {
        private static LoggingSystem instance;
        private readonly string logFilePath;

        private LoggingSystem(string logFilePath)
        {
            this.logFilePath = logFilePath;
        }

        public LoggingSystem GetInstance(string logFilePath)
        {
            if (instance == null)
            {
                instance = new LoggingSystem(logFilePath);
            }

            return instance;
        }

        public void LogMessage(string message)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"[{DateTime.Now}] - Message:{message}");
            }
        }

        public void LogError(string error)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"[{DateTime.Now}] - Error: {error}");
            }
        }

        public void LogDebug(string debug)
        {
            using (StreamWriter sw = File.AppendText(logFilePath))
            {
                sw.WriteLine($"[{DateTime.Now}] - Debug: {debug}");
            }
        }
    }
}
