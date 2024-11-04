using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Models;
using michael_3038EFWebAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace michael_3038EFWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CourseController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CourseController> logger)
        {
            this._categoryService = categoryService;
            this._logger = logger;
        }
        /// <summary>
        /// Add a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>

        // POST api/<CategoryController>
        [Authorize]
        [HttpPost]
        public CommonResult<Category> AddCategory(Category category)
        {
            this._logger.LogDebug("add category in category controller");
            this._logger.LogInformation("this is add category log in CategoryController LogInformation");
            var result = this._categoryService.AddCategory(category);
            return new CommonResult<Category>() { IsSucess = true, Result = result };
        }
        /// <summary>
        /// Delete a category
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>


        // DELETE api/<CategoryController>/5
        [Authorize]
        [HttpDelete("{id}")]
        public CommonResult<bool> DeleteCategory(int id)
        {
            var result = this._categoryService.DeleteCategory(id);
            return new CommonResult<bool>() { IsSucess = true, Result = result };

        }

        /// <summary>
        /// Update a category
        /// </summary>
        /// <param name="category"></param>
        /// <returns></returns>
        // PUT api/<CategoryController>/5
        [Authorize]
        [HttpPut]
        public CommonResult<Category> UpdateCategory([FromBody] Category category)
        {
            var result = this._categoryService.UpdateCategory(category);
            return new CommonResult<Category>() { IsSucess = true, Result = result };
        }

        /// <summary>
        /// Get all the categories
        /// </summary>
        /// <returns></returns>
        // GET: api/<CategoryControllers
        [Authorize]
        [HttpGet]
        public CommonResult<List<Category>> GetCategory()
        {
            var result = this._categoryService.GetCategories();
            return new CommonResult<List<Category>>() { IsSucess = true, Result = result };
        }

        /// <summary>
        /// Get cateogory by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET api/<CategoryController>/name
        [Authorize]
        [HttpGet("{name}")]
        public CommonResult<Category> GetCategoryByName(string name)
        {
            var result = this._categoryService.GetCategoryByName(name);
            return new CommonResult<Category>() { IsSucess = true, Result = result};
            
        }
 
   
     
    }
}
