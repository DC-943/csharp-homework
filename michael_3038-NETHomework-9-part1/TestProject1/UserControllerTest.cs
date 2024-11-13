

using System.Diagnostics.CodeAnalysis;
using michael_3038_WebApiHomework.Controllers;
using michael_3038_WebApiHomework.IService;
using michael_3038_WebApiHomework.Service;
using michael_3038_WebApiHomework.ViewModel;
using Microsoft.AspNetCore.Mvc;
using michael_3038_WebApiHomework.Models;
using System.ComponentModel.Design.Serialization;
using Microsoft.AspNetCore.Hosting.Server;



namespace TestProject1
{
    public class UserControllerTest
    {

        private readonly UserController _controller;
        private readonly IUserService _service;

        public UserControllerTest()
        {
            _service = new UserService();
            _controller = new UserController(_service);
        }

        [Fact]
        public void GetAllUserTest_Should_Return_AllUsers()
        {
            //Arragne
            //Act
            var result = _controller.GetAllUsers();

            //Assert
            Assert.IsType<JsonResult>(result);
            var jsonResult = result as JsonResult;

            Assert.IsType<CommonResult<List<User>>>(jsonResult.Value);
            var commonResult = jsonResult.Value as CommonResult<List<User>>;

            Assert.NotNull(commonResult);
            Assert.IsType<List<User>>(commonResult.Result);

            var listUsers = commonResult.Result as List<User>;

            Assert.Equal(5, listUsers.Count);
            Assert.True(listUsers.Count == 5);

        }

        [Theory]
        [InlineData(3, 3, "Joe Biden")]
        [InlineData(1, 7, "Jack Ma")]
        public void GetUserById_Should_Return_Specific_User(int id, int id2, string expectedUserName)
        {
            //Arrange
            int validId = id;
            int invalidId = id2;

            //Act
            var result = _controller.GetUserById(validId);
            var notFoundResult = _controller.GetUserById(invalidId);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.IsType<JsonResult>(notFoundResult);

            var jsonResult = result as JsonResult;
            var jsonResult2 = notFoundResult as JsonResult;

            Assert.IsType<CommonResult<User>>(jsonResult.Value);
            Assert.IsType<CommonResult<User>>(jsonResult2.Value);

            var commonResult = jsonResult.Value as CommonResult<User>;
            var commonResult2 = jsonResult.Value as CommonResult<User>;

            Assert.True(commonResult.IsSucess == true);
            Assert.False(commonResult2.IsSucess == false);

          //  Assert.NotNull(commonResult);

            Assert.IsType<User>(commonResult.Result);

            var user = commonResult.Result as User;

            Assert.Equal(validId, user.UserId);
            Assert.Equal(expectedUserName, user.UserName);
   
        }

        [Theory]
        [InlineData("Joe.Biden@gmail.com", "Joe.Biden@gmail.com", "Joe Biden")]
        [InlineData("Donald.Trump@gmail.com", "Donald@gmail.com", "Donald Trump")]
        public void GetUserByEmail_Should_Return_Specific_User(string email, string email2, string expectedUserName)
        {
            //Arrange
            string validEmail = email;
            string invalidEmail = email;

            //Act
            var result = _controller.GetUserByEmail(validEmail);
            var notFoundResult = _controller.GetUserByEmail(invalidEmail);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.IsType<JsonResult>(notFoundResult);

            var jsonResult = result as JsonResult;
            var jsonResult2 = notFoundResult as JsonResult;

            Assert.IsType<CommonResult<User>>(jsonResult.Value);
            Assert.IsType<CommonResult<User>>(jsonResult2.Value);

            var commonResult = jsonResult.Value as CommonResult<User>;
            var commonResult2 = jsonResult.Value as CommonResult<User>;

            Assert.True(commonResult.IsSucess == true);
            Assert.False(commonResult2.IsSucess == false);

            Assert.NotNull(commonResult);

            Assert.IsType<User>(commonResult.Result);

            var user = commonResult.Result as User;

            Assert.Equal(validEmail, user.Email);
            Assert.Equal(expectedUserName, user.UserName);

        }


