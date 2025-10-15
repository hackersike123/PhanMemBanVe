namespace PhanMemBanVe.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using PhanMemBanVe.DAL.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<PhanMemBanVe.DAL.Data.TicketManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Seed left intentionally empty for stub EF environment.
    }
}
