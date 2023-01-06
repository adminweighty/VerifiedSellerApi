using VerifiedSeller.Server.AuthenticationManager;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Server.Models;
using VerifiedSeller.Shared.Entities.Remote.Request;
using VerifiedSeller.Shared.Entities.Remote.Response;
using LoginRequest = VerifiedSeller.Shared.Entities.Remote.Request.LoginRequest;
using LoginResult = VerifiedSeller.Shared.Entities.Remote.Response.LoginResult;
using RegisterRequest = VerifiedSeller.Shared.Entities.Remote.Request.RegisterRequest;
using ResetPasswordRequest = VerifiedSeller.Shared.Entities.Remote.Request.ResetPasswordRequest;

namespace VerifiedSeller.Server.Services
{
    public class SystemManager:ISystemUser
    {
        private readonly IAuthManager authManager;
        readonly ApiContext _dbContext = new();

        public SystemManager(ApiContext dbContext,IAuthManager _authManager)
        {
            _dbContext = dbContext;
            authManager = _authManager;
        }
        public ResponseInfo ContactUser(ContactRequest contactRequest)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
        public ResponseInfo<LoginResult> LoginUser(LoginRequest loginRequest)
        {
            var responseObjects = new ResponseInfo<Shared.Entities.Remote.Response.LoginResult>();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
        public ResponseInfo RegisterUser(RegisterRequest registerRequest)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
        public ResponseInfo ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
        public ResponseInfo ChangePassword(SystemUserCredentials systemUsers)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
        public ResponseInfo DeRegister(OptOutRequest optOutRequest)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseStatus = true;
            //responseObjects.Data = "";
            return responseObjects;
        }
    }
}
