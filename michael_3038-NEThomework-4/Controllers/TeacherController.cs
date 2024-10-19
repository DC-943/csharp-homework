using michael_3038_WebApiHomework.Models;
using michael_3038_WebApiHomework.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace michael_3038_WebApiHomework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        #region Route Parameters
        [HttpGet]
        public JsonResult Get()
        {
            Teacher teacher = new Teacher()
            { TeacherId = 1, Department = "IT", Description = "HTML Teacher", Specialty = "HTML" };
            return new JsonResult(teacher);
        }

        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            Teacher teacher = new Teacher()
            { TeacherId = id, Department = "IT", Description = "HTML Teacher", Specialty = "HTML" };
            return new JsonResult(teacher);
        }

        //query string paramter
        [HttpGet] 
        public JsonResult Get([FromQuery] int id, [FromQuery] string Dept)
        {
            Teacher teacher = new Teacher()
            { TeacherId = id, Department = Dept, Description = "HTML Teacher", Specialty = "HTML" };
            return new JsonResult(teacher);
        }
        #endregion

        #region POST PUT
        [HttpPost]
        public IActionResult post([FromBody] Teacher teacher)
        {
            
            
            
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "successfully posting", Result = teacher });
        }

        [HttpPost]
        public IActionResult POST([FromForm] Teacher teacher)
        {
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "successfully posting form data", Result = teacher });
        }

        [HttpPut("{id}")]
        public IActionResult PUT(int id, [FromBody] Teacher teacher)
        {
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "successfully updating data", Result = teacher });
        }
        #endregion

        #region
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "successfully deleting data", Result = id });
        }
        #endregion


    }



}
