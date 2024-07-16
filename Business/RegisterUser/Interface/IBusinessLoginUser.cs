using Entities;
using Entities.ModelDto;
using Utils;

namespace Business.RegisterUser.Interface
{
    public interface IBusinessLoginUser
    {
        Task<Result<UserDto>> GetCredentialUser(string identification);
        Task<Result<UserDto>> GetUser(string identification);
        Task<Result<UserDto>> SaveUser(string identification);
        Task<Result<UserDto>> UpdateUser(string identification);
        Task<Result<UserDto>> DeleteUser(string identification);
    }
}
