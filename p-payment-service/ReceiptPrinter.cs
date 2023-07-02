using myPOS;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    public class ReceiptPrinter
    {
        public static ProcessingResult r { get; set; }
        public static string PaymentMethod { get; set; }
        public ReceiptPrinter(ProcessingResult req, string paymentMethod)
        {
            r = req;
            PaymentMethod = paymentMethod;
        }

        public void printCustomerReceipt()
        {
            try
            {
                // Create a PrintDocument object
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = Properties.Settings.Default.PrinterName; // Replace with the actual printer name
                //printDocument.PrinterSettings.PrinterName = "BlueTooth Printer"; // Replace with the actual printer name

                //printDocument.PrinterSettings.PrinterName = GetPortName("USB001"); // Replace with the actual port name


                // Set the print controller to suppress the print dialog box
                printDocument.PrintController = new StandardPrintController();

                // Hook up event handlers for printing
                printDocument.PrintPage += PrintDocument_PrintPage;
                printDocument.EndPrint += PrintDocument_EndPrint;

                // Start printing
                printDocument.Print();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            Console.WriteLine("Printing complete. Press any key to exit.");
        }
        string GetPortName(string port)
        {

            string query = string.Format("SELECT * FROM Win32_Printer WHERE PortName LIKE '%{0}%'", port);
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher(query))
            {
                foreach (ManagementObject printer in searcher.Get())
                {
                    string printerName = printer["Name"].ToString();
                    return printerName;
                }
            }

            throw new Exception("Printer not found for the specified port.");

        }
        static void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            // Prepare the receipt content
            string receiptContent = "Receipt\n\n";
            receiptContent += "---------------------------\n";
            receiptContent += "Item\t\tPrice\n";
            receiptContent += "---------------------------\n";
            receiptContent += "Product 1\t$10.00\n";
            receiptContent += "Product 2\t$15.00\n";
            receiptContent += "---------------------------\n";
            receiptContent += "Total\t\t$25.00\n";

            // Set font and brush for printing
            Font font = new Font("Arial", 12);
            Brush brush = Brushes.Black;

            // Calculate the height of a line based on the font size
            float lineHeight = font.GetHeight();

            // Set the position to start printing
            float x = 1;
            float y = 1;

            // Print each line of the receipt
            foreach (string line in receiptContent.Split('\n'))
            {
                e.Graphics.DrawString(line, font, brush, x, y);
                y += lineHeight;
            }
        }

        static void PrintDocument_EndPrint(object sender, PrintEventArgs e)
        {
            // Dispose of any resources after printing is complete
            ((PrintDocument)sender).Dispose();

        }


        public void printBlueTooth()
        {
            // Create a new instance of the SerialPort class

            SerialPort serialPort = new SerialPort(Properties.Settings.Default.PrinterPort, 9600);

            try
            {
                // Open the serial port connection
                serialPort.Open();

                // Set the necessary parameters for the Bluetooth thermal printer
                serialPort.DtrEnable = true;
                serialPort.RtsEnable = true;
                serialPort.Handshake = Handshake.None;
                serialPort.Parity = Parity.None;
                serialPort.DataBits = 8;
                serialPort.StopBits = StopBits.One;

                // Write the string to the serial port
                string textToPrint = "Hello, World!";
                // Prepare the receipt content
                string receiptContent = "Receipt\n\n";
                receiptContent += "---------------------------\n";
                receiptContent += "Item\t\tPrice\n";
                receiptContent += "---------------------------\n";
                receiptContent += "Product 1\t$10.00\n";
                receiptContent += "Product 2\t$15.00\n";
                receiptContent += "---------------------------\n";
                receiptContent += "Total\t\t$25.00\n";

                serialPort.Write(receiptContent);

                System.Threading.Thread.Sleep(2000);

                // Close the serial port connection
                serialPort.Close();

                Console.WriteLine("String printed successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
            finally
            {
                // Make sure to close the serial port connection in case of any exceptions
                if (serialPort.IsOpen)
                    serialPort.Close();
            }

        }
    }
    
}
