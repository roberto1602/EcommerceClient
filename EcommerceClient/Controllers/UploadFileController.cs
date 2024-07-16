using Business.UploadFile.Interface;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace EcommerceClient.Controllers
{
    [Route("api/upload-file")]
    [ApiController]
    public class UploadFileController : ControllerBase
    {
        private readonly IUploadFile _uploadFile;  
        public UploadFileController(IConfiguration configuration, IUploadFile uploadFile)
        {
            _uploadFile = uploadFile;
        }


        [HttpPost("upload-file", Name = "uploadfile")]
        [ProducesResponseType(typeof(Result<DocumentUpload>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<DocumentUpload>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<DocumentUpload>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SaveFile(IFormFile file)
        {
            try
            {
                var response = await _uploadFile.SaveFile(file);

                if (response.Error == true)
                {
                    if (response.Values != null)
                        return Ok(response.Values);
                }
                return NotFound(response);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected IActionResult InternalServerError(object obj)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, obj);
        }
    }
}
