namespace PhanMemBanVe.DAL.Entities
{
    public class User
    {
        public int Id { get; set; } // Primary Key
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } // User role (e.g., Admin, User)
    }
}