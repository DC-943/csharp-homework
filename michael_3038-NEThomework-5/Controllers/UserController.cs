using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using michael_3038_WebApiHomework.Models;
using michael_3038_WebApiHomework.ViewModel;
namespace michael_3038_WebApiHomework.Controllers
{
    //http://localhost:portnumber/api/User
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        #region Route Parameters Get
        [HttpGet]
        public JsonResult GetUserInfo()
        {
            User user = new User() 
            {UserId=1, UserName = "Jack Ma", Email="Jack.ma@gamil.com", Address = "jane street", Gender = GenderEnum.Male, Password = "123", Phone="0408899796"};
            return new JsonResult(user);
        }
        [HttpGet("{id}")]
        public JsonResult GetUserInfoById(int id)
        {
            User user = new User()
            { UserId = id, UserName = "Jack Ma", Email = "Jack.ma@gamil.com", Address = "jane street", Gender = GenderEnum.Male, Password = "123", Phone = "0408999797" };
            return new JsonResult(user);
        }
        #endregion


        #region Get path string  and  Query String Parameters
        [HttpGet("{name}/{password}")]
        public JsonResult GetUserInfoByMultiParams(string name, string password)
        {
            User user = new User()
            {UserId =1, UserName = name, Email = "Jack.ma@gamil.com", Address="jane street", Gender = 0, Password = password, Phone = "0249218888" };
            return new JsonResult(user);
        }
        public JsonResult GetUserInfoByNameAndPassword(string email)
        {
            User user = new User()
            {UserId =1, UserName = "username", Email = email, Address = "jane street", Gender = 0, Password = "123", Phone = "0249228888" };
            return new JsonResult(user);
        }
        #endregion


        #region Post Request Body and form Parameters
        [HttpPost]
        public JsonResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult( new CommonResult() { IsSucess = false, Message = "info is invalid, please enter again" });
            }
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "successfully creating a new user", Result = user });
        }
        [HttpPost]
        public JsonResult AddUserFormData([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(new CommonResult() { IsSucess = false, Message = "info is invalid, please enter again" });
            }
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "succcesfully creating a new from form data", Result = user });
        }
        [HttpPut("{email}")]
        #endregion


        #region Put and Delete
        public JsonResult PutUser(int id, [FromBody] string password) {

            User user = new User()
            {
                UserId = id,
                UserName = "JackMa",
                Email = "Jack.ma@gmail.com",
                Address = "jane street",
                Gender = GenderEnum.Male,
                Password = "321",
                Phone = "0401449888",
            };
            return new JsonResult(user);

         }
        [HttpDelete("{email}")]
        public JsonResult DeleteUserById(int id)
        {
            return new JsonResult(new CommonResult() { IsSucess = true, Message = "succcesfully deleting....." });
        }
        #endregion
    }


}

