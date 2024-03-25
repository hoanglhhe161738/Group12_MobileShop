using System.ComponentModel.DataAnnotations.Schema;

namespace Group12_MobileShop.Model
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
        public string? Username { get; set; }
        public DateTime? OrderDate { get; set; }

        [ForeignKey("Username")]
        public virtual Account? UsernameNavigation { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
