using Application.DTOs;
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
    }
}
