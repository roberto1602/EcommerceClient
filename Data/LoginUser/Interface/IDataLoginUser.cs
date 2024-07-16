using Entities;
using Utils;

namespace Data.LoginUser.Interface
{
    public interface IDataLoginUser
    {
        Task<Result<User>> GetCredentialUser(string identification);
    }
}
