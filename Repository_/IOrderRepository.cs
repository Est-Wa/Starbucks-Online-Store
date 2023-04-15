using Entities;

namespace Repository
{
    public interface IOrderRepository
    {
        public Task<Order> AddOrderAsync(Order order);
    }
}