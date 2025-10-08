using PhanMemBanVe.Data;
using PhanMemBanVe.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using PhanMemBanVe.utils;

namespace PhanMemBanVe
{
    public partial class frmRegister : Form
    {
        public frmRegister()
        {
            InitializeComponent();
            // event handler for btnRegister click
            btnRegister.Click += BtnRegister_Click;
            // password character for txtPassword and txtConfirmPassword
            txtPassword.PasswordChar = '*';
            txtConfirmPassword.PasswordChar = '*';
        }

     

        private bool IsUserNameExists(string username)
        {
            using (var context = new TicketManagementContext())
            {
                return context.Users.Any(u => u.UserName == username);
            }
        }

        private void BtnRegister_Click(object sender, EventArgs e)
        {
            // Implement registration logic here
            string username = txtUserName.Text;
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            // Validate input
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.");
                return;
            }

            if (password != confirmPassword)
            {
                MessageBox.Show("Passwords do not match.");
                return;
            }

            // Check if username already exists
            if (IsUserNameExists(username))
            {
                MessageBox.Show("Username already exists. Please choose a different username.");
                return;
            }

            // Hash the password
            string hashedPassword = Helper.HashPassword(password);

            // saving the user information to a database
            using (var context = new TicketManagementContext())
            {
                var user = new User
                {
                    UserName = username,
                    Password = hashedPassword,
                    Role = "User" // Default role
                };
                context.Users.Add(user);
                context.SaveChanges();
            }

            // Simulate successful registration
            MessageBox.Show("Registration successful!");
            this.Close();
        }
    }
}
