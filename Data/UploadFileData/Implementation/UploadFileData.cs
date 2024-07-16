using Data.UploadFileData.Interface;
using Entities;
using Entities.configuration;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.IO;
using System.Runtime.ExceptionServices;
using Utils;

namespace Data.UploadFileData.Implementation
{
    public class UploadFileData : UResult, IUploadFileData
    {
        private readonly ContexMain _contexMain;
        private readonly ServerRouteSettings _serverRoute;
        public UploadFileData(ContexMain contexMain, IOptions<ServerRouteSettings> serverRoute)
        {
            _contexMain = contexMain;
            _serverRoute = serverRoute.Value;
        }
        public async Task<Result<DocumentUpload>> SaveFileData(IFormFile file)
        {
            var result = new Result<DocumentUpload>();
            var documentUpload = new DocumentUpload();
            string documentRoute = Path.Combine(_serverRoute.Route!, file!.FileName);

            if (!Directory.Exists(documentRoute))
                Directory.CreateDirectory(documentRoute);

            try
            {
                FileStream fileStream = System.IO.File.Create(documentRoute);

                file.CopyTo(fileStream);
                fileStream.Flush();

                _contexMain.DocumentUploads.Add(documentUpload);
                await _contexMain.SaveChangesAsync();


                result.Values = documentUpload;
            }
            catch (Exception ex)
            {
                ExceptionDispatchInfo.Capture(ex).Throw();
            }

            return result;
        }
    }
}
