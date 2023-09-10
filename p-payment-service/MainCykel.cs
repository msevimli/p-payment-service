using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Text.Json;
using myPOS;
using System.Runtime.InteropServices;
using System.Drawing;
using System.Diagnostics;

namespace p_payment_service
{
    public partial class MainCykel : Form
    {
        public static  ApiObjects objects;
        public static FlowLayoutPanel categoryPanel;
        public static FlowLayoutPanel productPanel;
        public static PictureBox storeLogoPicture;
        public static Label storeBaseName;
        public static String Currency = Properties.Settings.Default.Currency;
        public static Label cartTotalLabel;
        public static Label cartItemTotal;
        public static Label activeCategory;

        public static CartItem cartItem = new CartItem();
        //public static myPOSTerminal terminal = new myPOSTerminal();
        public static myPOSTerminal terminal;
        

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
            terminal = new myPOSTerminal();
            formStoreLogo.MouseClick += SettingsFormDetecter_MouseClick;
            terminal.SetLanguage(myPOS.Language.English);
            terminal.SetCOMTimeout(3000);
            terminal.isFixedPinpad = true;
            terminal.Initialize((string)Properties.Settings.Default.PosPort); // This COM number is used as an example
            LangHelper.ChangeLanguage(Properties.Settings.Default.Language);
            Properties.Settings.Default.OrderNo = 1;
            Properties.Settings.Default.Save();
            cartItem.orderNo = 1;
            terminal.SetReceiptMode(ReceiptMode.NoReceipt);
            terminal.GetStatus();
            //terminal.PrintExternal($"\n Order-No: {MainCykel.cartItem.orderNo} \n");

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

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            cartItem.ItemChanged += CartItem_ItemChanged;
            cartItem.ItemAdded += CartItem_ItemAdded;
            cartItem.ItemsCleared += CartItem_ItemsCleared;
            if(Properties.Settings.Default.Debug == false)
            {
                formCloseBtt.Visible = false;
            }
            
            try
            {
                categoryPanel = categoryFlowPanel;
                productPanel = itemFlowPanel;
                storeLogoPicture = formStoreLogo;
                storeBaseName = storeName;
                cartTotalLabel = totalLabel;
                cartItemTotal = cartItemTotalLabel;
                activeCategory = activeCategoryLabel;
                calculateCartTotal();
                apiRequest req = new apiRequest();
                //req.apiUrl = "http://terminal.plife.loc/";
                req.apiUrl = "https://terminal.plife.se/";
                //req.apiUrl = "http://apitest.plife.loc/";
                //req.publicKey = "wwe";
                req.publicKey = (string)Properties.Settings.Default.PublicKey;
                //req.privateKey = "zz";
                req.privateKey = (string)Properties.Settings.Default.PrivateKey;
                var apiString = req.getAll();
                objects = JsonSerializer.Deserialize<ApiObjects>(apiString);
                //Console.WriteLine($"Person's settings storename: {objects.settings.storeName}");
                StoreBuilder storeBuilder = new StoreBuilder();
                CategoryBuilder categoryBuilder = new CategoryBuilder();
                new TouchScroll(categoryFlowPanel,2,20);
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
            if(cartItem.Item.Count < 1 )
            {
                cartItemTotal.Visible = false;
            } else
            {
                cartItemTotal.Visible = true;
                string totalItem = cartItem.Item.Count.ToString() + " " + LangHelper.GetString("item in the cart");
                cartItemTotal.Text = totalItem;
            }
        }

        private void CartItem_ItemsCleared(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => CartItem_ItemsCleared(sender, e)));
                return;
            }
            totalLabel.Text = "0 " +Properties.Settings.Default.Currency;
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
        private void formCloseBtt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            // Show the taskbar when the form is closed
            int hWnd = FindWindow("Shell_TrayWnd", "");
            ShowWindow((IntPtr)hWnd, SW_SHOW);
        }


        public static void RestartApplication()
        {
            string applicationPath = Application.ExecutablePath;
            Process.Start(applicationPath);
            Environment.Exit(0);
        }


        private int clickCount = 0;
        private DateTime lastClickTime = DateTime.MinValue;
        private const int MaxClicks = 3;
        private const int ClickIntervalMilliseconds = 500;

        private void SettingsFormDetecter_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                TimeSpan elapsed = DateTime.Now - lastClickTime;

                if (elapsed.TotalMilliseconds <= ClickIntervalMilliseconds)
                {
                    clickCount++;
                    if (clickCount >= MaxClicks)
                    {
                        // More than double click logic
                        // Perform actions when more than double click occurs
                        if(Login.is_active == false)
                        {
                            Login login = new Login();
                            login.Show();
                        }
                        clickCount = 0; // Reset click count
                    }
                }
                else
                {
                    clickCount = 1;
                }

                lastClickTime = DateTime.Now;
            }
        }

        private void cartItemTotalLabel_Click(object sender, EventArgs e)
        {
            ShowCart();
        }
        public static void exit_system()
        {
            ActiveForm.Close();
        }
    }
}
