
using VerifiedSeller.Shared.Entities.Database;
using VerifiedSeller.Shared.Entities.Remote.Response;

namespace VerifiedSeller.Server.Interfaces
{
    public interface ISellers
    {
        public List<SellerResponse> GetSellers();
    }
}
