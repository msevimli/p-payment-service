using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myPOS;

namespace p_payment_service
{
    public partial class Checkout : Form
    {
      
       

        public Checkout()
        {
            InitializeComponent();
            MainCykel.terminal.ProcessingFinished += ProcessResult;
            InitializeLanguage();
        }

        private void Checkout_FormClosed(object sender, FormClosedEventArgs e)
        {
            Cart.is_active = false;
        }

        private void backToCart_Click(object sender, EventArgs e)
        {
            this.Close();
            Cart cart = new Cart();
            cart.Owner = MainCykel.ActiveForm;
            cart.Show();
            Cart.is_active = true;
        }

        private void bankCard_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void takeAway_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            

        }

        private void payButton_Click(object sender, EventArgs e)
        {

            //terminal.SetReceiptMode((ReceiptMode)cmbReceiptMode.SelectedItem);
            RequestResult r = MainCykel.terminal.Purchase(0.1, myPOS.Currencies.EUR, "");
            switch (r)
            {
                case RequestResult.Processing:
                case RequestResult.Busy:
                case RequestResult.InvalidParams:
                case RequestResult.NotInitialized:
                    MessageBox.Show("RequestResult: " + r.ToString());
                    break;
                default: break;
            }

        }
        protected void ProcessResult(ProcessingResult r)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("Processing \"{0}\" finished\r\n", r.Method.ToString());
            sb.AppendFormat("Status: \"{0}\"\r\n", r.Status.ToString());
            
           
            if (r.TranData != null)
            {
                sb.AppendFormat("\r\nTransaction data:\r\n");
                sb.AppendFormat("Type: {0}\r\n", r.TranData.Type);
                sb.AppendFormat("Amount: {0}\r\n", r.TranData.Amount);
                sb.AppendFormat("Tip Amount: {0}\r\n", r.TranData.TipAmount);
                sb.AppendFormat("Currency: {0}\r\n", r.TranData.Currency.ToString());
                sb.AppendFormat("Approval: {0}\r\n", r.TranData.Approval);
                sb.AppendFormat("Auth code: {0}\r\n", r.TranData.AuthCode);
                sb.AppendFormat("Preauth Code: {0}\r\n", r.TranData.PreauthCode);
                sb.AppendFormat("RRN: {0}\r\n", r.TranData.RRN);
                sb.AppendFormat("Date: {0}\r\n", r.TranData.TransactionDate.ToString("dd.MM.yyyy"));
                sb.AppendFormat("Time: {0}\r\n", r.TranData.TransactionDate.ToString("HH:mm:ss"));
                sb.AppendFormat("Terminal ID: {0}\r\n", r.TranData.TerminalID);
                sb.AppendFormat("Merchant ID: {0}\r\n", r.TranData.MerchantID);
                sb.AppendFormat("Merchant Name: {0}\r\n", r.TranData.MerchantName);
                sb.AppendFormat("Merchant Address Line 1: {0}\r\n", r.TranData.MerchantAddressLine1);
                sb.AppendFormat("Merchant Address Line 2: {0}\r\n", r.TranData.MerchantAddressLine2);
                sb.AppendFormat("PAN Masked: {0}\r\n", r.TranData.PANMasked);
                sb.AppendFormat("Emboss Name: {0}\r\n", r.TranData.EmbossName);
                sb.AppendFormat("AID: {0}\r\n", r.TranData.AID);
                sb.AppendFormat("AID Name: {0}\r\n", r.TranData.AIDName);
                sb.AppendFormat("AID Preferred Name: {0}\r\n", r.TranData.ApplicationPreferredName);
                sb.AppendFormat("STAN: {0}\r\n", r.TranData.Stan);
                sb.AppendFormat("Signature Required: {0}\r\n", r.TranData.SignatureRequired ? "Yes" : "No");
                sb.AppendFormat("Software Version: {0}\r\n", r.TranData.SoftwareVersion);
            }

            
            MessageBox.Show(sb.ToString());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a PrintDocument object
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrinterSettings.PrinterName = "POS-80"; // Replace with the actual printer name

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
        private void InitializeLanguage()
        {
            this.Text = LangHelper.GetString("Checkout");
            backToCart.Text = LangHelper.GetString("Back to Cart");
            payButton.Text = LangHelper.GetString("To Payment");
            paymentOptions.Text = LangHelper.GetString("Payment Options");
            eatHere.Text = LangHelper.GetString("Eat Here");
            takeAway.Text = LangHelper.GetString("Take Away");
            othersButton.Text = LangHelper.GetString("Others");
        }
    }
}
