using System;
using System.Windows.Forms;

namespace p_payment_service
{
    public partial class Login : Form
    {
        public static bool is_active = false;
        public Login()
        {
            InitializeComponent();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            is_active = false;
            this.Close();
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            is_active=false;
        }

        private void Login_Load(object sender, EventArgs e)
        {
            is_active = true;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            if (ValidatePassword())
            {
                showSettingsForm();
            }
        }
        private void showSettingsForm()
        {
            is_active = false;
            this.Close();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();

        }
        private bool ValidatePassword()
        {
            string pass = passwordBox.Text;
            string propPass = Properties.Settings.Default.Password;
            if (propPass == "" && pass == "admin")
            {
                return true;

            }
            else if (propPass != "" && propPass == pass)
            {
                return true;
            }
            else
            {
                MessageBox.Show("incorrect Password ! ");
               
            }
            return false;
        }

        private void passwordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (ValidatePassword())
                {
                    showSettingsForm();
                }
            }
        }
    }
}
