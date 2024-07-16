using Business.DownloadFile.Interface;
using Entities.ModelDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace EcommerceClient.Controllers
{
    [Route("api/download-file")]
    [ApiController]
    public class DownloadFileController : ControllerBase
    {
        private readonly IBusinessFileDownLoad _businessFileDownLoad;
        public DownloadFileController(IBusinessFileDownLoad businessFileDownLoad)
        {
            _businessFileDownLoad = businessFileDownLoad;
        }

        [HttpGet("download-file", Name = "downloadfile")]
        [ProducesResponseType(typeof(Result<ClientDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<ClientDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<ClientDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetFile()
        {
            try
            {
                var response = await _businessFileDownLoad.GetFile();

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
