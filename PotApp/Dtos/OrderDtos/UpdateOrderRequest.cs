namespace PotApp.Dtos.OrderDtos
{
    public record UpdateOrderRequest(decimal? TotalPrice, int? OrderStatusId, string? Address, int? PaymentTypeId, int? UserId, int? SubscriptionId);
}
