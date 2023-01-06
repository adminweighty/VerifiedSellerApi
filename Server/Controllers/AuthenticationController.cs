using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Shared.Entities.Remote.Request;
using VerifiedSeller.Shared.Entities.Remote.Response;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace GlobalStraw.Web.Server.Controllers
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
        [Authorize]
        public async Task<ResponseInfo<LoginResult>> LoginUser(LoginRequest loginRequest)
        {
            return await Task.FromResult(_ISystemUser.LoginUser(loginRequest));
        }
        [HttpPost("Register")]
        [Authorize]
        public async Task<ResponseInfo> RegisterUser(RegisterRequest registerRequest)
        {
            return await Task.FromResult(_ISystemUser.RegisterUser(registerRequest));
        }
        [HttpPost("ResetPassword")]
        [Authorize]
        public async Task<ResponseInfo> RegisterUser(ResetPasswordRequest resetPasswordRequest)
        {
            return await Task.FromResult(_ISystemUser.ResetPassword(resetPasswordRequest));
        }
        [HttpPut("ChangePassword")]
        [Authorize]
        public async Task<ResponseInfo> ChangePassword(SystemUserCredentials systemUserCredentials)
        {
            return await Task.FromResult(_ISystemUser.ChangePassword(systemUserCredentials));
        }

        [HttpPost("Contact")]
        [Authorize]
        public async Task<ResponseInfo> Contact(ContactRequest contactRequest)
        {
            return await Task.FromResult(_ISystemUser.ContactUser(contactRequest));
        }

        [HttpPost("OptOut")]
        [Authorize]
        public async Task<ResponseInfo> DeRegister(OptOutRequest optOutRequest)
        {
            return await Task.FromResult(_ISystemUser.DeRegister(optOutRequest));
        }
    }
}
