using ApplicationCore.Entities;
using Core.DTO;
using Core.DTO.Request;

namespace ApplicationCore.Interfaces
{
    public interface IOffersService
    {
        Task<OfferDTO> CreateOfferAsync(Offer addOffer);
        Task<OfferSearchResult> GetAllOfferAsync();
        Task<OfferSearchResult> SearchOffersAsync(string query);
        Task<IEnumerable<SupplierStats>> GetPopularSuppliersAsync();
    }
}
