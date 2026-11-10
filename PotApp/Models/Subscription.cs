namespace PotApp.Models
{
    public class Subscription
    {
        public int Id { get; set; }
        public Boolean IsActive { get; set; }
        public decimal TotalPrice { get; set; }
        public int UserId { get; set; }
        public int StatusId { get; set; }
        public int PaymentTypeId { get; set; }
        public DateTime DateOfNextDelivery { get; set; }

        public ICollection<Order> Orders { get; set; }
    }
}
