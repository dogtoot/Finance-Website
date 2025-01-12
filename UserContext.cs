using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace FinanceProj
{
    public class UserContext
    {

    }
    /*public class UserContext //: DbContext
    {
        public DbSet<User> users { get; set; }
        public string DbPath { get; }

        public UserContext(DbContextOptions<UserContext> dbContext) : base(dbContext) { }

        public UserContext()
        {
            DbPath = "finance.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }

    public class User : IdentityUser
    {
        public required string UserId { get; set; }
    }*/
}
