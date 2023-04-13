using Entities;

namespace Services
{
    public interface IProductService
    {
        Task<Product> GetProductAsync(int?[] categoryIds, int? minPrice, int? maxPrice, string? productName, string? description);
        Task<int> AddProduct(Product product);
    }
}