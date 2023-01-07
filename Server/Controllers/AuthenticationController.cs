using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Shared.Entities.Remote.Request;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VerifiedSeller.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
     public class AuthenticationController : ControllerBase
    {
        private readonly ISystemUser _ISystemUser;
        public AuthenticationController(ISystemUser iSystemUser)
        {
            _ISystemUser = iSystemUser;
        }
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser(LoginRequest loginRequest)
        {
            var response= await Task.FromResult(_ISystemUser.LoginUser(loginRequest));

            if (response.Code==HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }
            
        }
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser(RegisterRequest registerRequest)
        {
            var response = await Task.FromResult(_ISystemUser.RegisterUser(registerRequest));
            if (response.Code == HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPost("ResetPassword")]
        public async Task<IActionResult> RegisterUser(ResetPasswordRequest resetPasswordRequest)
        {
            var response = await Task.FromResult(_ISystemUser.ResetPassword(resetPasswordRequest));
            if (response.Code == HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }

        }
        [HttpPut("ChangePassword")]
        public async Task<IActionResult> ChangePassword(SystemUserCredentials systemUserCredentials)
        {
            var response = await Task.FromResult(_ISystemUser.ChangePassword(systemUserCredentials));
            if (response.Code == HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("Contact")]
        public async Task<IActionResult> Contact(ContactRequest contactRequest)
        {
            var response = await Task.FromResult(_ISystemUser.ContactUser(contactRequest));
            if (response.Code == HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost("OptOut")]
        public async Task<IActionResult> DeRegister(OptOutRequest optOutRequest)
        {
            var response = await Task.FromResult(_ISystemUser.DeRegister(optOutRequest));
            if (response.Code == HttpStatusCode.OK.ToString())
            {
                return Ok(response);
            }
            else if (response.Code == HttpStatusCode.Unauthorized.ToString())
            {
                return Unauthorized(response);
            }
            else if (response.Code == HttpStatusCode.BadRequest.ToString())
            {
                return BadRequest(response);
            }
            else
            {
                return NotFound();
            }

        }


    }
}
