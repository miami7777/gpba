
namespace ApplicationCore.Entities
{
    public class Supplier
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Offer> Offers { get; set; }
    }
    public record SupplierStats(string SupplierName, int OfferCount);
}
