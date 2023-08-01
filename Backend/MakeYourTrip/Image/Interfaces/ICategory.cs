using Image.Models;

namespace Image.Interfaces
{
    public interface ICategory
    {
        public Task<Category?> AddCategory(Category category);
        public Task<Category?> DeleteCategory(int categoryId);
        public Task<Category?> GetCategory(int categoryId);
        public Task<ICollection<Category>?> GetAllCategories();
    }
}
