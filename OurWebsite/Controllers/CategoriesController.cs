using AutoMapper;
using DTO;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Services;

namespace OurWebsite.Controllers
{
      [Route("api/[controller]")]
      [ApiController]
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoriesController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> GetAll()
        {
            List<Category> categories = await _categoryService.getAllCategories();
            List<CategoryDTO> categoriesDTO = _mapper.Map<List<Category>, List<CategoryDTO>>(categories);
            return Ok(categoriesDTO);
        }

        [HttpPost]
        public async Task<ActionResult<int>> CreateCategory([FromBody] CategoryDTO category)
        {
            var _category = _mapper.Map<Category>(category);
            if(ModelState.IsValid) {
                var ans = await _categoryService.addCategory(_category);
                return ans;
            }
            return new JsonResult("Something went wrong") { StatusCode = 500 };
        }
    }
}
