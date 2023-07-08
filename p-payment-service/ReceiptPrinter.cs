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
               // MessageBox.Show(GetPortName("USB001"));
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
            DateTime currentDateTime = DateTime.Now;
            string formattedDateTime = currentDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string receiptContent = "Receipt\n";
            receiptContent += "\n";
            receiptContent += "\n" + formattedDateTime + "\n";
            receiptContent += "\n\n\n";
           
            string orderNo = "#Order No: 10";
            Font orderNoFont = new Font("Arial", 9);
            e.Graphics.DrawString(orderNo, orderNoFont, Brushes.Black,1,orderNoFont.GetHeight());
           
            //receiptContent += "\n"+orderNo+"\n";
            receiptContent += String.Format("{0,-15}{1,17}{2,9}{3,15}\n", "Item", "Qty", "Pr","Total");
            receiptContent += "------------------------------------------------------\n";
            //{ 0,-15}: Left - aligned with a width of 15 characters.
            //{ 1,-5}: Left - aligned with a width of 5 characters.
            //{ 2,8}: Right - aligned with a width of 8 characters.
            int ilist = 1;
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
                string itemName = cartItem.Name;
                string total = cartItem.Price * cartItem.Quantity +" "+MainCykel.Currency;
                if (itemName.Length >= 14)
                {
                    // Break line if itemName exceeds 15 characters
                    string[] itemNameLines = SplitStringByLength(itemName, 14);
                    int i = 0;
                    foreach (string itemNameLine in itemNameLines)
                    {
                        if(i == 0 )
                        {
                            
                            receiptContent += String.Format("{0,-15}{1,7}{2,9}{3,12}\n", ilist.ToString() +" - " + itemNameLine, "x"+cartItem.Quantity, cartItem.Price,total);
                        } else
                        {
                            receiptContent += String.Format("{0,-10}\n", itemNameLine);
                        }
                        i++;
                    }
                }
                else
                {
                    receiptContent += String.Format("{0,-15}{1,14}{2,10}{3,12}\n", ilist.ToString() + " - " + itemName, "x"+cartItem.Quantity, cartItem.Price,total);
                }
                // Additionals 
                if (cartItem.AdditionalItem.Count > 0)
                {
                    receiptContent += "Extra : \n ";
                    foreach (var option in cartItem.AdditionalItem)
                    {
                        foreach (var additionalOption in option.additionalCartOptions)
                        {
                            
                            receiptContent += additionalOption.Price + " " + MainCykel.Currency + " - " + additionalOption.Name + "\n";
                        }
                    }
                }
                ilist++;
                receiptContent += "\n";
            }
            receiptContent += "------------------------------------------------------\n";
            receiptContent += String.Format("{0,-15}{1,-5}{2,15}\n", "Total", "", MainCykel.cartItem.total);

            // Set font and brush for printing
            Font font = new Font("Arial", 7);
            Brush brush = Brushes.Black;

            // Calculate the height of a line based on the font size
            float lineHeight = font.GetHeight();

            // Set the position to start printing
            float x = 1;
            float y = 1;

            // Set the printing area height to fit the content
            float printingAreaHeight = e.MarginBounds.Height;

            // Print each line of the receipt until the printing area is filled
            foreach (string line in receiptContent.Split('\n'))
            {
                if (y + lineHeight > printingAreaHeight)
                    break;

                e.Graphics.DrawString(line, font, brush, x, y);
                y += lineHeight;
            }
        }

        static string[] SplitStringByLength(string input, int length)
        {
            List<string> parts = new List<string>();

            for (int i = 0; i < input.Length; i += length)
            {
                if (i + length > input.Length)
                {
                    parts.Add(input.Substring(i));
                }
                else
                {
                    parts.Add(input.Substring(i, length));
                }
            }

            return parts.ToArray();
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
