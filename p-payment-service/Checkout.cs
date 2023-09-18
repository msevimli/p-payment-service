using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO.Ports;
using System.Linq;
using System.Resources;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using myPOS;
using System.Management;
using System.Drawing.Imaging;
using System.IO;
using System.CodeDom;
using System.Threading.Tasks;

namespace p_payment_service
{
    public partial class Checkout : Form
    {


        private int orderNo;
        private double cartTotal;
        public Checkout()
        {
            
            InitializeComponent();
            orderNotifyLabel.Visible = false;
            MainCykel.terminal.ProcessingFinished += ProcessResult;
            MainCykel.terminal.onCardDetected += DetectedUserCart;
            orderService.Visible = false;

            cashPay.Visible = false;
            InitializeLanguage();
            MainCykel.cartItem.serviceMethod = "eat-here";
            if(Properties.Settings.Default.Debug)
            {
                button2.Visible = true;
                button1.Visible = true;
            }

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
            MainCykel.cartItem.serviceMethod = "take-away";
        }
        private void eatHereChecked_Changed(object sender, EventArgs e)
        {
            MainCykel.cartItem.serviceMethod = "eat-here";
        }

        private void Checkout_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            

        }

        public void DisableControls()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(DisableControls));
                return;
            }
            payButton.Enabled = false;
            paymentOptions.Enabled = false;
            orderService.Enabled = false;
            backToCart.Enabled = false;
        }
        public void EnableControls()
        {
            // Enable UI controls on the main UI thread
            if (InvokeRequired)
            {
                Invoke(new Action(EnableControls));
                return;
            }

            payButton.Enabled = true;
            paymentOptions.Enabled = true;
            orderService.Enabled = true;
            backToCart.Enabled = true;
        }

        private void payButton_Click(object sender, EventArgs e)
        {

            // Assuming you have a GroupBox named "groupBox1" containing RadioButtons
            DisableControls();

            RadioButton checkedRadioButton = null;

            foreach (RadioButton radioButton in paymentOptions.Controls.OfType<RadioButton>())
            {
                if (radioButton.Checked)
                {
                    checkedRadioButton = radioButton;
                    break;
                }
            }

            if (checkedRadioButton != null)
            {
                string checkedRadioButtonName = checkedRadioButton.Name;
                switch(checkedRadioButtonName)
                {
                    case "bankCard":
                        MainCykel.cartItem.paymentMethod = "bankCard";
                        payWithCart();
                        break;
                    case "cashPay":
                        //printBlueTooth();
                        MainCykel.cartItem.paymentMethod = "cash";
                        printRecipt();
                        //Call the function to add text to the PictureBox.
                        AddCashTextToStatusImage(LangHelper.GetString("PaymentCashMessage"), new Font("Arial", 130), Brushes.MidnightBlue, new Point(250, 750));
                        break;
                }
                //Console.WriteLine("Selected RadioButton: " + checkedRadioButtonText);
            }
            //EnableControls();

        }

        private void AddCashTextToStatusImage(string text, Font font, Brush brush, Point position)
        {
            using (Graphics graphics = Graphics.FromImage(statusImage.Image))
            {
                // Draw the text on the image using the specified font and brush at the given position.
                graphics.DrawString(text, font, brush, position);
            }

            // Refresh the PictureBox to display the updated image with the added text.
            statusImage.Refresh();
        }
        protected void payWithCart()
        {
            orderNo = Properties.Settings.Default.OrderNo;
            MainCykel.cartItem.orderNo = orderNo;
            MainCykel.calculateCartTotal();
            cartTotal =(double)MainCykel.cartItem.total;
            //terminal.SetReceiptMode((ReceiptMode)cmbReceiptMode.SelectedItem);
            //string _ref = "Order No " + MainCykel.cartItem.orderNo.ToString();
            if(Properties.Settings.Default.Debug)
            {
                cartTotal = 1;
            }
            string orderNoText = "orderNo:" + orderNo.ToString();
           // RequestResult r = MainCykel.terminal.Purchase(cartTotal, myPOS.Currencies.DKK, orderNoText);
            RequestResult r = MainCykel.terminal.Purchase(1, myPOS.Currencies.EUR, "");

            switch (r)
            {
                case RequestResult.Processing:
                    showImageIndicator("terminal");
                    break;
                case RequestResult.Busy:
                case RequestResult.InvalidParams:
                case RequestResult.NotInitialized:
                    MessageBox.Show("RequestResult: " + r.ToString());
                    EnableControls();
                    break;
      
          
                default: break;
            }
     
        }

        public void ProcessResult(ProcessingResult r)
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
            if (r.Method.ToString() == "PURCHASE" )
            {
          
                switch (r.Status.ToString())
                {
                    case "UserCancel":
                        showImageIndicator("cancel");
                        EnableControls();
                        //_ = print_customer_copy(sb.ToString());
                        
                        break;
                    case "InternalError":
                        showImageIndicator("cancel");
                        EnableControls();
                        break;
                    case "Success":

                        //MainCykel.terminal.PrintExternal($"\n Order-No: {MainCykel.cartItem.orderNo} \n");
                        // _ = print_customer_copy(r.TranData);
                        //_ = PrintCustomerCopy(r.TranData);
                        _ = PrintOrderNoToScreen(r.TranData,orderNo);
                        //completeOrder();
                        
                        break;
                    case "NoCardFound":
                        showImageIndicator("reset");
                        EnableControls();
                        break;

                    default:
                        showImageIndicator("reset");
                        EnableControls();
                        break;

                }
            }
          
            LogWriter log = new LogWriter();
            log.LogWrite(sb.ToString());
            //MessageBox.Show(sb.ToString());
        }


        public async Task PrintCustomerCopy(TransactionData trData)
        {
            // Delay for 2 seconds (2000 milliseconds)
            await Task.Delay(2000);

            // Create the receipt string using string interpolation
            string receiptData = $@"\L\c
==============
{trData.MerchantName}
==============\l
\l\H ORDER NO: {orderNo}
\l\w\h\n
\l
{trData.MerchantAddressLine1}
\n\l
{trData.MerchantAddressLine2}
\n\lDate: {trData.TransactionDate:dd.MM.yyyy-HH:mm:ss}
\n\l
\lTERMINAL ID: {trData.TerminalID}
MERCHANT ID: {trData.MerchantID}

\W\cPAYMENT\w\h
\l\n\nAMOUNT {trData.Amount} {trData.Currency}
\n\lCard N: {trData.PANMasked}
\n\lSTAN: {trData.Stan} / Auth: {trData.AuthCode}
\n\lRRN: {trData.RRN}
\n\lAID: {trData.AID}
\n\l
\c\h\n
==============
=== THANK YOU! ===
==============

\n\n\n";

            // Print the receipt and get the request result
            RequestResult r = MainCykel.terminal.PrintExternal(receiptData);

            // Check the result
            if (r != RequestResult.Processing)
            {
                // If printing is still processing, recursively call the method
                await PrintCustomerCopy(trData);
            }
            else

            {
                // If printing is not processing, complete the order
                completeOrder();
            }
        }

        public async Task print_customer_copy(TransactionData trData)
        {
            await Task.Delay(2000);
            string receiptData = $"\\L\\c\r\n==============\r\n{trData.MerchantName}\r\n==============\\l\n  \\l\\H ORDER NO: {orderNo.ToString()}\\l\\w\\h\\n  \\l\r\n{trData.MerchantAddressLine1}\n\\l                    \\n\\l{trData.MerchantAddressLine2}\\n\\lDate :{trData.TransactionDate.ToString("dd.MM.yyyy")}-{trData.TransactionDate.ToString("HH:mm:ss")}\\n\\l\n\\lTERMINAL ID:     {trData.TerminalID}\r\nMERCHANT ID:     {trData.MerchantID}\r\n\r\n\\W\\cPAYMENT\\w\\h\r\n\\l\\n\\nAMOUNT         {trData.Amount} {trData.Currency.ToString()}\r\n \\n\\lCard N: {trData.PANMasked} \\n\\lSTAN: {trData.Stan} / Auth: {trData.AuthCode} \\n\\lRRN : {trData.RRN}\\n\\lAID : {trData.AID} \\n\\l   \\c\\h\\n\r\n==============\r\n=== THANK YOU! ===\r\n==============\r\n\\n\\n\\n";
            RequestResult r =  MainCykel.terminal.PrintExternal(receiptData);
           if(r != RequestResult.Processing)
           {
                _ = print_customer_copy(trData);
           }
           //Complete order after print
           if(r == RequestResult.Processing)
           {
                completeOrder();
           }
           

        }
        public async Task PrintOrderNoToScreen(TransactionData trData,int orderNo)
        {
           
            string orderNotify = "#order-no : " + orderNo.ToString() + LangHelper.GetString("OrderInfo");
            orderNotifyLabel.Invoke((Action)(() => {
                orderNotifyLabel.Text = orderNotify;
                orderNotifyLabel.Dock = DockStyle.Fill;
                orderNotifyLabel.Visible = true;
            }));
            completeOrder();
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(trData, "card",orderNo);
            //receiptPrinter.printBlueTooth();
            receiptPrinter.printCustomerReceipt();
            _ = CloseCheckoutForm();
        }
        public async Task CloseCheckoutForm()
        {
            await Task.Delay(5000);
            //this.Close();
            ActiveForm.Invoke((Action)(() => {
                this.Close();
            }));
        }
        protected void DetectedUserCart(bool is_bad_card)
        {
            showImageIndicator("load");
        }
        public async Task ImageIndicatorReset()
        {
            await Task.Delay(2000);
            showImageIndicator("reset");
        }

        public void showImageIndicator(string indicator)
        {
            // Access the image from the resource
            ResourceManager rm = new ResourceManager(typeof(Properties.Resources));
            switch (indicator)
            {
                case "terminal":
                    Image imageTerminal = (Image)rm.GetObject("terminal-blue");
                    statusImage.Image = imageTerminal;
                    break;
                case "load":
                    Image imageLoad = (Image)rm.GetObject("loading");
                    statusImage.Image = imageLoad;
                    break;
                case "cancel":
                    Image imageCancel = (Image)rm.GetObject("cancel-animate");
                    statusImage.Image = imageCancel;
                    statusImage.SizeMode = PictureBoxSizeMode.CenterImage;
                    _ = ImageIndicatorReset();
                    break;
                case "done":
                    Image imageDone = (Image)rm.GetObject("success-animate");
                    // statusImage.Padding = new Padding(10, 10, 10, 10);
                    statusImage.SizeMode = PictureBoxSizeMode.CenterImage;
                    statusImage.Image = imageDone;
                    break;
                case "reset":
                    Image whiteBackground = (Image)rm.GetObject("white_background.jpg");
                    statusImage.Image = whiteBackground;
                    statusImage.SizeMode = PictureBoxSizeMode.Zoom;
                    break;
            }
            
            statusImage.SizeMode = PictureBoxSizeMode.Zoom; // Set the desired image display mode
        }
        public void completeOrder()
        {
            LogWriter _log = new LogWriter();
            _log.LogWrite(Properties.Settings.Default.OrderNo.ToString(), "before_change_order_no");
            if (MainCykel.cartItem.Item.Count > 0)
            {
                ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "card",0);
                receiptPrinter.printViaBluetooth();
               // Properties.Settings.Default.OrderNo = Properties.Settings.Default.OrderNo + 1;
               // Properties.Settings.Default.Save();
                orderNo  = Properties.Settings.Default.OrderNo;
                MainCykel.cartItem.ClearItems();
                MainCykel.cartItemTotal.Invoke((Action)(() => {
                    MainCykel.cartItemTotal.Visible = false;
                }));
                showImageIndicator("done");
               // Properties.Settings.Default.OrderNo = Properties.Settings.Default.OrderNo + 1;
                //Properties.Settings.Default.Save();

                // AddCashTextToStatusImage("Order complated", new Font("Arial", 130), Brushes.MidnightBlue, new Point(250, 750));

            }
            //this.Close();
            _log.LogWrite(Properties.Settings.Default.OrderNo.ToString(),"after_change_order_no");
           // MainCykel.cartItem.orderNo = Properties.Settings.Default.OrderNo;
        }
   
        public void printRecipt()
        {
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "cash",0);
            receiptPrinter.printCustomerReceipt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null,"card",0);
            //receiptPrinter.printBlueTooth();
            receiptPrinter.printCustomerReceipt();
            //receiptPrinter.printBlueTooth();
            // receiptPrinter.printViaBluetooth();
            //completeOrder();
           // _= PrintOrderNoToScreen(MainCykel.cartItem.orderNo);


        }

        private void InitializeLanguage()
        {
            this.Text = LangHelper.GetString("Checkout");
            backToCart.Text = LangHelper.GetString("Back to Cart");
            payButton.Text = LangHelper.GetString("To Payment");
            paymentOptions.Text = LangHelper.GetString("Payment Options");
            eatHere.Text = LangHelper.GetString("Eat Here");
            takeAway.Text = LangHelper.GetString("Take Away");
            //othersButton.Text = LangHelper.GetString("Others");co
        }

        private void button2_Click(object sender, EventArgs e)
        {

            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "card",0);
            receiptPrinter.printViaBluetooth();
        }
    }
}
