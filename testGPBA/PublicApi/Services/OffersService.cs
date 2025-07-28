using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using Core.DTO;
using Core.DTO.Request;
using Infrastructure.Repositories.Abstract;
using static testGPBA.Controllers.OffersController;

namespace PublicApi.Services
{
    public class OffersService : IOffersService
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepositories _repository;

        public OffersService(IOfferRepositories repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<OfferDTO> CreateOfferAsync(Offer offer)
        {
            var createdOffer = await _repository.CreateOfferAsync(offer);
            return _mapper.Map<OfferDTO>(createdOffer);
        }

        public async Task<OfferSearchResult> GetAllOfferAsync()
        {
            (IEnumerable<Offer> offers, int totalCounts) = await _repository.GetAllOffersAsync();
            var offersDTO = _mapper.Map<List<OfferDTO>>(offers);
            return new OfferSearchResult(offersDTO, totalCounts);
        }

        public async Task<IEnumerable<SupplierStats>> GetPopularSuppliersAsync()
        {
            var suppliers = await _repository.GetPopularSuppliersAsync(); 
            return suppliers.OrderByDescending(x => x.OfferCount);
        }

        public async Task<OfferSearchResult> SearchOffersAsync(string query)
        {
            (IEnumerable<Offer> offers, int totalCounts) = await _repository.SearchOffersAsync(query);
            var offersDTO = _mapper.Map<List<OfferDTO>>(offers);
            return new OfferSearchResult(offersDTO, totalCounts);
        }
    }
}
