using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Models;
using michael_3038EFWebAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace michael_3038EFWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly ICourseService _courseService;
        private readonly ILogger<CourseController> _logger;
        public CourseController(ICourseService courseService, ILogger<CourseController> logger)
        {
            this._courseService = courseService;
            this._logger = logger;
        }

        // POST api/<CourseController>
        [HttpPost]
        public CommonResult<bool> AddCourse(Course course)
        {
            this._logger.LogWarning("this is my log in CourseController");
            this._logger.LogInformation("this is my log in CourseController LogInformation");
            var result = this._courseService.AddCourse(course);
            return new CommonResult<bool>() { IsSucess = true, Result = result };
        }

        // DELETE api/<CourseController>/id
        [Authorize]
        [HttpDelete("{id}")]
        public CommonResult<bool> DeleteCourse(int id)
        {
            var result = this._courseService.DeleteCourse(id);
            return new CommonResult<bool>() { IsSucess = true, Result = result };
        }

        //PUT api/<CourseController>
        [Authorize]
        [HttpPut]
        public async Task<CommonResult<Course>> UpdateCourseAsync(Course course)
        {
            var result = await this._courseService.UpdateCourseAsync(course);
            return new CommonResult<Course>() { IsSucess = true, Message = "successfully update a course", Result = result };
        }

        //GET api/<CourseController>
        [Authorize]
        [HttpGet]
        public CommonResult<List<Course>> GetCourse()
        {
            var result = this._courseService.GetCourse();
            return new CommonResult<List<Course>>() { IsSucess = true, Message = "", Result = result };
        }

        //GET api/<CourseController>/name
        [Authorize]
        [HttpGet("{name}")]
        public CommonResult<Course> GetCourseByName(string name)
        {
            var result = this._courseService.GetCourseByName(name);
            return new CommonResult<Course>() { IsSucess = true, Result = result };
        }

    }
}
