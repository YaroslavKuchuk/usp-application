using Usp.Api.Data.Models;
using Usp.Api.Data.Repositories.Abstractions;

namespace Usp.Api.Data.Repositories
{
    public class SellingPointRepository : ISellingPointRepository
    {
        private readonly UspContext _uspContext;
        public SellingPointRepository()
        {
        }

        public SellingPoint Get(Guid id)
        {
            return _uspContext.Set<SellingPoint>().FirstOrDefault(e => e.Id == id);
        }

        public IEnumerable<SellingPoint> GetAll()
        {
            return _uspContext.Set<SellingPoint>();
        }
    }
}