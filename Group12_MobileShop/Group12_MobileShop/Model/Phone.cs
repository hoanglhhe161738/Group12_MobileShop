namespace Group12_MobileShop.Model
{
    public partial class Phone
    {
        public Phone()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int PhoneId { get; set; }
        public string? ModelName { get; set; }
        public string? Manufacturer { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public bool? InStock { get; set; }
        public string? ImageUrl { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
