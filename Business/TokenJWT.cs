using Entities.configuration;
using Entities.ModelDto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Utils;

namespace Business
{
    public class TokenJWT: UResult
    {
        private readonly JwtSettings _jwtSettings;
        public TokenJWT(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        public dynamic GenerarTokenJWT(UserDto user)
        {
            var data = JsonConvert.DeserializeObject<dynamic>(user.ToString()!);
            var result = new Result<UserDto>();


            //se especifica todo lo que se encapsula en el token
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                new Claim("password", user.Password!),
                new Claim("email", user.Email!)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var singIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //crear token
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: singIn
                );

            return new
            {
                success = true,
                message = "exito",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            };
        }

    }
}
