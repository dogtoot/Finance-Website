using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth;
using Newtonsoft.Json.Linq;

namespace FinanceProj.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public void OnGet()
    {
        Console.WriteLine("Started...");
    }

    public IActionResult OnPostBuildRow(string message)
    {
        Console.WriteLine(message);
        return new JsonResult(new { Success = true, Message = "Successfully saved row." });
    }

    public async Task<IActionResult> OnPostVerify()
    {
        Stream req = Request.Body;
        string json = new StreamReader(req).ReadToEndAsync().Result;
        GoogleJsonWebSignature.Payload payload = await GoogleJsonWebSignature.ValidateAsync(json);

        return new JsonResult(new { Success = true, Message = "Successfully signed in." });
    }
}
