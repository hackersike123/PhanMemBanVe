using System;
using System.Data.Entity;
using System.Windows.Forms;
using PhanMemBanVe.DAL.Data;
using PhanMemBanVe.DAL.Migrations;

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
            
            // Thiết lập Database Initializer để tự động migrate
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicketManagementContext, Configuration>());
            
            // Khởi tạo database
            try
            {
                using (var ctx = new TicketManagementContext())
                {
                    ctx.Database.Initialize(force: true);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khởi tạo database: {ex.Message}\n\nChi tiết: {ex.InnerException?.Message}", 
                    "Lỗi Database", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            Application.Run(new FormMain());
        }
    }
}
