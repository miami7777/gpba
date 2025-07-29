using Microsoft.AspNetCore.Mvc;
using Infrastructure.Repositories.Abstract;
using ApplicationCore.Entities;
using Core.DTO.Request;
using Core.DTO;
using AutoMapper;
using ApplicationCore.Interfaces;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using Microsoft.Extensions.Logging;

namespace testGPBA.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OffersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ILogger _logger;
        private readonly IOfferRepositories _repository;
        private readonly IOffersService _offersService;

        public OffersController(IOfferRepositories repository, IOffersService offersService, IMapper mapper, ILogger<OffersController> logger)
        {
            _repository = repository;
            _offersService = offersService;
            _mapper = mapper;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult<OfferDTO>> CreateOffer(AddOfferRequest offerRequest)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var offer = _mapper.Map<Offer>(offerRequest);
            try
            {
                var createdOffer = await _offersService.CreateOfferAsync(offer);
                return CreatedAtAction(nameof(OfferDTO), new { id = createdOffer.Id }, createdOffer);
            }
            catch (Exception ex)
            {
                _logger.LogError("Ошибка: {0} \n Подробности: {1}", ex.Message, ex.InnerException);
                return BadRequest($"Ошибка: {ex.Message}");
            }
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
