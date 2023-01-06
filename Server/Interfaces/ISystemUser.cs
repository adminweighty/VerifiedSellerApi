using VerifiedSeller.Shared.Entities.Remote.Request;
using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Interfaces
{
    public interface ISystemUser
    { 
        public ResponseInfo ContactUser(ContactRequest contactRequest);
        public ResponseInfo<LoginResult> LoginUser(LoginRequest loginRequest);
        public ResponseInfo RegisterUser(RegisterRequest registerRequest);
        public ResponseInfo ResetPassword(ResetPasswordRequest resetPasswordRequest);
        public ResponseInfo ChangePassword(SystemUserCredentials systemUsers);
        public ResponseInfo DeRegister(OptOutRequest optOutRequest);
    }
}
