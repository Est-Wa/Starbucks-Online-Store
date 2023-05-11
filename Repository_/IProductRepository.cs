using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetProductAsync(IEnumerable<int?> categoryIds, int? minPrice, int? maxPrice, string? productName, string? description);
        Task<int> AddProduct(Product product);
    }
}
