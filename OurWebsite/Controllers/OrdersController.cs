using AutoMapper;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<ActionResult<Order>> AddOrder([FromBody] OrderDTO order)
        {
            var _order = _mapper.Map<Order>(order);
            if(ModelState.IsValid) {
                var ans = await _orderService.AddOrderAsync(_order);
                return ans;
            }
            return BadRequest();
            //Order newOrder = await _orderService.AddOrderAsync(order);
            //if (newOrder != null)
            //{
            //    return CreatedAtAction(nameof(Get), new { id = newOrder.OrderId }, newOrder);
            //}
            //return BadRequest();
;        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> Get(int id)
        {
            Order o = await _orderService.GetOrderAsync(id);
            OrderDTO odto = _mapper.Map<OrderDTO>(o);
                //_mapper.Map<Order, OrderDTO>(o);
            return Ok(odto);
        }
    }
}
