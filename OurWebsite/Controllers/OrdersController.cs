using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrdersController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] Order order)
        {
            Order newOrder = await _orderService.AddOrderAsync(order);
            if (newOrder != null)
            {
                return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
            }
            return BadRequest();
;        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            return await _orderService.GetOrderAsync(id);
        }
    }
}
