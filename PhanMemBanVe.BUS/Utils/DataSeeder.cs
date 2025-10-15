using System;
using System.Linq;
using PhanMemBanVe.DAL.Models;
using PhanMemBanVe.DAL.Data;

namespace PhanMemBanVe.BUS.Utils
{
    public static class DataSeeder
    {
        public static void EnsureSeed(TicketManagementContext ctx)
        {
            if (ctx.Customers.Any() || ctx.TicketSales.Any())
                return;

            var cust1 = new Customer { CustomerCode = "C001", FullName = "Nguyen Van A", Phone = "0901000001", CreatedAt = DateTime.UtcNow };
            var cust2 = new Customer { CustomerCode = "C002", FullName = "Tran Thi B", Phone = "0902000002", CreatedAt = DateTime.UtcNow };
            ctx.Customers.Add(cust1);
            ctx.Customers.Add(cust2);
            ctx.SaveChanges();

            var rnd = new Random();
            for (int i = 0; i < 8; i++)
            {
                var cust = (i % 2 == 0) ? cust1 : cust2;
                ctx.TicketSales.Add(new TicketSale
                {
                    TicketCode = "T" + (1000 + i),
                    CustomerId = cust.CustomerId,
                    SaleDate = DateTime.UtcNow.AddHours(-i * 6),
                    SeatNumber = 10 + i,
                    AreaName = (i % 3 == 0) ? "VIP" : "Standard",
                    Price = 75000 + (i % 3) * 25000,
                    IsRefunded = (i == 5) // one refunded example
                });
            }
            ctx.SaveChanges();
        }
    }
}