using Group12_MobileShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace Group12_MobileShop.Controllers
{
    public class ProductController : Controller
    {

        private readonly HttpClient client = null;
        private string productUrl = string.Empty;
        private static List<Product>? models = new List<Product>();

        public ProductController()
        {
            this.client = new HttpClient();
            productUrl = "http://localhost:5000/api/Product";
            
        }

        public async Task<IActionResult> Index(int page = 1)
        {
            
            
            int pageSize = 12; // Số mục trên mỗi trang

            if (models.Count > 0)
            {
                var pagedData1 = models.Skip((page - 1) * pageSize).Take(pageSize);

                ViewBag.TotalCount = models.Count();
                ViewBag.CurrentPage = page;
                HttpContext.Session.SetString("CurrentPage", page.ToString());
                HttpContext.Session.SetString("TotalCount", models.Count().ToString());

                return View(pagedData1);
            }

            HttpResponseMessage responseMessage = await client.GetAsync(productUrl);
            
            string responseBody = await responseMessage.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            var list = JsonSerializer.Deserialize<List<Product>>(responseBody);

            var pagedData = list.Skip((page - 1) * pageSize).Take(pageSize);

            ViewBag.TotalCount = list.Count();
            ViewBag.CurrentPage = page;
            HttpContext.Session.SetString("CurrentPage", page.ToString());
            HttpContext.Session.SetString("TotalCount", list.Count().ToString());

            return View(pagedData);
        }

        [HttpGet]
        public async Task<IActionResult> filterPriceHighToLow()
        {
            List<Product> list2 = new List<Product>();
            if (models.Count > 0)
            {
                list2 = models.OrderByDescending(p => p.price).ToList();
                
            }
            else
            {
                HttpResponseMessage responseMessage = await client.GetAsync(productUrl);

                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Product> list = JsonSerializer.Deserialize<List<Product>>(responseBody);
                list2 = list.OrderByDescending(p => p.manufacturer).ToList();
            }
            models = list2;

            int pageSize = 12; // Số mục trên mỗi trang
            ViewBag.CurrentPage = 1;
            ViewBag.TotalCount = models.Count();

            var pagedData = list2.Skip((0) * pageSize).Take(pageSize);
            HttpContext.Session.SetString("CurrentPage", "1");
            HttpContext.Session.SetString("TotalCount", models.Count().ToString());

            return View("_ProductList", pagedData) ;
        }

        [HttpGet]      
        public async Task<IActionResult> filterPriceLowToHigh()
        {
            List<Product> list2 = new List<Product>();

            if(models.Count > 0)
            {
                list2 = models.OrderBy(p => p.price).ToList();
                models = list2;
            }
            else
            {
                HttpResponseMessage responseMessage = await client.GetAsync(productUrl);

                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                List<Product> list = JsonSerializer.Deserialize<List<Product>>(responseBody);
                list2 = list.OrderBy(p => p.manufacturer).ToList();
            }
           
            models = list2;

            int pageSize = 12; // Số mục trên mỗi trang

            var pagedData = list2.Skip((0) * pageSize).Take(pageSize);
            ViewBag.CurrentPage = 1;
            ViewBag.TotalCount = models.Count();

            HttpContext.Session.SetString("CurrentPage", "1");
            HttpContext.Session.SetString("TotalCount", models.Count().ToString());

            return View("_ProductList", pagedData);
        }

        [HttpGet]
        public async Task<IActionResult> SearchByname(string name)
        {
            List<Product> list = new List<Product>();
            if(models.Count > 0)
            {
                list = models.Where(m => m.modelName.ToUpper().Contains(name.ToUpper())).ToList();
            }
            else
            {
                HttpResponseMessage responseMessage = await client.GetAsync(productUrl + "/getPhoneByname?name=" + name);

                string responseBody = await responseMessage.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                list = JsonSerializer.Deserialize<List<Product>>(responseBody);
            }
            
            models = list;

            int pageSize = 12; // Số mục trên mỗi trang
            var pagedData = list.Skip((0) * pageSize).Take(pageSize);
            ViewBag.CurrentPage = 1;
            ViewBag.TotalCount = models.Count();

            HttpContext.Session.SetString("CurrentPage", "1");
            HttpContext.Session.SetString("TotalCount", models.Count().ToString());

            return View("_ProductList", pagedData);
        }

    }
}
