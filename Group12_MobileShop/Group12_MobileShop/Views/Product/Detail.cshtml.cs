using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Group12_MobileShop.Views.Product
{
    public class DetailModel : PageModel
    {
        public int Id { get; set; }
        public string ModelName { get; set; }
        public string Manufacturer { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public bool InStock { get; set; }

        public IActionResult OnGet(int id, string modelName, string manufacturer, decimal price, string description, bool inStock)
        {
            Id = id;
            ModelName = modelName;
            Manufacturer = manufacturer;
            Price = price;
            Description = description;
            InStock = inStock;

            return Page();
        }

        public async Task<IActionResult> OnPostOrderAsync()
        {
            return RedirectToPage("/Order/Success");
        }
    }
}