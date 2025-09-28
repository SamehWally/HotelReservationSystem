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
        private readonly IMapper _mapper;
        public ReservationService(IReservationRepository reservationRepository, IMapper mapper)
        {
            _reservationRepository = reservationRepository;
            _mapper = mapper;
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

        
    }
}
