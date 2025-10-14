using Application.DTOs.Offer;
using AutoMapper;
using Presentation.ViewModels.Offer;

namespace Presentation.ViewModels.Mapping
{
    public class OfferProfileViewModel:Profile
    {
        public OfferProfileViewModel()
        {
            CreateMap<GetOfferById, GetOfferViewModel>().ReverseMap();
            CreateMap<UpdateOfferVM, UpdateOfferDto>().ReverseMap();
            CreateMap<AddOfferDto, AddOfferVM>().ReverseMap();

            // CreateMap<GetOfferByIdDto, GetOfferByIdVM>().ReverseMap();

            CreateMap<GetOfferByIdDto, GetOfferByIdVM>().ReverseMap(); ;
            //.ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DiscountPercent))
            //.ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.EndDate >= DateTime.UtcNow))
            //.ForMember(dest => dest.roomInOfferDtos, opt => opt.MapFrom(src => src.roomInOfferDtos.Select(or => or.r));

            CreateMap<RoomInOfferDto, RoomInOfferVm>().ReverseMap(); ;
            //.ForMember(d => d.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight));

            CreateMap<GetAllOfferDto, GetAllOfferVM>().ReverseMap();


            CreateMap<AllRoomInOfferDto, AllRoomInOfferVM>().ReverseMap();

        }
    }
}
