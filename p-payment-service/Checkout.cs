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
using System.Net.Http;
using static p_payment_service.VivaTerminal;
using System.Data.SqlTypes;

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
          //  MainCykel.terminal.ProcessingFinished += ProcessResult;
           // MainCykel.terminal.onCardDetected += DetectedUserCart;
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
            
            if(Properties.Settings.Default.Debug)
            {
                cartTotal = 1;
            }

            _ = TerminalPayment(cartTotal, orderNo);
        }

        public async Task PrintOrderNoToScreen(int orderNo)
        {
           
            string orderNotify = "#order-no : " + orderNo.ToString() + LangHelper.GetString("OrderInfo");
            orderNotifyLabel.Invoke((Action)(() => {
                orderNotifyLabel.Text = orderNotify;
                orderNotifyLabel.Dock = DockStyle.Fill;
                orderNotifyLabel.Visible = true;
            }));
           
        }

        public async Task CloseCheckoutForm()
        {
            await Task.Delay(5000);
            //this.Close();
            try
            {
                ActiveForm.Invoke((Action)(() => {
                    this.Close();
                }));
            } catch(System.NullReferenceException)
            {
                //throw;
                return;
            }
          
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

        public async Task completeTransaction(Transaction _transaction, int orderNo)
        {
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(_transaction, "card", orderNo);
            
            await receiptPrinter.printReceipt("viaNetwork");
            await receiptPrinter.printCustomerReceipt();

            apiRequest req = new apiRequest();
            _ = req.SubmitOrderToApiAsync(_transaction,orderNo);

            MainCykel.cartItem.ClearItems();
            /*
            MainCykel.cartItemTotal.Invoke((Action)(() => {
                MainCykel.cartItemTotal.Visible = false;
            }));
            */
            Properties.Settings.Default.OrderNo++;

        }

        public void printRecipt()
        {
            ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "cash",0);
            receiptPrinter.printCustomerReceipt();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
           // ReceiptPrinter receiptPrinter = new ReceiptPrinter(null,"card",0);
            //receiptPrinter.printBlueTooth();
           // receiptPrinter.printCustomerReceipt();
            //receiptPrinter.printBlueTooth();
            // receiptPrinter.printViaBluetooth();
            //completeOrder();
           // _= PrintOrderNoToScreen(MainCykel.cartItem.orderNo);

            //apiRequest req = new apiRequest();
            //await  req.SubmitOrderToApiAsync();
            
            //VivaTerminal terminal = new VivaTerminal();
            //await terminal.getOrderZReport();

            ReceiptPrinter pr = new ReceiptPrinter(null, "card", 0);
            
            _= pr.printReceipt("viaNetwork");
           // receiptPrinter.printReceipt("viaBluetooth");


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

            //ReceiptPrinter receiptPrinter = new ReceiptPrinter(null, "card",0);
            //receiptPrinter.printViaBluetooth();

            double amount = 7.32;
            _ = TerminalPayment(amount,Properties.Settings.Default.OrderNo);

            
        }
        async Task TerminalPayment(double amount,int orderNo)
        {
            
            VivaTerminal terminal = new VivaTerminal();

            try
            {
      
                showImageIndicator("terminal");
                DisableControls();
                Transaction transaction = await terminal.MakeSalesRequest(amount,orderNo);
                //Console.WriteLine("API Response: " + transaction.ToString());
                if(transaction.Success)
                {
                    showImageIndicator("done");
                    await Task.Delay(2000);
                    _ = PrintOrderNoToScreen(orderNo);
                    await completeTransaction(transaction, orderNo);
                    _ = CloseCheckoutForm();
                }
                else
                {
                    showImageIndicator("cancel");
                    await Task.Delay(2000);
                    EnableControls();
                    _ = ImageIndicatorReset();
                }

                // string apiResponse = await terminal.RunTransactionStatusCheck();
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine("Error: " + e.Message);
                LogWriter _log = new LogWriter();
                _log.LogWrite(e.Message, "TerminalPayment Error: ");
            }
        }

    }
}
