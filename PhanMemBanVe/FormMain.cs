using System;
using System.Linq;
using System.Windows.Forms;

namespace PhanMemBanVe
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            mnuLogin.Click += MnuLogin_Click;
            menuExit.Click += MenuExit_Click;
        }

        private void MenuExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void MnuLogin_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmLogin)
                {
                    form.BringToFront();
                    return;
                }
            }

            var frm = new frmLogin
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void mnuTicketManagement_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is frmTicketManagement)
                {
                    form.BringToFront();
                    return;
                }
            }

            var ticketManagementForm = new frmTicketManagement
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            ticketManagementForm.Show();
        }

        private void mnuCustomers_Click(object sender, EventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormCustomers)
                {
                    form.BringToFront();
                    return;
                }
            }

            var frm = new FormCustomers
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            frm.Show();
        }

        private void mnuViewRevenue_Click(object sender, EventArgs e)
        {
            // Open Ticket Sales Report (FormTicketSalesReport)
            foreach (Form form in Application.OpenForms)
            {
                if (form is FormTicketSalesReport)
                {
                    form.BringToFront();
                    return;
                }
            }

            var rpt = new FormTicketSalesReport
            {
                MdiParent = this,
                StartPosition = FormStartPosition.CenterScreen
            };
            rpt.Show();
        }
    }
}
