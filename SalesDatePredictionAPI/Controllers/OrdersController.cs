using Microsoft.AspNetCore.Mvc;
using SalesDatePredictionAPI.DTOs;
using SalesDatePredictionAPI.Services;

namespace SalesDatePredictionAPI.Controllers
{
    [Route("api/Orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrderService _orderService;

        public OrdersController(OrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetOrdersByIdCustomer/{customerId}")]
        public async Task<ActionResult<IEnumerable<OrdersDto>>> GetOrdersByCustomer(int customerId)
        {
            var orders = await _orderService.GetOrdersByCustomerAsync(customerId);
            if (orders == null || orders.Count == 0)
            {
                return NotFound("No orders found for this customer.");
            }
            return Ok(orders);
        }

        [HttpGet("GetOrdersByCustomersWithOrderPrediction")]
        public async Task<ActionResult<IEnumerable<ResponsePredictOrderForDateDto>>> GetCustomersWithOrderPrediction()
        {
            var ordersWithPreditions = await _orderService.GetCustomersWithOrderPredictionAsync();
            if (ordersWithPreditions == null || ordersWithPreditions.Count == 0)
            {
                return NotFound("No found ordersWithPreditions.");
            }
            return Ok(ordersWithPreditions);
        }

        [HttpPost("CreateOrder")]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderDto orderDto)
        {
            var order = await _orderService.CreateOrderAsync(
                orderDto.CustomerId,
                orderDto.EmpId,
                orderDto.ShipperId,
                orderDto.ShipName,
                orderDto.ShipAddress,
                orderDto.ShipCity,
                orderDto.ShipCountry,
                orderDto.ShipRegion,
                orderDto.ShipPostalCode,
                orderDto.ProductId,
                orderDto.UnitPrice,
                orderDto.Quantity,
                orderDto.OrderDate,
                orderDto.RequiredDate,
                orderDto.ShippedDate,
                orderDto.Freight,
                orderDto.Discount
            );

            return CreatedAtAction(nameof(CreateOrder), new { id = order.orderid }, order);
        }

        [HttpGet("SearchCustomer")]
        public async Task<IActionResult> GetCustomers([FromQuery] string search = "")
        {
            var customers = await _orderService.GetOrderByCustomersPrediceAsync(search);
            return Ok(customers);
        }
    }  
}

