using System;

using System.Windows.Forms;

namespace p_payment_service
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void discardButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void GetSettings()
        {
            passwordBox.Text = Properties.Settings.Default.Password;
            debugModeBox.SelectedItem = Properties.Settings.Default.Debug.ToString();
            deviceNameBox.Text = Properties.Settings.Default.DeviceName;
            languageBox.SelectedItem = Properties.Settings.Default.Language;
            currencyBox.Text = Properties.Settings.Default.Currency;
            publicKeyBox.Text = Properties.Settings.Default.PublicKey;
            privateKeyBox.Text = Properties.Settings.Default.PrivateKey;
            printerNameBox.Text = Properties.Settings.Default.PrinterName;
            printerPortBox.Text = Properties.Settings.Default.PrinterPort;
            posPortBox.Text = Properties.Settings.Default.PosPort;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.Password =passwordBox.Text;
            Properties.Settings.Default.Debug = bool.Parse(debugModeBox.SelectedItem.ToString());
            Properties.Settings.Default.DeviceName = deviceNameBox.Text;
            Properties.Settings.Default.Language = languageBox.SelectedItem.ToString();
            Properties.Settings.Default.Currency = currencyBox.Text;
            Properties.Settings.Default.PublicKey = publicKeyBox.Text;
            Properties.Settings.Default.PrivateKey = privateKeyBox.Text;
            Properties.Settings.Default.PrinterName = printerNameBox.Text;
            Properties.Settings.Default.PosPort = posPortBox.Text;
            Properties.Settings.Default.PrinterPort = printerPortBox.Text;
            Properties.Settings.Default.Save();
            this.Close();
            MainCykel.RestartApplication();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            GetSettings();
        }

        private void showPass_Click(object sender, EventArgs e)
        {
            bool isPasswordChar = passwordBox.UseSystemPasswordChar; 
            if (isPasswordChar)
            {
                passwordBox.UseSystemPasswordChar = false;
                showPass.Text = "Hide";
            } else
            {
                passwordBox.UseSystemPasswordChar = true;
                showPass.Text = "Show";
            }
        }

        private void showPrivate_Click(object sender, EventArgs e)
        {
            bool isPasswordChar = privateKeyBox.UseSystemPasswordChar;
            if (isPasswordChar)
            {
                privateKeyBox.UseSystemPasswordChar = false;
                showPrivate.Text = "Hide";
            }
            else
            {
                privateKeyBox.UseSystemPasswordChar = true;
                showPrivate.Text = "Show";
            }
        }
    }
}
