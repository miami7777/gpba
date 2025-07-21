using Microsoft.AspNetCore.Mvc;
using testGPBA.Domain.Repositories.Abstract;
using testGPBA.Domain.Repositories.EntityFramework;
using testGPBA.Models;

namespace testGPBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        
        private readonly IOfferRepositories _repository;

        public OffersController(IOfferRepositories repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<Offer>> CreateOffer(OfferDto offerDto)
        {
            var offer = new Offer
            {
                Brand = offerDto.Brand,
                Model = offerDto.Model,
                SupplierId = offerDto.SupplierId,
                RegistrationDate = DateTime.Now
            };

            var createdOffer = await _repository.CreateOfferAsync(offer);
            return CreatedAtAction(nameof(Offer), new { id = createdOffer.Id }, createdOffer);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOffers()
        {
            (IEnumerable<Offer> offers, int totalCounts) = await _repository.GetAllOffersAsync();
            return Ok(new OfferSearchResult(offers, totalCounts));
        }
        [HttpGet("search")]
        public async Task<ActionResult> SearchOffers([FromQuery] string query = "")
        {            
            (IEnumerable<Offer> offers, int totalCounts)= await _repository.SearchOffersAsync(query);            
            return Ok(new OfferSearchResult(offers,totalCounts));
        }

        [HttpGet("popular-suppliers")]
        public async Task<ActionResult<IEnumerable<SupplierStats>>> GetPopularSuppliers()
        {
            var suppliers = await _repository.GetPopularSuppliersAsync();
            return Ok(suppliers.OrderByDescending(x => x.OfferCount));
        }
        public record OfferDto(string Brand, string Model, int SupplierId);
        public record OfferSearchResult(IEnumerable<Offer> Offers, int TotalCounts);
    }
}
