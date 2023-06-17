using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace p_payment_service
{
    public partial class Cart : Form
    {
        public Cart()
        {
            InitializeComponent();
        }

        private void Cart_Load(object sender, EventArgs e)
        {
            initCartDetails();
        }

        public void initCartDetails()
        {
            MainCykel.cartItem.ItemAdded += CartItem_ItemAdded;
            cartDetailsPanel.Controls.Clear();
            foreach (Item cartItem in MainCykel.cartItem.Item)
            {
                Panel pane = new Panel();
                pane.Width = 750;
                pane.Height = 100;
                pane.BackColor = Color.White;
                pane.BorderStyle = BorderStyle.FixedSingle;
                Label label = new Label();

                // Set properties of the Label
                label.Text = cartItem.Name;
                //label.Dock = DockStyle.Bottom;
                //label.TextAlign = ContentAlignment.MiddleCenter;

                // Set the background color and text color
                label.ForeColor = Color.Black;
                pane.Controls.Add(label);
                cartDetailsPanel.Controls.Add(pane);

            }
        }

        private void CartItem_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            Item addedItem = e.AddedItem;

            // Handle the added item
            Console.WriteLine("Item added-cart: " + addedItem.Name);
            initCartDetails();
        }

        private void cartDetailsPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
