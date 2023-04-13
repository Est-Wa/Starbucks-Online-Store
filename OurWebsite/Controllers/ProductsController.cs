using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet()]
        public async Task<ActionResult<Product>> Get([FromQuery] int?[] categoryIds, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? productName, [FromQuery] string? description)
        {
            return await _productService.GetProductAsync(categoryIds, minPrice, maxPrice, productName, description);
        }
        [HttpPost()]
        public async Task<ActionResult<int>> Post([FromBody] Product product)
        {
            return await _productService.AddProduct(product);
        }
    }
}
