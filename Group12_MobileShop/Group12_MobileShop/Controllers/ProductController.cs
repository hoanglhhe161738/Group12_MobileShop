using Group12_MobileShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task<IActionResult> Index(int index = 1)
        {

            HttpResponseMessage responseMessage = await client.GetAsync(productUrl);
            
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<Product>>(responseBody);
            int pageSize = 12; // Số mục trên mỗi trang

            var pagedData = list.Skip((index - 1) * pageSize).Take(pageSize);

            ViewBag.TotalCount = list.Count();
            ViewBag.CurrentPage = index;
            return View(pagedData);
        }

        [HttpGet]
        public async Task<IActionResult> filterPriceHighToLow()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(productUrl);

            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Product> list = JsonSerializer.Deserialize<List<Product>>(responseBody);
            List<Product> list2 = list.OrderByDescending(p => p.manufacturer).ToList();
            return View("_ProductList", list2) ;
        }

        [HttpGet]      
        public async Task<IActionResult> filterPriceLowToHigh()
        {
            HttpResponseMessage responseMessage = await client.GetAsync(productUrl);

            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            List<Product> list = JsonSerializer.Deserialize<List<Product>>(responseBody);
            List<Product> list2 = list.OrderBy(p => p.manufacturer).ToList();
            return View("_ProductList", list2);
        }
    }
}
