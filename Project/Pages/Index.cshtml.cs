using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Companies.Pages
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            return Redirect("/companies");
        }
    }
}
