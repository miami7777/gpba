using testGPBA.Models;

namespace testGPBA.Domain.Repositories.Abstract
{
    public interface IOfferRepositories
    {        
        Task<Offer> CreateOfferAsync(Offer offer);
        Task<(IEnumerable<Offer>, int)> GetAllOffersAsync();
        Task<(IEnumerable<Offer>,int)> SearchOffersAsync(string searchTerm);
        Task<IEnumerable<SupplierStats>> GetPopularSuppliersAsync(int count = 3);              
    }
    public record SupplierStats(string SupplierName, int OfferCount);
}
