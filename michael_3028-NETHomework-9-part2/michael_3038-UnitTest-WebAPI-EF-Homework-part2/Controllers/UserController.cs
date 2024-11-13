using michael_3038EFWebAPI.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using michael_3038EFWebAPI.Models;

namespace michael_3038EFWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("Users/")]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var users = await _userService.GetUserAsync();
            users = users.Where(x => x.Id > 4).ToList();
            return Ok(users);
        }

    }
}
