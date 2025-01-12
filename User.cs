using Microsoft.AspNetCore.Identity;

namespace FinanceProj
{
    public class User : IdentityUser
    {
        public required string UserId { get; set; }
    }
}
