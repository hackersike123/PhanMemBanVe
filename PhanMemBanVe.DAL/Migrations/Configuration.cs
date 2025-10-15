namespace PhanMemBanVe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using PhanMemBanVe.DAL.Data;
    using PhanMemBanVe.DAL.Entities;
    using PhanMemBanVe.DAL.Models;

    public sealed class Configuration : DbMigrationsConfiguration<PhanMemBanVe.DAL.Data.TicketManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true; // Cho phép tự động migrate kể cả khi có nguy cơ mất data
        }

        protected override void Seed(PhanMemBanVe.DAL.Data.TicketManagementContext context)
        {
            // Seed admin user nếu chưa có
            if (!context.Users.Any())
            {
                context.Users.AddOrUpdate(
                    u => u.UserName,
                    new User
                    {
                        UserName = "admin",
                        Password = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918", // Hash của "admin"
                        Role = "Admin"
                    }
                );
                context.SaveChanges();
            }

            // Seed sample customers và ticket sales cho báo cáo
            if (!context.Customers.Any())
            {
                // Thêm khách hàng mẫu
                var customers = new[]
                {
                    new Customer { CustomerCode = "C001", FullName = "Nguyễn Văn An", Phone = "0901234567", CreatedAt = DateTime.Now.AddDays(-30) },
                    new Customer { CustomerCode = "C002", FullName = "Trần Thị Bình", Phone = "0907654321", CreatedAt = DateTime.Now.AddDays(-25) },
                    new Customer { CustomerCode = "C003", FullName = "Lê Minh Châu", Phone = "0912345678", CreatedAt = DateTime.Now.AddDays(-20) },
                    new Customer { CustomerCode = "C004", FullName = "Phạm Thị Dung", Phone = "0923456789", CreatedAt = DateTime.Now.AddDays(-15) },
                    new Customer { CustomerCode = "C005", FullName = "Hoàng Văn Em", Phone = "0934567890", CreatedAt = DateTime.Now.AddDays(-10) }
                };

                foreach (var customer in customers)
                {
                    context.Customers.AddOrUpdate(c => c.CustomerCode, customer);
                }
                context.SaveChanges();

                // Thêm vé bán mẫu cho 30 ngày gần đây
                var random = new Random();
                var savedCustomers = context.Customers.ToList();
                
                for (int i = 0; i < 50; i++)
                {
                    var customer = savedCustomers[random.Next(savedCustomers.Count)];
                    var daysAgo = random.Next(0, 30);
                    var isVIP = random.Next(100) > 70; // 30% VIP
                    
                    context.TicketSales.Add(new TicketSale
                    {
                        TicketCode = "T" + (10000 + i).ToString(),
                        CustomerId = customer.CustomerId,
                        SaleDate = DateTime.Now.AddDays(-daysAgo).AddHours(random.Next(-12, 12)),
                        SeatNumber = random.Next(1, 100),
                        AreaName = isVIP ? "VIP" : "Standard",
                        Price = isVIP ? 150000 : 75000,
                        IsRefunded = random.Next(100) > 95 // 5% refunded
                    });
                }
                context.SaveChanges();
            }
        }
    }
}
