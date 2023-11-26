
using Usp.Models;

namespace Usp.Api.BusinessLogic.Services.Abstractions
{
    public interface ISellingPointService
    {
        public SellingPointViewModel Get(Guid id);

        public IList<SellingPointViewModel> GetList();
    }
}
