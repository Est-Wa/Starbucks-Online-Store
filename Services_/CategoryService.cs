using Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<Category>> getAllCategories()
        {
            return await _categoryRepository.getAllCategories();
        }

        public async Task<int> addCategory(Category category)
        {
            return await _categoryRepository.AddCategory(category);
        }
    }
}
