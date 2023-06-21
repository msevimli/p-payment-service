using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        myPOSTerminal terminal = new myPOSTerminal();
       

        public Checkout()
        {
            InitializeComponent();
            terminal.ProcessingFinished += ProcessResult;
            terminal.SetLanguage(Language.English);
            RequestResult r = terminal.Activate();
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
            terminal.Initialize((string)"COM3"); // This COM number is used as an example

        }

        private void payButton_Click(object sender, EventArgs e)
        {

            //terminal.SetReceiptMode((ReceiptMode)cmbReceiptMode.SelectedItem);
            RequestResult r = terminal.Purchase(0.1, myPOS.Currencies.EUR, "");


        }
        protected void ProcessResult(ProcessingResult r)
        {
            // handle the response here
            if (r.TranData != null)
            {
                // transaction response
                Console.WriteLine(r);
            }
        }

    }
}
