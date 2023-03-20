using Entities;

namespace Repository
{
    public interface ICategoryRepository
    {
        Task<int> AddCategory(Category category);
        Task<List<Category>> getAllCategories();
    }
}