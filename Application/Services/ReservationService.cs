using Application.DTOs.Reservation;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Application.DTOs;
using Domain.Models.Reservation;
using Domain.Repositories;

namespace Application.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IMapper _mapper;

        public ReservationService(IReservationRepository reservationRepository,IRoomRepository roomRepository ,IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _roomRepository = roomRepository;
            _mapper = mapper;
        }

        // 🔹 Search
        public async Task<IEnumerable<SearchReservationDto>> SearchAsync(int? roomId = null, int? customerId = null,
            DateOnly? from = null, DateOnly? to = null, ReservationStatus? status = null)
        {
            var query = _reservationRepository.Search(roomId, customerId, from, to, status);
            return await query.ProjectTo<SearchReservationDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        // 🔹 GetById
        public async Task<ReservationDto?> GetByIdAsync(int id)
        {
            var query = _reservationRepository.Search(); // IQueryable
            var reservation = await query.FirstOrDefaultAsync(r => r.Id == id);

            return reservation == null ? null : _mapper.Map<ReservationDto>(reservation);
        }

        // 🔹 GetDetails
        public async Task<ReservationDto?> GetDetailsAsync(int id)
        {
            var query = _reservationRepository.GetDetails(id);
            var reservation = await query.FirstOrDefaultAsync();

            return reservation == null ? null : _mapper.Map<ReservationDto>(reservation);
        }
      
        public ReservationResponse addReservation(AddReservationDto addReservationDto) {

            var room=_roomRepository.GetRoomById(addReservationDto.RoomId);
            if (room==null || room.IsDeleted)
            {
                return new ReservationResponse { Message = "room not found" };
            }
            if (addReservationDto.CheckIn.Date<DateTime.UtcNow.Date)
            {
                return new ReservationResponse { Message = "Check-in data cannot be in the past" };
            }
            if (addReservationDto.CheckOut<=addReservationDto.CheckIn)
            {
                return new ReservationResponse { Message = "Check-in data must be after check-in" };
            }
            bool isAvailable =  _roomRepository.IsRoomAvailable(addReservationDto.RoomId, addReservationDto.CheckIn, addReservationDto.CheckOut);
            if (!isAvailable)
                return new ReservationResponse { Message = "Room is not available for the selected dates." };
        
            var Resrvation = _mapper.Map<Reservation>(addReservationDto);
            _reservationRepository.AddReservation(Resrvation);
            var ReservationResponse = _mapper.Map<ReservationResponse>(Resrvation);
            ReservationResponse.Message = "Reservation created successfully";

            return ReservationResponse;
        }
        
        public async Task<bool> CancelReservation(CancelReservationDto cancelReservationDto)
        {
            var reservation= await _reservationRepository.GetByIdAsync(cancelReservationDto.ReservationId);
            if (reservation == null || reservation.CustomerId != cancelReservationDto.CustomerId)
            {
                return false;
            }
           
            //                                Source       Destination
            var mappedReservation =_mapper.Map(cancelReservationDto, reservation);
            await _reservationRepository.UpdateStatusAsync(mappedReservation);
            return true;
        }
      
        public async Task<bool> ConfirmReservation(ConfirmReservationDto confirmReservationDto)
        {
            var reservation = await _reservationRepository.GetByIdAsync(confirmReservationDto.ReservationId);
            if (reservation == null)
            {
                return false;
            }
            //                                   Source                  Destination
            var mappedReservation = _mapper.Map(confirmReservationDto, reservation);
            await _reservationRepository.UpdateStatusAsync(mappedReservation);
            return true;
        }

        
        public async Task<bool> UpdateAsync(UpdateReservationDto dto)
        {
            if (dto is null || dto.Id <= 0) return false;
            if (dto.CheckIn >= dto.CheckOut) return false;

            var reservatio = _mapper.Map<Reservation>(dto);
            var isUpdated = await _reservationRepository.UpdateAsync(reservatio);
            return isUpdated;
        }

        public async Task<bool> UpdateDateAsync(UpdateReservationDateDto dto)
        {
            if (dto is null || dto.Id <= 0) return false;
            if (dto.CheckIn >= dto.CheckOut) return false;

            var reservatio = _mapper.Map<Reservation>(dto);
            var isUpdated = await _reservationRepository.UpdateAsync(reservatio);
            return isUpdated;
        }
      
        public async Task<IEnumerable<GetReservationByRoomIdDto>> GetByRoomAsync(GetReservationByRoomIdDto dto)
        {
            if (dto is null) throw new ArgumentNullException(nameof(dto));
            if (dto.Id <= 0) throw new ArgumentException("RoomId (Id) must be > 0.", nameof(dto.Id));
            if (dto.CheckIn.HasValue && dto.CheckOut.HasValue && dto.CheckIn >= dto.CheckOut)
                throw new ArgumentException("CheckIn must be before CheckOut.");

            var q = _reservationRepository.GetByRoomAsync(dto.Id, dto?.CheckIn, dto?.CheckOut, dto?.Status);
            var enumerable = await q
                .ProjectTo<GetReservationByRoomIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return enumerable;
        }
    }
}
