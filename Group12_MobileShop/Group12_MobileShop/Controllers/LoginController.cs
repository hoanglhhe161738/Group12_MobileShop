using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

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
        public Task< ActionResult > Login (string Email, string Password) 
        {
            loginUrl = loginUrl+Email+"&"+Password;
            
            HttpResponseMessage responseMessage = client.GetAsync(loginUrl);

            string responseBody =  responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }
    }
}
