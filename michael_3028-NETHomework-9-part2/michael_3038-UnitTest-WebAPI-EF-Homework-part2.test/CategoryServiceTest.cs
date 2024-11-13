using Moq;
using michael_3038EFWebAPI.Data;
using Microsoft.EntityFrameworkCore;
using michael_3038EFWebAPI.Models;
using michael_3038EFWebAPI.Service;
using System.Collections.Generic;
using System.Linq;
using Org.BouncyCastle.Security;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace michael_3038_EF_WebAPI.test
{
    public class CategoryServiceTest
    {
        private readonly Mock<HomeworkDBContext> _mockContext;
        private readonly CategoryService _categoryService;
        private readonly Mock<DbSet<Category>> _mockCategorySet;
       // private readonly Mock<Category> _mockCategory;
        public CategoryServiceTest() 
        {
            var categoryList = new List<Category>
            {
                new Category { Id = 1, CategoryName = "software", CategoryLevel = 1, Parent = null, ParentId = null },
                new Category { Id = 2, CategoryName = "hardware", CategoryLevel = 1, Parent = null, ParentId = null },
                new Category { Id = 3, CategoryName = "architecture", CategoryLevel = 1, Parent = null, ParentId = null }
            }.AsQueryable();

          
            _mockCategorySet = new Mock<DbSet<Category>>();

            _mockCategorySet.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categoryList.Provider);
            _mockCategorySet.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categoryList.Expression);
            _mockCategorySet.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categoryList.ElementType);
            _mockCategorySet.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(categoryList.GetEnumerator());

            _mockContext = new Mock<HomeworkDBContext>();
         //   _mockCategory = new Mock<Category>();
            _mockContext.Setup(m => m.Categories).Returns(_mockCategorySet.Object);
            _categoryService = new CategoryService(_mockContext.Object);

        }

        [Fact]
        public void CreateCategoryTest_saves_a_category_via_context()
        {
            //arrage
            Category testCategory = new Category { Id = 1, CategoryName = "software", CategoryLevel = 1, Parent = null, ParentId = null };

           // EntityEntry<TEntity> Add(TEntity entity);
           //_mockCategorySet.Setup(x => x.Add(It.IsAny<Category>())).Returns(_mockCategory.Object);
           
            //act
            var service = new CategoryService(_mockContext.Object);
            var result  = _categoryService.AddCategory(testCategory);
          
            //assert
            _mockCategorySet.Verify(m => m.Add(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());
            
        }

        [Fact]
        public void DeleteCategoryTest_ShouldDeleteCategory()
        {
            Category testCategory = new Category { Id = 1, CategoryName = "software", CategoryLevel = 1, Parent = null, ParentId = null };
            
            _mockCategorySet.Setup(m => m.Find(It.IsAny<int>())).Returns(testCategory);

            _categoryService.DeleteCategory(1);

            _mockCategorySet.Verify(m => m.Remove(It.Is<Category>(c => c.Id == 1)), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }



        [Fact]
        public void UpdateCategoryTest_saves_a_category_via_context()
        {
            //arrage
            Category updateCategory = new Category { Id = 1, CategoryName = "software", CategoryLevel = 1, Parent = null, ParentId = null };

            // EntityEntry<TEntity> Add(TEntity entity);
            //_mockCategorySet.Setup(x => x.Add(It.IsAny<Category>())).Returns(_mockCategory.Object);

            //act
           // _mockCategorySet.Setup(m => m.Find(It.IsAny<int>())).Returns(updateCategory);
            var result = _categoryService.UpdateCategory(updateCategory);

            //assert
            Assert.NotNull(result);
            Assert.Equal("software", result.CategoryName);
            Assert.Equal(1, result.Id);

            //_mockCategorySet.Verify(m => m.FirstOrDefault(It.IsAny<Category>()), Times.Once);
            _mockContext.Verify(m => m.SaveChanges(), Times.Once());

        }

        [Fact]
        public void GetCategoriesTest_should_return_all_categories()
        {

            var categories = _categoryService.GetCategories();

            Assert.NotNull(categories);
            Assert.Equal(3, categories.Count);
            Assert.Equal("architecture", categories[0].CategoryName);
            Assert.Equal("hardware", categories[1].CategoryName);
            Assert.Equal("software", categories[2].CategoryName);

        }

        [Fact]
        public void GetCategoryByNameTest_Should_Return_ACategory()
        {
            Category testCategory = new Category { Id = 1, CategoryName = "software", CategoryLevel = 1, Parent = null, ParentId = null };
            var category = _categoryService.GetCategoryByName("software");

            Assert.NotNull(category);
            Assert.Equal(1, category.CategoryLevel);
            Assert.Equal("software", category.CategoryName);
            Assert.Equal(1, category.Id);
        }


    }



}