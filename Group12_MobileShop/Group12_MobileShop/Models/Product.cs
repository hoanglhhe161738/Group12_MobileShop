namespace Group12_MobileShop.Models
{
    public class Product
    {
        public int phoneId { get; set; }
        public string? modelName { get; set; }
        public string? manufacturer { get; set; }
        public decimal price { get; set; }
        public string? description { get; set; }
        public bool inStock { get; set; }
        public string? imageUrl { get; set; }

    }
}
