

using michael_3038EFWebAPI.Models;

namespace michael_3038EFWebAPI.IService
{
    public interface ICategoryService
    {
        public Category AddCategory(Category category);
        public bool DeleteCategory(int id);
        public Category UpdateCategory(Category category);

        public List<Category> GetCategories();

        public Category? GetCategoryByName(string name);

     
    }
}
