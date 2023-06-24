using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

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
            string pass = passwordBox.Text;
            string propPass = Properties.Settings.Default.Password;
            if(propPass == "" && pass == "admin")
            {
                showSettingsForm();

            } else if(propPass != "" && propPass == pass)
            {
                showSettingsForm();
            } else
            {
                MessageBox.Show("incorrect Password ! ");
            }
        }
        private void showSettingsForm()
        {
            is_active = false;
            this.Close();
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();

        }
    }
}
