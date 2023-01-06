using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Interfaces
{
    public interface IProducts
    {
        public List<ProductResponse> GetProducts(int categoryId);
    }
}
