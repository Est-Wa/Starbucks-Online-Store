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
        //private readonly IOrderItemService
        private readonly IMapper _mapper;
        public OrdersController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<OrderDTO>> Get(int id)
        {
            Order o = await _orderService.GetOrderAsync(id);
            OrderDTO odto = _mapper.Map<Order, OrderDTO>(o);
            return Ok(odto);
        }

        [HttpPost]
        public async Task<ActionResult<OrderDTO>> AddOrder([FromBody] OrderDTO orderDTO)
        {
            Order order = _mapper.Map<OrderDTO, Order>(orderDTO);
 
                var orderCreated = await _orderService.AddOrderAsync(order);
            if(orderCreated != null)
            {
                OrderDTO o =  _mapper.Map<Order, OrderDTO>(orderCreated);
                return CreatedAtAction(nameof(Get), new { id = o.OrderId }, o);

            }
     
            return BadRequest();

;        }

    }
}
