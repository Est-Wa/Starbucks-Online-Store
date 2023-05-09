using AutoMapper;
using DTO;
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
        private readonly IMapper _mapper;
        public ProductsController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }
        [HttpGet()]
        public async Task<ActionResult<List<Product>>> Get([FromQuery] IEnumerable<int> categoryIds, [FromQuery] int? minPrice, [FromQuery] int? maxPrice, [FromQuery] string? productName, [FromQuery] string? description)
        {
            return await _productService.GetProductAsync(categoryIds, minPrice, maxPrice, productName, description);
        }
        [HttpPost()]
        public async Task<ActionResult<int>> Post([FromBody] ProductDTO product)
        {
            var _product = _mapper.Map<Product>(product);
            var ans = await _productService.AddProduct(_product);
            return ans;
        }
    }
}
