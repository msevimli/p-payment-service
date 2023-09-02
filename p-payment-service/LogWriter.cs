using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p_payment_service
{
    internal class LogWriter
    {
        
        public  void LogWrite(string message,string title = "")
        {
            try
            {
                string logFileName = "log.txt"; // Change this to the desired log file name
                string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, logFileName);
                // Open the file for appending
                using (StreamWriter writer = File.AppendText(logFilePath))
                {
                    // Write the log message along with the current date and time
                    string logMessage = $"[{DateTime.Now}] - {title} \n {message}";
                    writer.WriteLine(logMessage);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }
    }
}
