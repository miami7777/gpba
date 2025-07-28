using ApplicationCore.Entities;
using AutoMapper;
using Core.DTO;
using Core.DTO.Request;
namespace PublicApi
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddOfferRequest,Offer>();
            CreateMap<Offer,OfferDTO>();
        }
    }
}
