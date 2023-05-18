using Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{

    public class CategoryRepository : ICategoryRepository
    {
        StoreDbContext _storeDbContext;
        public CategoryRepository(StoreDbContext storeDbContext)
        {
            _storeDbContext = storeDbContext;

        }
        public async Task<List<Category>> getAllCategories()
        {
            return await _storeDbContext.Categories.ToListAsync();
        }
        public async Task<int> AddCategory(Category category)
        {
            await _storeDbContext.Categories.AddAsync(category);
            await _storeDbContext.SaveChangesAsync();
            return category.CategoryId;
        }
    }
}
