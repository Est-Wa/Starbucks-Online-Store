using Azure.Core;
using Entities;
using Microsoft.EntityFrameworkCore;
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
        public async Task<List<Product>> GetProductAsync(int?[] categoryIds, int? minPrice, int? maxPrice, string? productName, string? description) {
            var query = _storeDbContext.Products.Where(Product =>
            (description == null ? true : Product.Description.Contains(description)) &&
            (minPrice == null ? true : Product.Price >= minPrice) &&
            (maxPrice == null ? true : Product.Price <= maxPrice) &&
            (productName == null ? true : Product.ProductName.Equals(productName))
            //&& (categoryIds == null? true: categoryIds.Any(
            );
            return List<Product> = await query.ToListAsync();
        }
        public async Task<int> AddProduct(Product product)
        {
            await _storeDbContext.Products.AddAsync(product);
            await _storeDbContext.SaveChangesAsync();
            return product.ProductId;
        }
    }
}
