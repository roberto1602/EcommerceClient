using Data.LoginUser.Interface;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.LoginUser.Implementation
{
    public class DataLoginUser : UResult, IDataLoginUser
    {
        private readonly ContexMain _contexMain;

        public DataLoginUser(ContexMain contexMain)
        {
            _contexMain = contexMain;
        }
        public async Task<Result<User>>GetCredentialUser(string identification)
        {
            var result = new Result<User>();

            try
            {
                var userQuery =  _contexMain.Users
               .Where(u => u.NumberIdentification == identification)
               .Select(u => new User
               {
                   Password = u.Password,
                   Email = u.Email
               })
               .FirstOrDefault();

                result = Ok(StatusCodes.Status200OK.ToString(), userQuery);
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }
            return result;
        }
    }
}
