using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using myPOS;
using System.Runtime.InteropServices;
using System.Drawing;

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
        public static myPOSTerminal terminal = new myPOSTerminal();

        // Import the necessary functions from the user32.dll library for full screen mode
        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        private static extern int FindWindow(string className, string windowText);

        [DllImport("user32.dll")]
        private static extern int GetSystemMetrics(int nIndex);

        private const int SW_HIDE = 0;
        private const int SW_SHOW = 5;

        public MainCykel()
        {
            InitializeComponent();
            terminal.SetLanguage(myPOS.Language.English);
            terminal.SetCOMTimeout(3000);
            terminal.isFixedPinpad = true;
            terminal.Initialize((string)"COM3"); // This COM number is used as an example
            LangHelper.ChangeLanguage("da-DK");
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // Hide the taskbar
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow((IntPtr)hWnd, SW_HIDE);

            // Set the form to normal state
            WindowState = FormWindowState.Normal;

            // Adjust the form bounds to cover the entire screen
            Rectangle screenBounds = Screen.PrimaryScreen.Bounds;
            Bounds = screenBounds;

            // Set the form as topmost to ensure it overlays the taskbar
            //TopMost = true;
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

           
            label1.Text = LangHelper.GetString("World");
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
                //Console.WriteLine($"Person's settings storename: {objects.settings.storeName}");
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

        private void MainCykel_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Show the taskbar when the form is closed
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow((IntPtr)hWnd, SW_SHOW);
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Show the taskbar when the form is closed
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow((IntPtr)hWnd, SW_SHOW);
        }

        private void button1_Click_3(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
