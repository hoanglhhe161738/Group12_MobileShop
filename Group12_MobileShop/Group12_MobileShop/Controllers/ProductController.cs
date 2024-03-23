using Group12_MobileShop.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Group12_MobileShop.Controllers
{
    public class ProductController : Controller
    {

        private readonly HttpClient client = null;
        private string productUrl = string.Empty;



        public ProductController()
        {
            this.client = new HttpClient();
            productUrl = "http://localhost:5000/api/Product";
        }

        public async Task<IActionResult> Index()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(productUrl);
            
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Product> list = JsonSerializer.Deserialize<List<Product>>(responseBody);
            return View(list);
        }
    }
}
