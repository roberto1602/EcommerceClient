using Business.UploadFile.Interface;
using Data.UploadFileData.Interface;
using Entities;
using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Utils;

namespace Business.UploadFile.Implementation
{
    public class UploadFile(IUploadFileData uploadFileData) : UResult, IUploadFile
    {
        private readonly IUploadFileData _uploadFileData = uploadFileData;

        public async Task<Result<DocumentUpload>> SaveFile(IFormFile file)
        {
            var result = new Result<DocumentUpload>();

            var saveFile = await _uploadFileData.SaveFileData(file);
            
            if (saveFile != null)
                return Error<DocumentUpload>(StatusCodes.Status404NotFound.ToString("file not save"), null!);

            result.Values = saveFile!.Values; 
            return result;
        }
    }
}
