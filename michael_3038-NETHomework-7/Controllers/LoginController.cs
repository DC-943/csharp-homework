using michael_3038EFWebAPI.Service;
using michael_3038EFWebAPI.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using michael_3038EFWebAPI.IService;


namespace michael_3038EFWebAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class LoginController : ControllerBase
    {
        private readonly CreateTokenService _createTokenService;
        private readonly IUserService _userService;
        public LoginController(CreateTokenService createTokenService, IUserService userService)
        {
            this._createTokenService = createTokenService;
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<CommonResult<LoginOutput>> LoginAsync(LoginInput loginInput)
        {
            CommonResult<LoginOutput> commonResult = new CommonResult<LoginOutput>();
            var user = await this._userService.GetUserByNameAsync(loginInput.UserName);
            if (user == null)
            {
                commonResult.IsSucess = false;
                commonResult.Message = "";
                return commonResult;
            }

            if (user.Password == loginInput.Password)
            {
                Dictionary<string, string> payBody = new Dictionary<string, string>();
                payBody.Add("UserId", user.Id.ToString());
                payBody.Add("UserName", user.UserName);
                payBody.Add("Email",user.Email);
                var accessToken = this._createTokenService.CreateToken(payBody);
                commonResult.IsSucess = true;
                commonResult.Message = "";
                commonResult.Result = new LoginOutput()
                {
                    AccessToken = accessToken,
                    UserName = loginInput.UserName,
                };
                return commonResult;
            }

            commonResult.IsSucess = false;
            commonResult.Message = "";
            return commonResult;
        }
    }

}
