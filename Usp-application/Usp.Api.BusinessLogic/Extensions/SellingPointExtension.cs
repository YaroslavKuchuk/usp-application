using Usp.Api.Data.Models;
using Usp.Models;

namespace Usp.Api.BusinessLogic.Extensions
{
    public static class SellingPointExtension
    {
        public static SellingPointViewModel ToModel(this SellingPoint sellingPoint)
        {
            if (sellingPoint is null)
                return null;

            var model = new SellingPointViewModel();

            model.Id = sellingPoint.Id;
            model.Name = sellingPoint.Name;
            model.Description = sellingPoint.Description;
            model.Header = sellingPoint.Header;
            model.Price
                = sellingPoint.SellingPointPrices.SingleOrDefault(s => !s.EndDate.HasValue)?.Price ?? 0;

            List<string> properties
                = sellingPoint.SellingPointProperties?
                    .Select(s => s.Name)
                    .ToList();

            model.Properties = properties;

            return model;
        }
    }
}
