using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using michael_3038EFWebAPI.Data;

namespace michael_3038EFWebAPI.Service
{
    public class CategoryService : ICategoryService
    {
        private readonly HomeworkDBContext _HomeworkDBContext;
        public CategoryService(HomeworkDBContext HomeworkDBContext)
        {
            this._HomeworkDBContext = HomeworkDBContext;
        }

        public Category AddCategory(Category category)
        {
            this._HomeworkDBContext.Category.Add(category);
            this._HomeworkDBContext.SaveChanges();
            return category;
        }

        public bool DeleteCategory(int id)
        {
            var deleteCategory = this._HomeworkDBContext.Category.FirstOrDefault(x => x.Id == id);
            if (deleteCategory != null)
            {

                this._HomeworkDBContext.Category.Remove(deleteCategory);
                return this._HomeworkDBContext.SaveChanges() > 0;
            }

            return false;
        }

        public Category UpdateCategory(Category category)
        {

            var updateCategory = this._HomeworkDBContext.Category.FirstOrDefault(x => x.Id == category.Id);
            if (updateCategory != null)
            {
                updateCategory.CategoryLevel = category.CategoryLevel;
                updateCategory.CategoryName = category.CategoryName;
                updateCategory.ParentId = category.ParentId;

                this._HomeworkDBContext.SaveChanges();
                return updateCategory;
            }

            return category;
        }
        public List<Category> GetCategories()
        {

            var categories = from category in this._HomeworkDBContext.Category
                             select category;

            return categories.ToList();

        }
        public Category? GetCategoryByName(string name)
        {
            return this._HomeworkDBContext.Category.FirstOrDefault(x => x.CategoryName == name);//lambda expression
        }
    }
}
