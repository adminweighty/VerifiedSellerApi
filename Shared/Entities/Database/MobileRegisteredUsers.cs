namespace VerifiedSeller.Shared.Entities.Database
{
    public class MobileRegisteredUsers
    {
        public int Id { get; set; }
        public int BuyerId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ActiveCode { get; set; }
        public int RoleId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public bool IsLocked { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public int LockCount { get; set; }
        public string Platform { get; set; }
        public int status { get; set; }

    }
}
