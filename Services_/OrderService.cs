using Entities;
using Microsoft.Extensions.Logging;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<OrderService> _logger;
        public OrderService(IOrderRepository orderRepository, IProductRepository productRepository, ILogger<OrderService> logger)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
            _logger = logger;
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            int sum = 0;
            foreach(var item in order.OrderItems)
            {
                sum += item.Quantity * await _productRepository.getItemPrice(item.ProductId) ;
            }
            if(order.OrderSum != sum)
            {
                _logger.LogError($"User Tried Hacking! order sum supposed to be: {sum}, user tried putting in {order.OrderSum}: ");
                order.OrderSum = sum; 
            }
            return await _orderRepository.AddOrderAsync(order);
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            return await _orderRepository.GetOrderAsync(id);
        }
    }
}
