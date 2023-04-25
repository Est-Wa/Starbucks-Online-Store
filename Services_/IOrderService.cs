using Entities;

namespace Services
{
    public interface IOrderService
    {
        public Task<Order> AddOrderAsync(Order order);
        public Task<Order> GetOrderAsync(int id);
    }
}