        [Theory]
        [InlineData("Joe Biden", "Joe Biden", "666", "666", "Joe.Biden@gmail.com" )]
        [InlineData("Donald Trump","Donald", "888", "8888", "Donald.Trump@gmail.com")]
        public void GetUserByNamePassword_Should_Return_Specific_User(string name, string fakeName, string password, string fakePassword, string expectedEmail)
        {
            //Arrange
            string validName = name;
            string invalidName = fakeName;

            string validPassword = password;
            string invalidPassword = fakePassword;

            //Act
            var result = _controller.GetUserByNamePassword(name, password);
            var notFoundResult = _controller.GetUserByNamePassword(fakeName, fakePassword);

            //Assert
            Assert.IsType<JsonResult>(result);
            Assert.IsType<JsonResult>(notFoundResult);

            var jsonResult = result as JsonResult;
            var jsonResult2 = notFoundResult as JsonResult;

            Assert.IsType<CommonResult<User>>(jsonResult.Value);
            Assert.IsType<CommonResult<User>>(jsonResult2.Value);

            var commonResult = jsonResult.Value as CommonResult<User>;
            var commonResult2 = jsonResult.Value as CommonResult<User>;

            Assert.True(commonResult.IsSucess == true);
            Assert.False(commonResult2.IsSucess == false);

            Assert.NotNull(commonResult);

            Assert.IsType<User>(commonResult.Result);

            var user = commonResult.Result as User;

            Assert.Equal(validName, user.UserName);
            Assert.Equal(validPassword, user.Password);

            Assert.Equal(expectedEmail, user.Email);

        }


        [Fact]
        public void AddUserTest_Should_Add_NewUser()
        {
            //Arrange
            var completeUser = new User()
            {
                UserName = "Joe Hockey",
                Email = "Joe.Hockey@gamil.com",
                Address = "hockey street",
                Gender = GenderEnum.Male,
                Password = "666",
                Phone = "0408899746"
            };

            //Act
            var createdResponse = _controller.AddUser(completeUser);

            //Assert
            Assert.IsType<JsonResult>(createdResponse);
            var jsonResult = createdResponse as JsonResult;

            Assert.IsType<CommonResult<User>>(jsonResult.Value);
            var commonResult = jsonResult.Value as CommonResult<User>;

            Assert.True(commonResult.IsSucess == true);

            Assert.NotNull(commonResult);

            Assert.IsType<User>(commonResult.Result);

            var user = commonResult.Result as User;

            Assert.Equal(completeUser.UserName, user.UserName);
            Assert.Equal(completeUser.Email, user.Email);
            Assert.Equal(completeUser.Address, user.Address);
            Assert.Equal(completeUser.Gender, user.Gender);
            Assert.Equal(completeUser.Password, user.Password);
            Assert.Equal(completeUser.Phone, user.Phone);

            //Arrange
            var incompleteBook = new User()
            {
                UserName = "Joe Hockey",
                Email = "Joe.Hockey@gamil.com",
                Address = "hockey street",
            };

            //Act
            _controller.ModelState.AddModelError("Gender", "Gender is a requried filed");
            var badResponse = _controller.AddUser(incompleteBook);

            //Assert
            Assert.IsType<JsonResult>(badResponse);

            var badJsonResult = badResponse as JsonResult;

            Assert.IsType<CommonResult<User>>(badJsonResult.Value);
            var badCommonResult = jsonResult.Value as CommonResult<User>;

            Assert.False(badCommonResult.IsSucess == false);

        }

        [Theory]
        [InlineData(3, 7)]
        public void DeleteUserkByIdTest_Should_Remove_Specific_User(int id, int id2)
        {
            //Arrange
            var validId = id;
            var invalidId = id2;

            //Act
            var notFoundResult = _controller.DeleteUserById(invalidId);

            //Assert
            Assert.IsType<JsonResult>(notFoundResult);
            Assert.Equal(5, _service.GetAll().Count());

            //Act
            var okResult = _controller.DeleteUserById(validId);

            //Assert
            Assert.IsType<JsonResult>(okResult);
           
            Assert.Equal(4, _service.GetAll().Count());
        }
   


    }
}