namespace VerifiedSeller.Shared.Entities.Database
{
    public class SystemUsers
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string ActiveCode { get; set; }
        public int RoleId { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public DateTimeOffset DateModified { get; set; }
        public bool IsLocked { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int LockCount { get; set; }
        public int Status { get; set; }
    }
}
