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
        
        public async Task<bool> CancelReservation(int id)
        {
            var reservation= await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }
            reservation.Status = Domain.Enums.ReservationStatus.Canceled;
            await _reservationRepository.UpdateAsync(reservation);
            return true;
        }
        public async Task<bool> ConfirmReservation(int id)
        {
            var reservation = await _reservationRepository.GetByIdAsync(id);
            if (reservation == null)
            {
                return false;
            }
            reservation.Status = Domain.Enums.ReservationStatus.Confirmed;
            await _reservationRepository.UpdateAsync(reservation);
            return true;
        }

        
    }
}
