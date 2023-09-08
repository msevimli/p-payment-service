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

namespace p_payment_service
{
    public partial class Checkout : Form
    {
      
       

        public Checkout()
        {
            InitializeComponent();
            MainCykel.terminal.ProcessingFinished += ProcessResult;
            MainCykel.terminal.onCardDetected += DetectedUserCart;

            cashPay.Visible = false;
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
        private void eatHereChecked_Changed(object sender, EventArgs e)
        {

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
            //terminal.SetReceiptMode((ReceiptMode)cmbReceiptMode.SelectedItem);
            RequestResult r = MainCykel.terminal.Purchase(1, myPOS.Currencies.DKK, "");
           // RequestResult r = MainCykel.terminal.Purchase(1, myPOS.Currencies.EUR, "");
           
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

            // Access the image from the resource
            ResourceManager rm = new ResourceManager(typeof(Properties.Resources));
            Image image = (Image)rm.GetObject("terminal-blue"); // Replace "imageName" with the actual name of your resource image

            // Display the image in a PictureBox control
            statusImage.Image = image;
            statusImage.SizeMode = PictureBoxSizeMode.Zoom; // Set the desired image display mode
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
            if (r.Method.ToString() == "PURCHASE" )
            {
                switch (r.Status.ToString())
                {
                    case "UserCancel":
                        showImageIndicator("cancel");
                        EnableControls();
                        break;
                    case "InternalError":
                        showImageIndicator("cancel");
                        EnableControls();
                        break;
                    case "Success":
                        showImageIndicator("done");
                        completeOrder();
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
        
        protected void DetectedUserCart(bool is_bad_card)
        {
            showImageIndicator("load");
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
                    Image imageCancel = (Image)rm.GetObject("canceled");
                    statusImage.Image = imageCancel;
                    break;
                case "done":
                    Image imageDone = (Image)rm.GetObject("checkmark");
                    statusImage.Image = imageDone;
                    break;
                case "reset":
                    Image whiteBackground = (Image)rm.GetObject("white-background.jpg");
                    statusImage.Image = whiteBackground;
                    break;
            }
            
            statusImage.SizeMode = PictureBoxSizeMode.Zoom; // Set the desired image display mode
        }
        public void completeOrder()
        {
            LogWriter _log = new LogWriter();
            _log.LogWrite(Properties.Settings.Default.OrderNo.ToString(), "before_change_order_no");
            Properties.Settings.Default.OrderNo = Properties.Settings.Default.OrderNo + 1;
            Properties.Settings.Default.Save();
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "card");
            receiptPrinter.printViaBluetooth();
            MainCykel.cartItem.ClearItems();
            //this.Close();
            _log.LogWrite(Properties.Settings.Default.OrderNo.ToString(),"after_change_order_no");
            MainCykel.cartItem.orderNo = Properties.Settings.Default.OrderNo;
        }

        public void printRecipt()
        {
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "cash");
            receiptPrinter.printCustomerReceipt();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //ReceiptPrinter receiptPrinter = new ReceiptPrinter(null,"card");
            //receiptPrinter.printBlueTooth();
            //receiptPrinter.printCustomerReceipt();
            //receiptPrinter.printBlueTooth();
            // receiptPrinter.printViaBluetooth();
            completeOrder();

        
        }

        private void InitializeLanguage()
        {
            this.Text = LangHelper.GetString("Checkout");
            backToCart.Text = LangHelper.GetString("Back to Cart");
            payButton.Text = LangHelper.GetString("To Payment");
            paymentOptions.Text = LangHelper.GetString("Payment Options");
            eatHere.Text = LangHelper.GetString("Eat Here");
            takeAway.Text = LangHelper.GetString("Take Away");
            //othersButton.Text = LangHelper.GetString("Others");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
    }
}
