using Microsoft.AspNetCore.Mvc;
using VerifiedSeller.Server.Interfaces;
using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProducts _IProducts;
        public ProductsController(IProducts iProducts)
        {
            _IProducts = iProducts;
        }
        [HttpGet]
        public async Task<List<ProductResponse>> Get(int categoryId)
        {
            return await Task.FromResult(_IProducts.GetProducts(categoryId));
        }
    }
}
