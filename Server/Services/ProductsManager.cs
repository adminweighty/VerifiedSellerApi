using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Server.Models;
using VerifiedSeller.Shared.Entities.Database;
using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Services
{
    public class ProductsManager : IProducts
    {
        readonly ApiContext _dbContext = new();
        public ProductsManager(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<ProductResponse> GetProducts(int categoryId)
        {
            try
            {

                var productList = (from s in _dbContext.Products
                                   join sell in _dbContext.SellerUsers on s.sellerId equals sell.Id
                                   join cat in _dbContext.Categories
                                   on s.categoryId equals cat.Id
                                   join curr in _dbContext.Currencies
                                   on s.productCurrency equals curr.Id
                                   where s.categoryId == categoryId
                                   select new ProductResponse
                                   {
                                       productId = s.productId,
                                       productName = s.productName,
                                       productCode = s.productCode,
                                       productCurrency = curr.Symbol,
                                       productPrice = s.productPrice,
                                       productRetailPrice = s.productRetailPrice,
                                       productPriceDescription = s.productPriceDescription,
                                       productDiscount = s.productDiscount,
                                       productBrand = s.productBrand,
                                       productLastUpdated = s.productLastUpdated,
                                       productManufacturerDate = s.productManufacturerDate,
                                       productExpiryDate = s.productExpiryDate,
                                       productBarCode = s.productBarCode,
                                       productUnit = s.productUnit,
                                       productWeight = s.productWeight,
                                       productHeight = s.productHeight,
                                       productHeightUnit = s.productHeightUnit,
                                       productQuantity = s.productQuantity,
                                       productColor = s.productColor,
                                       customer = sellPerson(sell),
                                       categoryId = s.categoryId,
                                       featureImageUrl = s.featureImageUrl,
                                       featureImageUrl_1 = s.featureImageUrl_1,
                                       featureImageUrl_2 = s.featureImageUrl_2,
                                       featureImageUrl_3 = s.featureImageUrl_3,
                                       featureImageUrl_4 = s.featureImageUrl_4,
                                       featureImageUrl_5 = s.featureImageUrl_5,
                                   }).ToList();
                return productList;
            }
            catch (Exception e)
            {
                return new List<ProductResponse>();
            }


        }

        private static SellerResponse sellPerson(SellerUsers sellerUsers)
        {
            SellerResponse sellerResponse = new SellerResponse();
            sellerResponse.SellerId = sellerUsers.Id;
            sellerResponse.PhoneNumber = sellerUsers.PhoneNumber;
            sellerResponse.Email = sellerUsers.Email;
            sellerResponse.FirstName = sellerUsers.FirstName;
            sellerResponse.LastName = sellerUsers.LastName;
            sellerResponse.CompanyName = sellerUsers.CompanyName;
            sellerResponse.Street = sellerUsers.Street;
            sellerResponse.City = sellerUsers.City;
            sellerResponse.Country = sellerUsers.Country;
            sellerResponse.ZipCode = sellerUsers.ZipCode;
            sellerResponse.SpecialityArea = sellerUsers.SpecialityArea;

            return sellerResponse;
        }
    }


}
