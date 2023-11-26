
using Usp.Api.Data.Models;

namespace Usp.Api.Data.Repositories.Abstractions
{
    public interface ISellingPointRepository
    {
        IEnumerable<SellingPoint> GetAll();
        SellingPoint Get(Guid id);
    }
}
