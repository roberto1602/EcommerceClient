using Entities.ModelDto;
using Utils;

namespace Business.DownloadFile.Interface
{
    public interface IBusinessFileDownLoad
    {
        Task<Result<List<ClientDto>>> GetFile();
    }
}
