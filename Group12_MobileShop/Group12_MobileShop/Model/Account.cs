using Group12_MobileShop.Models;

namespace Group12_MobileShop.Model
{
    public partial class Account
    {
        public Account()
        {
            Orders = new HashSet<Order>();
        }

        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Email { get; set; }
        public string? full_name { get; set; }

        public virtual ICollection<Order>? Orders { get; set; }
    }
}
