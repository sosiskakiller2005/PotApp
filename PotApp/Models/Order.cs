namespace PotApp.Models
{
    public class Order
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public int StatusId { get; set; }
        public string Address { get; set; }
        public int PaymentTypeId { get; set; }
        public int UserId { get; set; }
        public int? SubscriptionId { get; set; }
    }
}
