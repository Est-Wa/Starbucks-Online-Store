using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrderAsync(Order order);
        public Task<Order> GetOrderAsync(int id);
    }
}