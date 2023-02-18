using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Shared.Entities.Database;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VerifiedSeller.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategories _ICategories;
        public CategoriesController(ICategories iCategories)
        {
            _ICategories= iCategories;
        }
        [HttpGet]
        public async Task<List<Categories>> Get()
        {
            return await Task.FromResult(_ICategories.GetCategories());
        }
       
    }
}
