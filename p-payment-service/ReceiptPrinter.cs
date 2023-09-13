using myPOS;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Management;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace p_payment_service
{
    public class ReceiptPrinter
    {
        public static ProcessingResult r { get; set; }
        public static string PaymentMethod { get; set; }
        private LogWriter _log = new LogWriter();
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
                _log.LogWrite(ex.ToString(), "ReceiptPrinter");
               
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
           
            string orderNo = "#Order No:" + Properties.Settings.Default.OrderNo;
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
            receiptContent += String.Format("{0,-15}{1,-5}{2,15}\n", "Total", "", MainCykel.cartItem.total + " " + MainCykel.Currency);

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
            Properties.Settings.Default.OrderNo++;

        }

        public void printViaBluetooth()
        {
            ThermalPrinter printer = new ThermalPrinter(Properties.Settings.Default.PrinterPort, 9600); // Adjust COM port and baud rate as needed
            Receipt receipt = new Receipt(printer);
            //receipt.AddHeader("My Store", "123 Main St");
            receipt.AddSeparator();
            receipt.AddDate(DateTime.Now);
            receipt.AddOrderNo(MainCykel.cartItem.orderNo);
            receipt.AddServiceMethod(MainCykel.cartItem.serviceMethod);
            receipt.AddSeparator();
            receipt.AddItemHeader("Item", "Qty", "Price");
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
                string itemName = cartItem.Name;
                string total = cartItem.Price * cartItem.Quantity + " " + MainCykel.Currency;
                if (itemName.Length >= 17)
                {
                    // Break line if itemName exceeds 15 characters
                    string[] itemNameLines = SplitStringByLength(itemName, 14);
                    int i = 0;
                    foreach (string itemNameLine in itemNameLines)
                    {
                        if (i == 0)
                        {

                            // receiptContent += String.Format("{0,-15}{1,7}{2,9}{3,12}\n", ilist.ToString() + " - " + itemNameLine, "x" + cartItem.Quantity, cartItem.Price, total);
                            receipt.AddItem(itemNameLine, cartItem.Quantity, Convert.ToDouble(cartItem.Price));
                        }
                        else
                        {
                            receipt.AddNewLine(itemNameLine);
                        }
                        i++;
                    }
                }
                else
                {
                    //receiptContent += String.Format("{0,-15}{1,14}{2,10}{3,12}\n", ilist.ToString() + " - " + itemName, "x" + cartItem.Quantity, cartItem.Price, total);
                    receipt.AddItem(itemName, cartItem.Quantity, Convert.ToDouble(cartItem.Price));
                }
                // Additionals 
                if (cartItem.AdditionalItem.Count > 0)
                {
                   
                    foreach (var option in cartItem.AdditionalItem)
                    {
                        foreach (var additionalOption in option.additionalCartOptions)
                        {
                            receipt.AddSubItem(additionalOption.Name, Convert.ToDouble(additionalOption.Price));
                        }
                    }
                }
               
            }


            receipt.AddSeparator();
            receipt.AddTotal(Convert.ToDouble(MainCykel.cartItem.CalculateTotal()));
            receipt.AddSeparator();
            receipt.AddThankYou();
            receipt.AddSeparator();

            receipt.Print();

            //printer.Close();

        }

        public string[] SplitStringByCharLength(string input, int length)
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

    }


    /* Thermal printer class */

    class ThermalPrinter
    {
        private SerialPort _serialPort;
        private LogWriter _log = new LogWriter();
        private string _comPort;
        private int _baudRate;
        public ThermalPrinter(string comPort, int baudRate)
        {
           
            _comPort = comPort;
            _baudRate = baudRate;
            
        }

        public void Write(string text)
        {
            try
            {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(text);
               // _serialPort.Write(data, 0, data.Length);
                using (SerialPort _serialPort = new SerialPort(_comPort, _baudRate))
                {
                    // Perform serial port operations here
                    _serialPort.Open();
                    _serialPort.Write(data, 0, data.Length);
                    _serialPort.Close();
                }

            } catch(System.InvalidOperationException e)
            {
                _log.LogWrite(e.ToString(),"ReceiptPrinter");
            }
        }

        public void Close()
        {
           // _serialPort.Close();
        }
    }

    class Receipt
    {
        private ThermalPrinter _printer;
        private string _receiptData;

        public Receipt(ThermalPrinter printer)
        {
            _printer = printer;
            _receiptData = "";
        }

        public void AddHeader(string storeName, string address)
        {
            _receiptData +=
                $"{storeName}\n" +
                $"{address}\n";
        }

        public void AddDate(DateTime date)
        {
            _receiptData += $"Date: {date.ToString("yyyy-MM-dd HH:mm:ss")}\n";
        }
        public void AddOrderNo(int OrderNo)
        {
            _receiptData += $"OrderNo: {OrderNo.ToString()}\n";
        }
        public void AddServiceMethod(string serviceMethod)
        {
            _receiptData += $"Service: {serviceMethod}\n";
        }
        public void AddSeparator()
        {
            _receiptData += new string('-', 32) + "\n";
        }

        public void AddItemHeader(string itemLabel, string qtyLabel, string priceLabel)
        {
            _receiptData += $"{itemLabel,-17} {qtyLabel,-4} {priceLabel}\n";
        }

        public void AddItem(string itemName, int qty, double price)
        {
            _receiptData += $"{itemName,-17} {qty,-4} {Properties.Settings.Default.Currency}{price.ToString("0.00")}\n";
        }
        public void AddNewLine(string itemLine)
        {
            _receiptData += $"{itemLine,-17}\n"; 
        }

        public void AddSubItem(string itemName, double price)
        {
            string space = "";
            _receiptData += $"{space,-2}-{itemName,-17} {Properties.Settings.Default.Currency}{price.ToString("0.00")}\n";
        }

        public void AddTotal(double totalAmount)
        {
            _receiptData += $"Total: {totalAmount.ToString("0.00"),22} {Properties.Settings.Default.Currency}\n";
        }

        public void AddThankYou()
        {
            _receiptData += "Thank you for shopping!\n";
        }

        public void Print()
        {
            _printer.Write(_receiptData);
        }
    }

    /* thermal printer class end */


}
