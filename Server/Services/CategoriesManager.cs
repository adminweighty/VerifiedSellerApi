using Microsoft.EntityFrameworkCore;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Server.Models;
using VerifiedSeller.Shared.Entities.Database;

namespace VerifiedSeller.Server.Services
{
    public class CategoriesManager : ICategories
    {
        readonly ApiContext _dbContext = new();
        public CategoriesManager(ApiContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Categories> GetCategories()
        {
            try
            {
                return _dbContext.Categories.ToList();
            }
            catch
            {
               return new List<Categories>();
            }
        }
       
    }
}
