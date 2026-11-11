using Microsoft.EntityFrameworkCore;
using PotApp.Data;
using PotApp.Dtos.OrderDtos;
using PotApp.Dtos.ProductDtos;
using PotApp.Models;


namespace PotApp.Services
{
    public class OrderService(DataContext context)
    {
        public async Task<GetOrdersResponse> GetOrdersAsync()
        {
            List<OrderDto> orders = await context.Orders.Select(o => new OrderDto(o.Id, o.TotalPrice, o.OrderStatusId, o.Address, o.PaymentTypeId, o.UserId, o.SubscriptionId)).ToListAsync();
            return new GetOrdersResponse(orders);
        }

        public async Task<OrderDto?> GetOrderByIdAsync(int id)
        {
            Order? order = await context.Orders.FindAsync(id);
            if (order is null)
            {
                return null;
            }

            return new OrderDto(
                order.Id,
                order.TotalPrice,
                order.OrderStatusId,
                order.Address,
                order.PaymentTypeId,
                order.UserId,
                order.SubscriptionId);
        }

        public async Task<CreateOrderRequest> CreateOrderAsync(CreateOrderRequest request)
        {
            var newOrder = new Order
            {
                TotalPrice = request.TotalPrice,
                OrderStatusId = request.OrderStatusId,
                Address = request.Address,
                PaymentTypeId = request.PaymentTypeId,
                UserId = request.UserId,
                SubscriptionId = request.SubscriptionId
            };
            context.Orders.Add(newOrder);
            await context.SaveChangesAsync();

            return new CreateOrderRequest(
                newOrder.TotalPrice,
                newOrder.OrderStatusId,
                newOrder.Address,
                newOrder.PaymentTypeId,
                newOrder.UserId,
                newOrder.SubscriptionId);
        }
        
        public async Task<bool?> DeleteOrderAsync(int id)
        {
            var order = await context.Orders.FindAsync(id);
            if (order is null)
            {
                return null;
            }
            context.Orders.Remove(order);
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateOrderAsync(int id, OrderDto orderDto)
        {
            var order = await context.Orders.FindAsync(id);
            if (order is null)
            {
                return null;
            }
            order.TotalPrice = orderDto.TotalPrice;
            order.OrderStatusId = orderDto.OrderStatusId;
            order.Address = orderDto.Address;
            order.PaymentTypeId = orderDto.PaymentTypeId;
            order.UserId = orderDto.UserId;
            order.SubscriptionId = orderDto.SubscriptionId;
            await context.SaveChangesAsync();
            return true;
        }

        public async Task<bool?> UpdateOrderPartialAsync(int id, UpdateOrderRequest request)
        {
            var order = await context.Orders.FindAsync(id);
            if (order is null)
            {
                return null;
            }
            foreach (var orderProperty in order.GetType().GetProperties())
            {
                if (orderProperty.Name == nameof(order.Id))
                {
                    continue;
                }

                var dtoProperty = request.GetType().GetProperty(orderProperty.Name);
                var dtoValue = dtoProperty?.GetValue(request);
                if (dtoValue is null)
                {
                    continue;
                }

                var orderValue = orderProperty.GetValue(order);
                if (!Equals(orderValue, dtoValue))
                {
                    orderProperty.SetValue(order, dtoValue);
                }
            }
            await context.SaveChangesAsync();
            return true;
        }
    }
}
