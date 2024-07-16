using Entities;
using Microsoft.AspNetCore.Http;
using Utils;

namespace Data.UploadFileData.Interface
{
    public interface IUploadFileData
    {
        Task<Result<DocumentUpload>> SaveFileData(IFormFile file);
    }
}
