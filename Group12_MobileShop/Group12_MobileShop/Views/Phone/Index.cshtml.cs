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
    public class IndexModel : PageModel
    {
        private readonly Group12_MobileShop.Model.PhoneStoreContext _context;

        public IndexModel(Group12_MobileShop.Model.PhoneStoreContext context)
        {
            _context = context;
        }

        public IList<Group12_MobileShop.Model.Phone> Phone { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Phones != null)
            {
                Phone = await _context.Phones.ToListAsync();
            }
        }
    }
}
