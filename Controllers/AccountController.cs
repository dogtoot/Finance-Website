using Google.Apis.Auth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FinanceProj.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        [Route("verify")]
        public async Task<IActionResult> PostVerify()
        {
            Stream req = Request.Body;
            string json = new StreamReader(req).ReadToEndAsync().Result;
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(json.Replace("\"", ""));
            Console.WriteLine($"UserID: {payload.Subject}");
            
            var user = new IdentityUser { Email = payload.Email, UserName = payload.Name };
            var result = await _userManager.CreateAsync(user, payload.Subject);
            Challenge();
            /*using (var db = new UserContext()) 
            {
                if (result.Succeeded)
                {
                    db.Add(user);
                    db.SaveChanges();
                }
            }*/
            return new JsonResult(new { Success = true, Message = "Successfully signed in." });
        }

        [Route("google")]
        public IActionResult SignInGoogle()
        {
            return Challenge(new AuthenticationProperties
            {
                RedirectUri = Url.Action(nameof(SignInReturn))
            }, GoogleDefaults.AuthenticationScheme);
        }

        [Route("return")]
        public IActionResult SignInReturn()
        {
            // Do stuff with the user here. Their information is in the User    
            // property of the controller.
            return LocalRedirect("/Finance");
        }
    }
}
