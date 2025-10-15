using System;
using System.Windows.Forms;
using PhanMemBanVe.DAL.Data;

namespace PhanMemBanVe.GUI
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            // Initialize context (stub)
            using (var ctx = new TicketManagementContext()) { ctx.Database.Initialize(false); }
            Application.Run(new FormMain());
        }
    }
}
