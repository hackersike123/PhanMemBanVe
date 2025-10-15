using PhanMemBanVe.DAL.Entities;
using PhanMemBanVe.DAL.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace PhanMemBanVe.DAL.Data
{
    public class TicketManagementContext : DbContext
    {
        public TicketManagementContext() : base("name=TicketManagementContext")
        {
        }

        // DbSet for tables - Thêm virtual để EF có thể khởi tạo đúng
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<TicketSale> TicketSales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ...existing code...
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}