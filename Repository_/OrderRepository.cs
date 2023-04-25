using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class OrderRepository : IOrderRepository
    {
        StoreDbContext _storeDbContext;
        public OrderRepository(StoreDbContext storeDbContext) 
        {
            _storeDbContext = storeDbContext; 
        }
        public async Task<Order> AddOrderAsync(Order order)
        {
            await _storeDbContext.Orders.AddAsync(order);
            await _storeDbContext.SaveChangesAsync();
            return order;
        }
        public async Task<Order> GetOrderAsync(int id)
        {
            return await _storeDbContext.Orders.FindAsync(id);
        }

    }
}
