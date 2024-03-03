using Group12_MobileShop.Areas.Identity.Data;
using Group12_MobileShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Group12_MobileShop.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient client = null;
        private string loginUrl = string.Empty;

        public LoginController()
        {
            client = new HttpClient();
            loginUrl = "http://localhost:5000/api/Login?";
        }

        public IActionResult Index()
        {

            return View();
        }
        public async Task<IActionResult> Login (string Email, string Password) 
        {
            loginUrl = loginUrl+Email+"&"+Password;
            
            HttpResponseMessage responseMessage = await client.GetAsync(loginUrl);

            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

            User user = JsonSerializer.Deserialize<User>(responseBody);
            if(user == null)
            {
                return Content("Sai tai khoan hoac mat khau");
            }
            return View("Product", "Index");
                
        }
    }
}
