namespace PotApp.Models
{
    public class SubscriptionProduct
    {
        public int Id { get; set; }
        public int SubscriptionId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
