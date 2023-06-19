using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;

namespace p_payment_service
{
    public partial class MainCykel : Form
    {
        public static  ApiObjects objects;
        public static FlowLayoutPanel categoryPanel;
        public static FlowLayoutPanel productPanel;
        public static PictureBox storeLogoPicture;
        public static Label storeBaseName;
        public static String Currency = "kr";
        public static Label cartTotalLabel;

        public static CartItem cartItem = new CartItem();

        public MainCykel()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            cartItem.ItemChanged += CartItem_ItemChanged;
            cartItem.ItemAdded += CartItem_ItemAdded;
            cartItem.ItemsCleared += CartItem_ItemsCleared;
            
            try
            {
                categoryPanel = categoryFlowPanel;
                productPanel = itemFlowPanel;
                storeLogoPicture = formStoreLogo;
                storeBaseName = storeName;
                cartTotalLabel = totalLabel;
                calculateCartTotal();
                apiRequest req = new apiRequest();
                //req.apiUrl = "http://terminal.plife.loc/";
                req.apiUrl = "https://terminal.plife.se/";
                //req.apiUrl = "http://apitest.plife.loc/";
                req.publicKey = "wwe";
                req.privateKey = "zz";
                var apiString = req.getAll();
                objects = JsonSerializer.Deserialize<ApiObjects>(apiString);
                Console.WriteLine($"Person's settings storename: {objects.settings.storeName}");
                StoreBuilder storeBuilder = new StoreBuilder();
                CategoryBuilder categoryBuilder = new CategoryBuilder();
               
            } catch
            {
                Console.WriteLine("error");
            }
        }

        private void CartItem_ItemChanged(object sender, ItemChangedEventArgs e)
        {
            List<Item> changedItems = e.ChangedItems;

            // Handle the changed items
            /*
            foreach (Item item in changedItems)
            {
                Console.WriteLine("Item changed: " + item.Name);
            }
            */
            calculateCartTotal();
        }

        private void CartItem_ItemAdded(object sender, ItemAddedEventArgs e)
        {
            //Item addedItem = e.AddedItem;
            // Handle the added item
            //Console.WriteLine("Item added: " + addedItem.Name);
            calculateCartTotal();
        }
        public static void calculateCartTotal()
        {
            decimal totalValue = cartItem.CalculateTotal();
            cartTotalLabel.Text = totalValue.ToString()+" "+Currency;
        }
        /*
        public  void calculateCartTotal()
        {
            decimal totalValue = cartItem.CalculateTotal();
            totalLabel.Text = totalValue.ToString();
        }
        */
        private void CartItem_ItemsCleared(object sender, EventArgs e)
        {
            totalLabel.Text = "0";
        }

        private void bottomPanelCover_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cartItem.ClearItems();
        }

      
        private void bottomPanelMiddle_Click(object sender, EventArgs e)
        {
            ShowCart();
        }

        private void totalLabel_Click(object sender, EventArgs e)
        {
            ShowCart();
        }

        private void itemFlowPanel_Paint(object sender, PaintEventArgs e)
        {

        }
        public void ShowCart()
        {
            if (!Cart.is_active)
            {
                Cart cart = new Cart();
                cart.Owner = MainCykel.ActiveForm;
                cart.Show();
                Cart.is_active = true;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ShowCart();
        }

        private void button1_Click_2(object sender, EventArgs e)
        {

        }
    }
}
