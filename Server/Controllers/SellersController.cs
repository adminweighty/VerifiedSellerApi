using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Shared.Entities.Remote.Response;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace VerifiedSeller.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellersController : ControllerBase
    {
        private readonly ISellers _ISellers;
        public SellersController(ISellers iSellers)
        {
            _ISellers = iSellers;
        }
        [HttpGet]
        public async Task<List<SellerResponse>> Get()
        {
            return await Task.FromResult(_ISellers.GetSellers());
        }
       
    }
}
