using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Shoeshop
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void btnlogin_Click(object sender, EventArgs e)
        {
            
            Account account = new Account()
            {
                Username = txttk.Text.Trim(),
                Password = txtmk.Text.Trim()
            };
            bool result = new AccountBUS().CheckAccount(account);
            if (result)
            {
                new Homepage().Show();
                    this.Hide();
            }
            else MessageBox.Show("SR");
        }

        private void btnre_Click(object sender, EventArgs e)
        {
            Account newAccount = new Account()
            {
                Username = txttk.Text.Trim(),
                Password = txtmk.Text.Trim()
            };
            bool result = new AccountBUS().AddNew(newAccount);
            if (result) MessageBox.Show("OK");
            else MessageBox.Show("SR");
        }
    }
}
