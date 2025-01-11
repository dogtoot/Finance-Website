using Microsoft.EntityFrameworkCore;

namespace FinanceProj
{
    public class UserContext : DbContext
    {
        public DbSet<User> users { get; set; }
        public string DbPath { get; }

        public UserContext()
        {
            DbPath = "finance.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }

    public class User
    {
        public required string UserId { get; set; }
        public required string Email { get; set; }
        public required string UserName {  get; set; }
    }

    // Remove Migrations : "ef migrations remove"
}
