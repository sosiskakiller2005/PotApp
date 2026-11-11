namespace PotApp.Dtos.OrderDtos
{
    public record CreateOrderRequest(decimal TotalPrice, int OrderStatusId, string Address, int PaymentTypeId, int UserId, int? SubscriptionId);
}
