using Usp.Api.BusinessLogic.Extensions;
using Usp.Api.BusinessLogic.Services.Abstractions;
using Usp.Api.Data.Repositories.Abstractions;
using Usp.Models;

namespace Usp.Api.BusinessLogic.Services
{
    public class SellingPointService : ISellingPointService
    {
        public readonly ISellingPointRepository _repository;

        public SellingPointService(ISellingPointRepository repository)
        {
            _repository = repository;
        }

        public SellingPointViewModel Get(Guid id)
        {
            var sellingPoint = _repository.Get(id);

            return sellingPoint.ToModel();
        }

        public IList<SellingPointViewModel> GetList()
        {
            var sellingPoints = _repository.GetAll();

            return sellingPoints.Select(x => x.ToModel()).ToList();
        }
    }
}
