using Entities;

namespace Services
{
    public interface ICategoryService
    {
        Task<int> addCategory(Category category);
        Task<List<Category>> getAllCategories();
    }
}