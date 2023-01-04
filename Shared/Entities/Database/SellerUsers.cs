namespace VerifiedSeller.Shared.Entities.Database
{
    public class SellerUsers
    {
        public int Id { get; set; }
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string SpecialityArea { get; set; }
        public int status { get; set; }
    }
}
