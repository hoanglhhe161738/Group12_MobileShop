using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Group12_MobileShop.Model;

namespace Group12_MobileShop.Views.Phone
{
    public class DeleteModel : PageModel
    {
        private readonly Group12_MobileShop.Model.PhoneStoreContext _context;

        public DeleteModel(Group12_MobileShop.Model.PhoneStoreContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Group12_MobileShop.Model.Phone Phone { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }

            var phone = await _context.Phones.FirstOrDefaultAsync(m => m.PhoneId == id);

            if (phone == null)
            {
                return NotFound();
            }
            else 
            {
                Phone = phone;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Phones == null)
            {
                return NotFound();
            }
            var phone = await _context.Phones.FindAsync(id);

            if (phone != null)
            {
                Phone = phone;
                _context.Phones.Remove(Phone);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
