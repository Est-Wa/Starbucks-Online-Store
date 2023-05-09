using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<List<Product>> GetProductAsync(IEnumerable<int> categoryIds, int? minPrice, int? maxPrice, string? productName, string? description)
        {
            return await _productRepository.GetProductAsync(categoryIds, minPrice, maxPrice, productName, description);
        }
        public async Task<int> AddProduct(Product product)
        {
            return await _productRepository.AddProduct(product);
        }
    }
}
