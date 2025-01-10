using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Auth;
using Newtonsoft.Json.Linq;

namespace FinanceProj.Pages;

public class IndexModel : PageModel
{
    public static bool logged_in = false;

    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger)
    {
        _logger = logger;
    }

    public IActionResult OnGet()
    {
        if (!logged_in) 
        {
            return LocalRedirect("/");
        }
        return new JsonResult(new { Success = true });
    }

    public IActionResult OnPostBuildRow(string message)
    {
        Console.WriteLine(message);
        return new JsonResult(new { Success = true, Message = "Successfully saved row." });
    }
}
