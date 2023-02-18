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
            var user = (from v in  _dbContext.MobileRegisteredUsers
                       join b in _dbContext.Buyers 
                       on v.BuyerId equals b.Id  
                       where (v.Email.Equals(loginRequest.Email) && v.status == 1)
                       select new { user=v , 
                           buyer=b }).ToList();

            if (user.Count==0)
            {
                responseObject.Code = HttpStatusCode.Unauthorized.ToString();
                responseObject.ResponseStatus = false;
                responseObject.ResponseMessage = "Incorrect Credentials";
                return responseObject;
            }
            var myUser=user.FirstOrDefault();

            var isAuth = PasswordHash.From(myUser.user.PasswordHash, myUser.user.PasswordSalt).Verify(loginRequest.Password);

            if (!isAuth)
            {
                responseObject.Code = HttpStatusCode.Unauthorized.ToString();
                responseObject.ResponseMessage = "Incorrect Credentials";
                return responseObject;
            }
            ClaimsIdentity claims = new ClaimsIdentity();

            claims = new ClaimsIdentity(new[] {
                new Claim(ClaimTypes.Name, myUser.user.Email),
                new Claim(ClaimTypes.NameIdentifier, myUser.user.Email),
                new Claim("UserId", myUser.user.Id.ToString()),
                new Claim(ClaimTypes.Role, "User"),
                }, "ApplicationCookie");


            var claimsPrincipal = new ClaimsPrincipal(claims);

    
            var finalAuth = authManager.GenerateTokens(loginRequest.Email, claimsPrincipal.Claims.ToArray(), DateTime.Now);

            var resultToken = new LoginResult
            {
                UserId = myUser.user.Id.ToString(),
                AccessToken = finalAuth.AccessToken,
                RefreshToken = finalAuth.RefreshToken,
                UserRole = myUser.user.RoleId.ToString(),
                Email = myUser.user.Email.ToString(),
                Buyer=myUser.buyer.BuyerType.ToString(),
                Mobile = myUser.user.PhoneNumber.ToString(),
             };

            responseObject.ResponseStatus = true;
            responseObject.Data = resultToken;
            responseObject.Code = HttpStatusCode.OK.ToString();
            return responseObject;
        }
        public ResponseInfo RegisterUser(RegisterRequest registerRequest)
        {
           
            var responseObject = new ResponseInfo();

         var userExists = _dbContext.MobileRegisteredUsers.Where(a => a.Email.Equals(registerRequest.Email)).ToList();

            var phoneExists = _dbContext.MobileRegisteredUsers.Where(a => a.PhoneNumber.Equals(registerRequest.MobileNumber)).ToList();


            Buyers? getBuyerDetails = _dbContext.Buyers.Where(a => a.BuyerType.Equals(registerRequest.Buyer)).FirstOrDefault();

            if (userExists.Count != 0)
            {
                responseObject.Code = HttpStatusCode.BadRequest.ToString();
                responseObject.ResponseStatus = false;
                responseObject.ResponseMessage = "Email already taken";
                return responseObject;
            }
            if (phoneExists.Count != 0)
            {
                responseObject.Code = HttpStatusCode.BadRequest.ToString();
                responseObject.ResponseStatus = false;
                responseObject.ResponseMessage = "Phone already taken";
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
            newUser.BuyerId = getBuyerDetails.Id;
            newUser.status = 1;
            newUser.RoleId = 2;
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

            var systemUsers = _dbContext.MobileRegisteredUsers.Where(a=>a.Email.Equals(resetPasswordRequest.Email)).FirstOrDefault();
            if (systemUsers != null)
            {
                var hash = PasswordHash.Generate(ApiConstants.DEFAULT_PASSWORD);
                systemUsers.PasswordHash = hash.HashBase64;
                systemUsers.PasswordSalt = hash.SaltBase64;
                systemUsers.status = 1;
                systemUsers.DateModified = DateTimeOffset.UtcNow;
                _dbContext.Entry(systemUsers).State = EntityState.Modified;
                _dbContext.SaveChanges();
                responseObjects.Code = HttpStatusCode.OK.ToString();
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
                responseObjects.Code = HttpStatusCode.OK.ToString();
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
                responseObjects.Code = HttpStatusCode.OK.ToString();
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
            return responseObjects;
        }
    }
}
