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

        // DbSet for tables
        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<TicketSale> TicketSales { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // ...existing code...
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}