using Application.DTOs.Reservation;
using AutoMapper;
using Domain.Models.Reservation;
using Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            //var Resrvation = new Reservation
            //{
            //    CheckIn = addReservationDto.CheckIn,
            //    CheckOut = addReservationDto.CheckOut,
            //    RoomId = addReservationDto.RoomId,
            //    CustomerId = addReservationDto.CustomerId,
            //    Number = addReservationDto.Number,
            //    Status = addReservationDto.Status,
            //};
            var Resrvation = _mapper.Map<Reservation>(addReservationDto);
            _reservationRepository.AddReservation(Resrvation);
            //return new ReservationResponse
            //{
            //    CheckIn = Resrvation.CheckIn,
            //    CheckOut = Resrvation.CheckOut,
            //    RoomId = Resrvation.RoomId,
            //    Message = "Reservation created successfully"
            //};
            var ReservationResponse = _mapper.Map<ReservationResponse>(Resrvation);
            ReservationResponse.Message = "Reservation created successfully";

            return ReservationResponse;
        }
    }
}
