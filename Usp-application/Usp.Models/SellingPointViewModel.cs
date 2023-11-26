
namespace Usp.Models
{
    public class SellingPointViewModel
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public IList<string> Properties { get; set; }
    }
}
