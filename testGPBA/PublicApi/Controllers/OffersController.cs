using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories.Abstract;
using ApplicationCore.Entities;
using Core.DTO.Request;
using Core.DTO;
using AutoMapper;
using ApplicationCore.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace testGPBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IOfferRepositories _repository;
        private readonly IOffersService _offersService;

        public OffersController(IOfferRepositories repository, IOffersService offersService, IMapper mapper)
        {
            _repository = repository;
            _offersService = offersService;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<OfferDTO>> CreateOffer(AddOfferRequest offerRequest)
        {
            var offer = _mapper.Map<Offer>(offerRequest);

            var createdOffer = await _offersService.CreateOfferAsync(offer);
            return CreatedAtAction(nameof(OfferDTO), new { id = createdOffer.Id }, createdOffer);
        }
        [HttpGet]
        public async Task<ActionResult> GetAllOffers()
        {            
            return Ok(await _offersService.GetAllOfferAsync());
        }
        [HttpGet("search")]
        public async Task<ActionResult> SearchOffers([FromQuery] string query = "")
        {
            return Ok(await _offersService.SearchOffersAsync(query));
        }

        [HttpGet("popular-suppliers")]
        public async Task<ActionResult<IEnumerable<SupplierStats>>> GetPopularSuppliers()
        {            
            return Ok(await _offersService.GetPopularSuppliersAsync());
        }              
    }
}
