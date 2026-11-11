namespace PotApp.Dtos.OrderDtos
{
    public record OrderDto(int Id, decimal TotalPrice, int OrderStatusId, string Address, int PaymentTypeId, int UserId, int? SubscriptionId);
}
