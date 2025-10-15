using System.Data.Entity;

namespace PhanMemBanVe.DAL.Data
{
    public class TicketManagementDbInitializer : CreateDatabaseIfNotExists<TicketManagementContext>
    {
        protected override void Seed(TicketManagementContext context)
        {
            base.Seed(context);
        }
    }
}
