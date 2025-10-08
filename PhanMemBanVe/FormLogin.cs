using PhanMemBanVe.utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PhanMemBanVe
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
            // event handler for likRegister click
            likRegister.LinkClicked += LikRegister_LinkClicked;
            txtPassword.PasswordChar = '*';
        }

        private void LikRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            // Open the registration form
            frmRegister registerForm = new frmRegister();
            registerForm.ShowDialog();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Implement login logic here
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }
            using (var context = new Data.TicketManagementContext())
            {
                var user = context.Users.FirstOrDefault(u => u.UserName == username);
                if (user != null)
                {
                    // Hash the entered password and compare with stored hash
                    string hashedPassword = Helper.HashPassword(password);
                    if (user.Password == hashedPassword)
                    {
                        // Login successful
                        MessageBox.Show("Login successful!");
                        // Open the ticket management form
                        frmTicketManagement ticketManagementForm = new frmTicketManagement();
                        ticketManagementForm.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid password.");
                    }
                }
                else
                {
                    MessageBox.Show("User not found.");
                }
            }
        }
    }
}
