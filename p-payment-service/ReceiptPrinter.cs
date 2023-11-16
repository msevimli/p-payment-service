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
using System.Security.Policy;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace p_payment_service
{
    public class ReceiptPrinter
    {
        public static VivaTerminal.Transaction r { get; set; }
        public  string PaymentMethod { get; set; }
        private LogWriter _log = new LogWriter();
        public static int orderNo = 0;
        public ReceiptPrinter(VivaTerminal.Transaction req, string paymentMethod, int order_no)
        {
            r = req;
            PaymentMethod = paymentMethod;
            orderNo = order_no;
        }

        public async Task printCustomerReceipt()
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
           
            // Initialize variables for positioning text
            float yPos = 10; // Start Y-position
            float lineSpacing = 15; // Space between lines

            Font receiptFont = new Font("Arial", 9);
        
            string orderNoReceipt = "#Order No:" + orderNo;
            e.Graphics.DrawString(orderNoReceipt, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position
            string separator = "------------------------------------------------------";
            e.Graphics.DrawString(separator, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            // Print merchant name and separator
            string merchantName = Properties.Settings.Default.MerchantName;
            e.Graphics.DrawString(merchantName, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position
            e.Graphics.DrawString(separator, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string rTransactionDate = "Date : " + r.TransactionDateTime;
            e.Graphics.DrawString(rTransactionDate, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string rType = "Tid: " +r.Tid;
           e.Graphics.DrawString(rType, receiptFont, Brushes.Black, 10, yPos);
           yPos += lineSpacing; // Increment Y-position

            string rTerminalID = "TerminalId : " + r.TerminalId;
            e.Graphics.DrawString(rTerminalID, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position


            string rMerchantID = "MerchantId : " + Properties.Settings.Default.merchantId;
            e.Graphics.DrawString(rMerchantID, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string orderCode = "orderCode : " + r.OrderCode;
            e.Graphics.DrawString(orderCode, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string rauthorizationId = "authorizationId : " + r.AuthorizationId;
            e.Graphics.DrawString(rauthorizationId, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string transactionId = "transactionId : " + r.TransactionId;
            e.Graphics.DrawString(transactionId, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string applicationLabel = "Application : " + r.ApplicationLabel;
            e.Graphics.DrawString(applicationLabel, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string primaryAccountNumberMasked = "Masked : " + r.PrimaryAccountNumberMasked;
            e.Graphics.DrawString(primaryAccountNumberMasked, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string rAmount ="Amount: " + ((double)r.Amount / 100).ToString() + " " + Properties.Settings.Default.Currency;
           e.Graphics.DrawString(rAmount, receiptFont, Brushes.Black, 10, yPos);
           yPos += lineSpacing; // Increment Y-position

           string rTipAmount ="Tip Amount :" + r.TipAmount.ToString() + " " + Properties.Settings.Default.Currency;
           e.Graphics.DrawString(rTipAmount, receiptFont, Brushes.Black, 10, yPos);
           yPos += lineSpacing; // Increment Y-position

            string rCurrency = "Currency Code: " +r.CurrencyCode.ToString();
            e.Graphics.DrawString(rCurrency, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string verificationMethod = "VerificationMethod : " + r.VerificationMethod;
            e.Graphics.DrawString(verificationMethod, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string referenceNumber = "ReferenceNo : " + r.ReferenceNumber;
            e.Graphics.DrawString(referenceNumber, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position

            string message =  r.Message;
            e.Graphics.DrawString(message, receiptFont, Brushes.Black, 10, yPos);
            yPos += lineSpacing; // Increment Y-position


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
           // Properties.Settings.Default.OrderNo++;

        }

        public async Task printViaBluetooth()
        {
            ThermalPrinter printer = new ThermalPrinter(Properties.Settings.Default.PrinterPort, 9600); // Adjust COM port and baud rate as needed
            Receipt receipt = new Receipt(printer);
            //receipt.AddHeader("My Store", "123 Main St");
            receipt.AddSeparator();
            receipt.AddDate(DateTime.Now);
            //receipt.AddOrderNo(Properties.Settings.Default.OrderNo);
            receipt.AddOrderNo(orderNo);
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

        public async Task printZReport(VivaTerminal.OrderZReport orderZReport)
        {
            ThermalPrinter printer = new ThermalPrinter(Properties.Settings.Default.PrinterPort, 9600); // Adjust COM port and baud rate as needed
            Receipt receipt = new Receipt(printer);
            //receipt.AddHeader("My Store", "123 Main St");
            receipt.AddSeparator();
            receipt.AddNewLine("Date :" + orderZReport.Date);
            receipt.AddNewLine("Merchant Name : " + orderZReport.MerchantName);
            receipt.AddNewLine("Merchant Id : " + orderZReport.MerchantId);
            receipt.AddNewLine("Terminal Id : " + orderZReport.TerminalId);
            receipt.AddNewLine("Currency Code : " + orderZReport.CurrencyCode);
            receipt.AddNewLine("Total Order : " + orderZReport.OrderCount.ToString());
            receipt.AddNewLine("Order Total Amount : " + orderZReport.TotalAmount.ToString() + " " + Properties.Settings.Default.Currency);
           
            receipt.AddSeparator();
        
            receipt.AddSeparator();
            receipt.Print();
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
                    try
                    {
                        _serialPort.ReadTimeout = 1000; // 1 second read timeout
                        _serialPort.WriteTimeout = 1000; // 1 second write timeout
                        _serialPort.Open();
                        _serialPort.Write(data, 0, data.Length);
                        //_serialPort.Close();
                    } catch (Exception ex)
                    {
                        _log.LogWrite(ex.ToString(), "printerWrite");
                    }
                   
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
