using Application.DTOs.Offer;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Mapping
{
    public class OfferProfileDto:Profile
    {
        public OfferProfileDto()
        {
            CreateMap<UpdateOfferDto, Domain.Models.Offer.Offer>()
            .ForMember(dest => dest.DisCountPercent, opt => opt.MapFrom(src => src.DisCountPercent))
            .ForMember(dest => dest.OfferRooms, opt => opt.Ignore()); // هنديرها يدوي


            //----------------------------------------
            CreateMap<AddOfferDto, Domain.Models.Offer.Offer>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.OfferRooms, opt => opt.Ignore())
                   .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.EndDate >= DateTime.UtcNow));


            // GetById Offer → GetOfferByIdDto
            CreateMap<Domain.Models.Offer.Offer, GetOfferById>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DisCountPercent))
                .ForMember(dest => dest.RoomIds, opt => opt.MapFrom(src => src.OfferRooms.Select(or => or.RoomId).ToList()));
            // .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.EndDate >= DateTime.UtcNow));

            CreateMap<Domain.Models.Offer.Offer, GetOfferByIdDto>()
                .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DisCountPercent))
                .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.EndDate >= DateTime.UtcNow))
                .ForMember(dest => dest.roomInOfferDtos, opt => opt.MapFrom(src => src.OfferRooms.Select(or => or.Room).ToList().Distinct()));

            CreateMap<Domain.Models.Room.Room, RoomInOfferDto>()
                .ForMember(d => d.PricePerNight, opt => opt.MapFrom(src => src.PricePerNight));
            //--------------------------------------------------------------
            CreateMap<Domain.Models.Offer.Offer, GetAllOfferDto>()
            .ForMember(dest => dest.DiscountPercent, opt => opt.MapFrom(src => src.DisCountPercent))
            .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.EndDate >= DateTime.UtcNow))
            .ForMember(dest => dest.RoomInOfferDtos,
                opt => opt.MapFrom(src => src.OfferRooms
                    .Select(or => or.Room)
                    .DistinctBy(r => r.Id)
                ));

            CreateMap<Domain.Models.Room.Room, AllRoomInOfferDto>();


        }
    }
}

