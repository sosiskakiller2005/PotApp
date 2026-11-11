namespace PotApp.Models
{
    public class OrderProduct
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        // свойство для хранения цены на момент покупки
        public decimal UnitPrice { get; set; }

    }
}
