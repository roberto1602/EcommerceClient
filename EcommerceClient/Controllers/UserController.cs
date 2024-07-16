using Business.RegisterUser.Interface;
using Entities.ModelDto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utils;

namespace EcommerceClient.Controllers
{
    [Route("api/user")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IBusinessLoginUser _businessLoginUser;
        public UserController(IBusinessLoginUser businessLoginUser)
        {
            _businessLoginUser = businessLoginUser;
        }

        [HttpGet("user-login", Name = "UserLogin")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetCredentialUser(string identification)
        {
            try
            {
                var response = await _businessLoginUser.GetCredentialUser(identification);

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

        [HttpGet("get-user", Name = "GetUser")]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(Result<UserDto>), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetUser(string identification)
        {
            try
            {
                var response = await _businessLoginUser.GetUser(identification);

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
