using Entities;
using Entities.ModelDto;
using Utils;

namespace Data.DownLoadFile.Interface
{
    public interface IDataFileDownLoad
    {
        public Task<Result<List<Client>>> GetFileData();
    }
}
