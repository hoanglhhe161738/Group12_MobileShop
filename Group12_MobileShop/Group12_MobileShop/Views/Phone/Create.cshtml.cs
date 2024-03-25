using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Group12_MobileShop.Model;

namespace Group12_MobileShop.Views.Phone
{
    public class CreateModel : PageModel
    {
        private readonly Group12_MobileShop.Model.PhoneStoreContext _context;

        public CreateModel(Group12_MobileShop.Model.PhoneStoreContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Group12_MobileShop.Model.Phone Phone { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Phones == null || Phone == null)
            {
                return Page();
            }

            _context.Phones.Add(Phone);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
