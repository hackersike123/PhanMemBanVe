namespace PhanMemBanVe.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    using PhanMemBanVe.Data;

    internal sealed class Configuration : DbMigrationsConfiguration<PhanMemBanVe.Data.TicketManagementContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        // Seed left intentionally empty for stub EF environment.
    }
}
