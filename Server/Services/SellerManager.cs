using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Server.Models;
using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Services
{
    public class SellerManager : ISellers
    {
        readonly ApiContext _dbContext = new();
        public SellerManager(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<SellerResponse> GetSellers()
        {

            try
            {
                var sellerList = (from s in _dbContext.SellerUsers
                                  select new SellerResponse
                                  {
                                      SellerId = s.Id,
                                      PhoneNumber = s.PhoneNumber,
                                      Email = s.Email,
                                      FirstName = s.FirstName,
                                      LastName = s.LastName,
                                      CompanyName = s.CompanyName,
                                      Street = s.Street,
                                      City = s.City,
                                      Country = s.Country,
                                      ZipCode = s.ZipCode,
                                      SpecialityArea = s.SpecialityArea,

                                  }).ToList();
                if (sellerList.Count > 0)
                {
                    return sellerList;
                }
                else
                {

                    return new List<SellerResponse>();

                }
            }
            catch (Exception)
            {

                return new List<SellerResponse>();
            }

         
        }

    }
}
