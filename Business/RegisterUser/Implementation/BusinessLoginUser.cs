using Business.RegisterUser.Interface;
using Data.LoginUser.Interface;
using Entities;
using Entities.configuration;
using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.ExceptionServices;
using System.Security.Claims;
using System.Text;
using Utils;

namespace Business.RegisterUser.Implementation
{
    public class BusinessLoginUser : UResult, IBusinessLoginUser
    {
        private readonly IDataLoginUser _dataLoginUser;
        private readonly JwtSettings _jwtSettings;
        public BusinessLoginUser(IDataLoginUser dataLoginUser, IOptions<JwtSettings> jwtSettings)
        {
            _dataLoginUser = dataLoginUser;
            _jwtSettings = jwtSettings.Value;
        }

        public async Task<Result<UserDto>> GetCredentialUser(string identification)
        {
            var result = new Result<UserDto>();
            try
            {
                if (!ValidateUser(identification))
                    return Error<UserDto>("parameters are not specified", null);

                var userToken = await _dataLoginUser.GetCredentialUser(identification);

                                
                result.Values = MapUsers(userToken.Values!);
                GenerateToken(result.Values);

                //if (responseUser.Values == null)
                //    return Error<UserDto>(StatusCodes.Status404NotFound.ToString("transaccion no realizada"));

            }
            catch (Exception ex) 
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            result = Ok(StatusCodes.Status200OK.ToString(), result.Values);

            return result;
        }


        public string GenerateToken(UserDto user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            //se especifica todo lo que se encapsula en el token
            var claims = new[]
            {
                new Claim(ClaimTypes.Email, user.Email!),
                new Claim(ClaimTypes.Anonymous, user.Password!)
            };

            //crear token
            var token = new JwtSecurityToken(
                _jwtSettings.Issuer,
                _jwtSettings.Audience,
                claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: credentials
                );

            var jwtSecurity = new JwtSecurityTokenHandler().WriteToken(token);

            return jwtSecurity;
        }

        private static bool ValidateUser(string identification)
        {
            if (string.IsNullOrEmpty(identification))
                return false;
            if (identification.Length < 2 )
                return false;
            return true;
        }

        private static UserDto MapUsers(User user)
        {
            return new UserDto()
            {
                IdUsuario = user.IdUsuario,
                NumberIdentification = user.NumberIdentification,
                Username = user.Username,
                Password = user.Password,
                Email = user.Email,
                IdRole = user.IdRole,
            };
        }

        public Task<Result<UserDto>> GetUser(string identification)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDto>> SaveUser(string identification)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDto>> UpdateUser(string identification)
        {
            throw new NotImplementedException();
        }

        public Task<Result<UserDto>> DeleteUser(string identification)
        {
            throw new NotImplementedException();
        }
    }
}
