using Azure.Core;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ProductRepository : IProductRepository
    {
        StoreDbContext _storeDbContext;
        public ProductRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;
        }
        public async Task<Product> GetProductAsync(int? [] categoryIds, int? minPrice, int? maxPrice, string? productName, string? description)
        {
            return null;
        }
        public async Task<int> AddProduct(Product product)
        {
            await _storeDbContext.Products.AddAsync(product);
            await _storeDbContext.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
