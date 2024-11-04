using michael_3038EFWebAPI.Config;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;


namespace michael_3038EFWebAPI.Service
{
    public class CreateTokenService
    {
        private readonly JWTConfig jWTConfig;

        public CreateTokenService(IOptions<JWTConfig> options)
        {
            this.jWTConfig = options.Value;
        }

        public string CreateToken(Dictionary<string, string> playBody)
        {
            var claims = new List<Claim>();
            foreach (var item in playBody)
                claims.Add(new Claim(item.Key, item.Value));

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(this.jWTConfig.SecrectKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
               issuer: this.jWTConfig.Issuer,
               audience: this.jWTConfig.Audience,
               claims: claims,
               expires: DateTimeOffset.Now.LocalDateTime.AddSeconds(this.jWTConfig.ExpireSecondes),
               signingCredentials: creds);

            var jwtHandel = new JwtSecurityTokenHandler();
            var accessToken = jwtHandel.WriteToken(token);

            return accessToken;
        }

    }
}
