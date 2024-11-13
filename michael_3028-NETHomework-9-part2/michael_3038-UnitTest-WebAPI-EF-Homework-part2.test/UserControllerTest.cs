using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using michael_3038EFWebAPI.IService;
using michael_3038EFWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using michael_3038EFWebAPI.Controllers;
using System.Configuration;

namespace michael_3038_EF_WebAPI.test
{
    public class UserControllerTest
    {
        private readonly IUserService _mockUserService;


        public UserControllerTest()
        {
            //made stubbed properties fully lazy.
            //(Mock.Of<T> traditionally calls SetupAllProperties, which stubs all properties.) 
            //new Mock<IUserService>();
            _mockUserService = Mock.Of<IUserService>();
            //Mock Property
            //注意如果没有下面的setup 后面一行给属性赋值是没有作用的
            //but you're not mocking the class you're mocking the interface - and that interface knows nothing of your class implementatio
            var mockerProductService = new Mock<IUserService>();
            //mockerProductService.SetupProperty(x => x.EditTime);

        }

        [Fact]
        public async Task GetUsersAyncTest_Should_Retrun_Users()
        {
            //Arrange
            IList<User> mockUsers = new List<User>();

            using (StreamReader reader = new StreamReader(@"E:\JR bootcamp fullstack-net\lecture-22 NET-Unit Test\michael_3038-EF-WebAPI.test\MockData\posts.json"))
            {
                var userStringValue = reader.ReadToEnd();
                mockUsers = System.Text.Json.JsonSerializer.Deserialize<IList<User>>(userStringValue, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }

            var controller = new UserController(_mockUserService);
            Mock.Get(_mockUserService).Setup(x => x.GetUserAsync()).Returns(Task.FromResult(mockUsers));

            //Act
            var users = await controller.GetUsers();

            //Assert
            Assert.IsType<OkObjectResult>(users.Result);
            Assert.NotNull(users.Result as OkObjectResult);
            var result = users.Result as OkObjectResult;

            Assert.True((result.Value as IList<User>).Count == 96);
        }

    }
}
