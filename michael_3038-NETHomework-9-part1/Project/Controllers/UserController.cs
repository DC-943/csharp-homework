using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using michael_3038_WebApiHomework.Models;
using michael_3038_WebApiHomework.ViewModel;
using System.Text;
using michael_3038_WebApiHomework.IService;
using System.Xml.Linq;
namespace michael_3038_WebApiHomework.Controllers
{
    //http://localhost:portnumber/api/User
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _service;
        public UserController(IUserService service)
        {
            _service = service;
        }

        #region Route Parameters Get
        [HttpGet]
        public JsonResult GetAllUsers()
        {
            var userList = _service.GetAll() as List<User>;
            return new JsonResult(new CommonResult<List<User>>() { IsSucess = true, Message = "successfully get user info", Result = userList });
        }

        //public IEnumerable<string> Get()
        //{
        //    throw new NotImplementedException();
        //}
        [HttpGet("{id}")]
        public JsonResult GetUserById(int id)
        {
            var user = _service.GetById(id);
            if (user == null)
            {
                return new JsonResult(new CommonResult<User>() { IsSucess = false, Message = "the user is not found", Result = null });
            }
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "get the user info", Result = user });
        }
        #endregion


        #region Get path string and query string parameters
        [HttpGet("{name}/{password}")]
        public JsonResult GetUserByNamePassword(string name, string password)
        {
            var user = _service.GetByNamePassword(name, password);
            if (user == null)
            {
               return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "the user is not found", Result = null });
            }
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully get path string ", Result = user });
        }
        
        public JsonResult GetUserByEmail(string email)
        {
            var user = _service.GetByEmail(email);
            if (user == null)
            {
                return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "the user is not found", Result = null });
            }
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
                return new JsonResult( new CommonResult<User>() { IsSucess = false, Message= "the user info is invalid", Errors= stringBuilder.ToString(), Result = user });
            }
            var newUser = _service.Add(user);

            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully got user info from body", Result = newUser });
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

        #endregion


        #region Put and Delete  
        [HttpPut("{password}")]
        public JsonResult PutUser([FromBody] User user) {

            //User user = new User()
            //{
            //    UserId = ,
            //    UserName = "JackMa",
            //    Email = "Jack.ma@gmail.com",
            //    Address = "jane street",
            //    Gender = GenderEnum.Male,
            //    Password = password,
            //    Phone = "0401449888",
            //};

            var userList = _service.Add(user);
            return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "successfully update password", Result = userList });

        }
        [HttpDelete("{id}")]
        public JsonResult DeleteUserById(int id)
        {

            var existingUser = _service.GetById(id);

            if (existingUser == null)
            {
                return new JsonResult(new CommonResult<User>() { IsSucess = true, Message = "not found.....", Result = null });
            }
            _service.Remove(id);
            return new JsonResult(new CommonResult<int>() { IsSucess = true, Message = "succcesfully deleting.....", Result = id });
        }

        #endregion

    }


}

