using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Security.Claims;
using VerifiedSeller.Server.AuthenticationManager;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Server.Models;
using VerifiedSeller.Shared.Entities.Database;
using VerifiedSeller.Shared.Entities.Local;
using VerifiedSeller.Shared.Entities.Remote.Request;
using VerifiedSeller.Shared.Entities.Remote.Response;
using LoginRequest = VerifiedSeller.Shared.Entities.Remote.Request.LoginRequest;
using LoginResult = VerifiedSeller.Shared.Entities.Remote.Response.LoginResult;
using RegisterRequest = VerifiedSeller.Shared.Entities.Remote.Request.RegisterRequest;
using ResetPasswordRequest = VerifiedSeller.Shared.Entities.Remote.Request.ResetPasswordRequest;

namespace VerifiedSeller.Server.Services
{
    public class SystemManager : ISystemUser
    {
        private readonly IAuthManager authManager;
        readonly ApiContext _dbContext = new();

        public SystemManager(ApiContext dbContext, IAuthManager _authManager)
        {
            _dbContext = dbContext;
            authManager = _authManager;
        }
        public ResponseInfo ContactUser(ContactRequest contactRequest)
        {
            var responseObjects = new ResponseInfo();
            responseObjects.ResponseMessage = "Contact message sent!";
            responseObjects.ResponseStatus = true;
            responseObjects.Code = HttpStatusCode.OK.ToString();
            return responseObjects;
        }
        public ResponseInfo<LoginResult> LoginUser(LoginRequest loginRequest)
        {
            var responseObject = new ResponseInfo<LoginResult>();
            var user = _dbContext.MobileRegisteredUsers.Where(a => a.Email.Equals(loginRequest.Email) && a.status==1).FirstOrDefault();

            if (user == null)
            {
                responseObject.Code = HttpStatusCode.Unauthorized.ToString();
                responseObject.ResponseStatus = false;
                responseObject.ResponseMessage = "Incorrect Credentials";
                return responseObject;
            }

            var isAuth = PasswordHash.From(user.PasswordHash, user.PasswordSalt).Verify(loginRequest.Password);

            if (!isAuth)
            {
                responseObject.Code = HttpStatusCode.Unauthorized.ToString();
                responseObject.ResponseMessage = "Incorrect Credentials";
                return responseObject;
            }
            ClaimsIdentity claims = new ClaimsIdentity();

            claims = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier, user.Email),
                new Claim("UserId", user.Id.ToString()),
                new Claim(ClaimTypes.Role, "User"),
                }, "ApplicationCookie");


            var claimsPrincipal = new ClaimsPrincipal(claims);

            var authResult = authManager.GenerateTokens(loginRequest.Email, claimsPrincipal.Claims.ToArray(), DateTime.Now);

            var resultToken = new LoginResult
            {
                UserId = user.Id.ToString(),
                AccessToken = authResult.AccessToken,
                RefreshToken = authResult.RefreshToken,
                UserRole = user.RoleId.ToString(),
                Email = user.Email.ToString(),
            };

            responseObject.ResponseStatus = true;
            responseObject.Data = resultToken;
            responseObject.Code = HttpStatusCode.OK.ToString();
            return responseObject;
        }
        public ResponseInfo RegisterUser(RegisterRequest registerRequest)
        {
           
            var responseObject = new ResponseInfo();
         var userExists = _dbContext.MobileRegisteredUsers.FirstOrDefault(a => a.Email.Equals(registerRequest.Email));

            if (userExists != null)
            {
                responseObject.Code = HttpStatusCode.BadRequest.ToString();
                responseObject.ResponseStatus = false;
                responseObject.ResponseMessage = "ID Number already taken";
                return responseObject;
            }
            MobileRegisteredUsers newUser = new MobileRegisteredUsers();
            var hash = PasswordHash.Generate(registerRequest.Password);
            newUser.PasswordHash = hash.HashBase64;
            newUser.PasswordSalt = hash.SaltBase64;
            newUser.Email = registerRequest.Email;
            newUser.DateCreated = DateTimeOffset.UtcNow;
            newUser.DateModified = DateTimeOffset.UtcNow;
            newUser.Platform = registerRequest.Platform;
            newUser.PhoneNumber = registerRequest.MobileNumber;
            string activationtoken = Guid.NewGuid().ToString();
            newUser.ActiveCode = activationtoken;
            _dbContext.Add(newUser);
            _dbContext.SaveChanges();
            responseObject.ResponseMessage = "Account Created Successfully.";           
            responseObject.ResponseStatus = true;
            responseObject.Code = HttpStatusCode.OK.ToString();
            return responseObject;
        }
        public ResponseInfo ResetPassword(ResetPasswordRequest resetPasswordRequest)
        {
            var responseObjects = new ResponseInfo();

            var systemUsers = _dbContext.MobileRegisteredUsers.Where(a=>a.Email.Equals(resetPasswordRequest)).FirstOrDefault();
            if (systemUsers != null)
            {
                var hash = PasswordHash.Generate(ApiConstants.DEFAULT_PASSWORD);
                systemUsers.PasswordHash = hash.HashBase64;
                systemUsers.PasswordSalt = hash.SaltBase64;
                systemUsers.status = 1;
                systemUsers.DateModified = DateTimeOffset.UtcNow;
                _dbContext.Entry(systemUsers).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                responseObjects.Code = HttpStatusCode.BadRequest.ToString();
                responseObjects.ResponseStatus = false;
                responseObjects.ResponseMessage = "Email does not exsist!";
                return responseObjects;
            }
            responseObjects.ResponseMessage = "Password successfully reset";
            responseObjects.ResponseStatus = true;
              return responseObjects;
        }
        public ResponseInfo ChangePassword(SystemUserCredentials systemUserCredentials)
        {
            var responseObjects = new ResponseInfo();

            var systemUsers = _dbContext.MobileRegisteredUsers.Where(a => a.Email.Equals(systemUserCredentials.UserEmail)).FirstOrDefault();
            if (systemUsers != null)
            {
                var hash = PasswordHash.Generate(systemUserCredentials.Password);
                systemUsers.PasswordHash = hash.HashBase64;
                systemUsers.PasswordSalt = hash.SaltBase64;
                systemUsers.status = 1;
                systemUsers.DateModified = DateTimeOffset.UtcNow;
                _dbContext.Entry(systemUsers).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                responseObjects.Code = HttpStatusCode.BadRequest.ToString();
                responseObjects.ResponseStatus = false;
                responseObjects.ResponseMessage = "Failed to update password !";
                return responseObjects;
            }
            responseObjects.ResponseMessage = "Password successfully updated";
            responseObjects.ResponseStatus = true;
            return responseObjects;
        }
        public ResponseInfo DeRegister(OptOutRequest optOutRequest)
        {
            var responseObjects = new ResponseInfo();

            var systemUsers = _dbContext.MobileRegisteredUsers.Where(a => a.Email.Equals(optOutRequest.Email)).FirstOrDefault();
            if (systemUsers != null)
            {
               systemUsers.status = 5;
                systemUsers.DateModified = DateTimeOffset.UtcNow;
                _dbContext.Entry(systemUsers).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
            else
            {
                responseObjects.Code = HttpStatusCode.BadRequest.ToString();
                responseObjects.ResponseStatus = false;
                responseObjects.ResponseMessage = "Failed to deregister account!";
                return responseObjects;
            }
            responseObjects.ResponseMessage = "Account deregistered";
            responseObjects.ResponseStatus = true;
            responseObjects.Code = HttpStatusCode.OK.ToString();
            return responseObjects;
        }
    }
}
