using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Group12_MobileShop.Model;

namespace Group12_MobileShop.Views.Phone
{
    public class EditModel : PageModel
    {
        private readonly Group12_MobileShop.Model.PhoneStoreContext _context;

        public EditModel(Group12_MobileShop.Model.PhoneStoreContext context)
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

            var phone =  await _context.Phones.FirstOrDefaultAsync(m => m.PhoneId == id);
            if (phone == null)
            {
                return NotFound();
            }
            Phone = phone;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Phone).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PhoneExists(Phone.PhoneId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PhoneExists(int id)
        {
          return (_context.Phones?.Any(e => e.PhoneId == id)).GetValueOrDefault();
        }
    }
}
