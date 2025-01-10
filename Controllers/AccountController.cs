using Google.Apis.Auth;
using Microsoft.AspNetCore.Mvc;

namespace FinanceProj.Controllers
{
    [Route("api")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        [HttpPost]
        [Route("verify")]
        public async Task<IActionResult> PostVerify()
        {
            Stream req = Request.Body;
            string json = new StreamReader(req).ReadToEndAsync().Result;
            GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(json.Replace("\"", ""));
            Console.WriteLine($"UserID: {payload.Subject}");

            return new JsonResult(new { Success = true, Message = "Successfully signed in." });
        }
    }
}
