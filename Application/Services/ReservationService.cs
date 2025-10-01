using Application.DTOs.Room.DTO;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
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
