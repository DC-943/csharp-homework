using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using michael_3038_WebApiHomework.Models;
using michael_3038_WebApiHomework.ViewModel;
using System.Text;
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
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully get user info", Result = user });
        }
        //public IEnumerable<string> Get()
        //{
        //    throw new NotImplementedException();
        //}

        [HttpGet("{id}")]
        public JsonResult GetUserInfoById(int id)
        {
            User user = new User()
            { UserId = id, UserName = "Jack Ma", Email = "Jack.ma@gamil.com", Address = "jane street", Gender = GenderEnum.Male, Password = "123", Phone = "0408999797" };
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully get user info by Id", Result = user });
        }
        #endregion


        #region Get path string and query string parameters
        [HttpGet("{name}/{password}")]
        public JsonResult GetUserInfoByMultiParams(string name, string password)
        {
            User user = new User()
            { UserId = 1, UserName = name, Email = "Jack.ma@gamil.com", Address = "jane street", Gender = 0, Password = password, Phone = "0249218888" };
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully get path string ", Result = user });
        }
        
        public JsonResult GetUserInfoByEmail(string email)
        {
            User user = new User()
            {UserId =1, UserName = "username", Email = email, Address = "jane street", Gender = 0, Password = "123", Phone = "0249228888" };
            return new JsonResult(new CommonResult<User>() {IsSucess = true, Message= "successfully get query string by email", Result = user});
        }
        #endregion


        #region Post Request Body and form Parameters
        [HttpPost]
        public JsonResult AddUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in ModelState.Keys)
                {
                    stringBuilder.Append(item + ": ");
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {
                            stringBuilder.Append(error.ErrorMessage + " ");
                        }
                    }
                    stringBuilder.AppendLine();
                }
                return new JsonResult( new CommonResult<User>() { IsSucess = false, Message="the user info is invalid", Errors= stringBuilder.ToString(), Result = user });
            }
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully got user info from body", Result = user });
        }
        [HttpPost]
        public JsonResult AddUserFormData([FromForm] User user)
        {
            if (!ModelState.IsValid)
            {
              
                StringBuilder stringBuilder = new StringBuilder();
                foreach (var item in ModelState.Keys)
                {
                    stringBuilder.Append(item + ": ");
                    if (ModelState[item].Errors != null && ModelState[item].Errors.Count > 0)
                    {
                        foreach (var error in ModelState[item].Errors)
                        {
                            stringBuilder.Append(error.ErrorMessage + " ");
                        }
                    }
                    stringBuilder.AppendLine();
                }
                return new JsonResult(new CommonResult<User>() { IsSucess = false, Message = "the user info is invalid", Errors = stringBuilder.ToString(), Result = user});
            }
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "succcesfully get info from form", Result = user });
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
                Password = password,
                Phone = "0401449888",
            };
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully update password", Result = user });

        }
        [HttpDelete("{email}")]
        public JsonResult DeleteUserById(int id)
        {
            return new JsonResult(new CommonResult<int>() { IsSucess = true, Message = "succcesfully deleting.....", Result = id });
        }
        #endregion
    }


}

