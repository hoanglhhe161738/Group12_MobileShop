using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group12_MobileShop.Views.Product
{
    public class ProductModel : PageModel
    {

            public string ModelName { get; set; }
            public string Manufacturer { get; set; }
            public decimal Price { get; set; }
            public string Description { get; set; }
            public bool InStock { get; set; }

            public void OnGet(string modelName, string manufacturer, decimal price, string description, bool inStock)
            {
                ModelName = modelName;
                Manufacturer = manufacturer;
                Price = price;
                Description = description;
                InStock = inStock;
            }
        }
    }