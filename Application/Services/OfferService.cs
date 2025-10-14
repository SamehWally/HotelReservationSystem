using Application.DTOs.Offer;
using AutoMapper;
using Domain.Models.Offer;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class OfferService{
    private readonly IOfferRepository _offerRepository;
    private readonly IRoomRepository _roomRepository;
    private readonly IMapper _mapper;

    public OfferService(IOfferRepository offerRepository, IRoomRepository roomRepository, IMapper mapper)
    {
        _offerRepository = offerRepository;
        _roomRepository = roomRepository;
        _mapper = mapper;
    }

        public string AddOffer(AddOfferDto addOfferDto)
        {
            if (addOfferDto == null)
            {
                return "Invalid request";
            }

            if (addOfferDto.DisCountPercent <= 0 || addOfferDto.DisCountPercent > 100)
            {
                return "Discount percent must be between 1 and 100";
            }

            if (addOfferDto.EndDate <= addOfferDto.StartDate)
            {
                return "End date must be after start date";
            }


            if (addOfferDto.RoomIds == null || !addOfferDto.RoomIds.Any())
            {
                return "At least one room must be selected";
            }
            if (addOfferDto.EndDate < DateTime.UtcNow)
            {
                return "cannot create an expired offer";
            }

            var validRoomIds = new List<int>();
            foreach (var roomId in addOfferDto.RoomIds)
            {
                var room = _roomRepository.GetRoomById(roomId);
                if (room != null && !room.IsDeleted)
                {
                    validRoomIds.Add(roomId);
                }
            }

            if (!validRoomIds.Any())
            {
                return "No valid rooms found";
            }

            //var offer = new Offer
            //{
            //    Id = addOfferDto.Id,
            //    Title = addOfferDto.Title,
            //    Description = addOfferDto.Description,
            //    DisCountPercent = addOfferDto.DisCountPercent,
            //    StartDate = addOfferDto.StartDate,
            //    EndDate = addOfferDto.EndDate,
            //    OfferRooms = new List<OfferRoom>()
            //};
            var offer = _mapper.Map<Offer>(addOfferDto);
            foreach (var roomid in validRoomIds)
            {
                offer.OfferRooms.Add(new OfferRoom
                {
                    OfferId = offer.Id,
                    RoomId = roomid
                });
            }

            _offerRepository.AddOffer(offer);

            return "Offer created successfully";
        }

        public GetOfferById? GetOfferById(int id)
        {
            _offerRepository.UpdateStatus(id);
            var offer = _offerRepository.GetById(id);

            if (offer == null || offer.IsDeleted)
                return null;

            //return new GetOfferById
            //{    Id = offer.Id,
            //    Title = offer.Title,
            //    Description = offer.Description,
            //    DiscountPercent = offer.DisCountPercent,
            //    StartDate = offer.StartDate,
            //    EndDate = offer.EndDate,
            //    IsActive = offer.EndDate >= DateTime.UtcNow,
            //    RoomIds = offer.OfferRooms?.Select(or => or.RoomId).ToList() ?? new List<int>()
            //};
            return _mapper.Map<GetOfferById>(offer);


        }
        public string UpdateOffer(UpdateOfferDto dto)
        {
            if (dto == null)
                return "Invalid request";

            var existingOffer = _offerRepository.GetById(dto.Id);
            if (existingOffer == null)
                return "Offer not found";


            if (dto.DisCountPercent <= 0 || dto.DisCountPercent > 100)
                return "Discount percent must be between 1 and 100";


            if (dto.EndDate <= dto.StartDate)
                return "End date must be after start date";


            if (dto.EndDate < DateTime.UtcNow)
                return "Cannot update an expired offer";

            if (dto.RoomIds == null || !dto.RoomIds.Any())
                return "At least one room must be selected";

            var validRoomIds = new List<int>();
            foreach (var roomId in dto.RoomIds)
            {
                var room = _roomRepository.GetRoomById(roomId);
                if (room != null && !room.IsDeleted)
                    validRoomIds.Add(roomId);
            }

            if (!validRoomIds.Any())
                return "No valid rooms found";
            //existingOffer.Title = dto.Title;
            //existingOffer.Description = dto.Description;
            //existingOffer.DisCountPercent = dto.DisCountPercent;
            //existingOffer.StartDate = dto.StartDate;
            //existingOffer.EndDate = dto.EndDate;
            //existingOffer.IsActive = dto.EndDate >= DateTime.UtcNow;
            _mapper.Map(dto, existingOffer);

            existingOffer.OfferRooms.Clear();
            foreach (var roomId in validRoomIds)
            {
                existingOffer.OfferRooms.Add(new OfferRoom
                {
                    OfferId = existingOffer.Id,
                    RoomId = roomId
                });
            }

            _offerRepository.UpdateOffer(existingOffer);

            return "Offer updated successfully";
        }
        public bool SoftDeleteOffer(int id)
        {

            var offer = _offerRepository.GetById(id);
            if (offer == null)
            {
                return false;
            }
            _offerRepository.DeleteOffer(id);
            return true;
        }

        public async Task<GetOfferByIdDto?> GetOfferByIdAsync(int id)
        {
            _offerRepository.UpdateStatus(id);
            var offer = await _offerRepository.GetOfferById(id);
            if (offer == null)
                return null;
            var dto = _mapper.Map<GetOfferByIdDto>(offer);
            return dto;
        }
        public async Task<List<GetAllOfferDto>> GetAllOffersAsync()
        {

            var offers = await _offerRepository.GetAllOfferWithRoom();
            return _mapper.Map<List<GetAllOfferDto>>(offers);
        }
    }
}
