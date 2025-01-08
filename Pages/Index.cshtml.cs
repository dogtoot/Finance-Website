using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        
    }

    public IActionResult OnPostBuildRow(string message)
    {
        Console.WriteLine(message);
        return new JsonResult(new { Success = true, Message = "Successfully saved row." });
    }
}
