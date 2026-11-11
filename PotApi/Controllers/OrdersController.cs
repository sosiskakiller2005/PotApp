using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PotApp.Dtos.OrderDtos;
using PotApp.Services;

namespace PotApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController(OrderService service) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult<GetOrdersResponse>> GetOrders()
            => Ok(await service.GetOrdersAsync());

        [HttpGet("{id}")]
        public async Task<ActionResult> GetOrderById(int id)
        {
            var order = await service.GetOrderByIdAsync(id);
            if (order is null)
            {
                return NotFound("Order was not found.");
            }
            return Ok(order);
        }

        [HttpPost]
        public async Task<ActionResult<CreateOrderRequest>> CreateOrder(CreateOrderRequest request)
        {
            var order = await service.CreateOrderAsync(request);
            if (order is null)
            {
                return NotFound("Order was not found.");
            }
            return StatusCode(StatusCodes.Status201Created, order);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateOrder(int id, OrderDto request)
        {
            var updatedOrder = await service.UpdateOrderAsync(id, request);
            if (updatedOrder is null)
            {
                return NotFound("Order with this Id was not found.");
            }
            return Ok(updatedOrder);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult> UpdateOrderPartial(int id, UpdateOrderRequest request)
        {
            var updatedOrder = await service.UpdateOrderPartialAsync(id, request);
            if (updatedOrder is null)
            {
                return NotFound("Order with this Id was not found.");
            }
            return Ok(updatedOrder);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOrder(int id)
        {
            var result = await service.DeleteOrderAsync(id);
            if (result is null)
            {
                return NotFound("Order with this Id was not found.");
            }
            return Ok("Order deleted successfully.");
        }
    }
}
