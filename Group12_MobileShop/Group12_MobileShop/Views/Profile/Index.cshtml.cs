using Group12_MobileShop.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group12_MobileShop.Views.Profile
{
    public class IndexModel : PageModel
    {
        public IActionResult OnGet()
        {
            var userId = HttpContext.Session.GetString("UserId");
            var userName = HttpContext.Session.GetString("UserName");
            var userFullName = HttpContext.Session.GetString("Fullname");           

            ViewData["UserId"] = userId;
            ViewData["UserName"] = userName;
            ViewData["Fullname"] = userFullName;
            return Page();
        }
    }
}
