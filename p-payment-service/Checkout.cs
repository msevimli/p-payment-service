using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace p_payment_service
{
    public partial class Checkout : Form
    {
        public Checkout()
        {
            InitializeComponent();
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
        
    }
}
