using Entities;
using Microsoft.AspNetCore.Http;
using Utils;

namespace Business.UploadFile.Interface
{
    public interface IUploadFile
    {
        public Task<Result<DocumentUpload>> SaveFile(IFormFile file);
    }
}
