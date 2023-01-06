﻿namespace VerifiedSeller.Shared.Entities.Remote.Response
{
    public class SellerResponse
    {
        public int SellerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyName { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public string ZipCode { get; set; }
        public string SpecialityArea { get; set; }
    }
}
