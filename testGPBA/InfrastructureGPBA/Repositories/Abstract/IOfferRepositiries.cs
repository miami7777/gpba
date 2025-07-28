using ApplicationCore.Entities;

namespace Infrastructure.Repositories.Abstract
{
    public interface IOfferRepositories
    {
        Task<Offer> CreateOfferAsync(Offer offer);
        Task<(IEnumerable<Offer>, int)> GetAllOffersAsync();
        Task<(IEnumerable<Offer>, int)> SearchOffersAsync(string searchTerm);
        Task<IEnumerable<SupplierStats>> GetPopularSuppliersAsync(int count = 3);
    }    
}
