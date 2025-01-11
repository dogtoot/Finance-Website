using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Security.Claims;
using Microsoft.Data.Sqlite;

namespace FinanceProj
{
    public class UserManager
    {
        public static async void SignIn(HttpContext httpContext)
        {
            using (var con = new SqliteConnection("finance.db"))
            {

            }
        }
    }
}
