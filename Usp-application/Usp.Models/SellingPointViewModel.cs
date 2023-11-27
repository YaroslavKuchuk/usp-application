
namespace Usp.Models
{
    public class SellingPointViewModel
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Header { get; set; }

        public decimal Price { get; set; }

        public bool? IsPrimary { get; set; }

        public IList<string> Properties { get; set; }
    }
}
