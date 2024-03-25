namespace Group12_MobileShop.Model
{
    public partial class Message
    {
        public int MessageId { get; set; }
        public string SenderUsername { get; set; } = null!;
        public string ReceiverUsername { get; set; } = null!;
        public string MessageText { get; set; } = null!;
        public DateTime MessageDateTime { get; set; }
    }
}
