using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace OurWebsite.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]

        public async Task<ActionResult<List<Category>>> GetAll()
        {
            return await _categoryService.getAllCategories();
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory([FromBody] Category category)
        {
            var ans = await _categoryService.addCategory(category);
            return ans;
        }
    }
}
