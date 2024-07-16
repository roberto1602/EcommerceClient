using Business.RegisterUser.Interface;
using Data.LoginUser.Interface;
using Entities;
using Entities.configuration;
using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Runtime.ExceptionServices;
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
           var tokenJWT = new TokenJWT((IOptions<JwtSettings>)_jwtSettings);

            try
            {
                if (!ValidateUser(identification))
                    return Error<UserDto>("parameters are not specified", null);

                var responseUser = await _dataLoginUser.GetCredentialUser(identification);
                
                result.Values = MapUsers(responseUser.Values!);
                var getToken = tokenJWT.GenerarTokenJWT(result.Values);


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
