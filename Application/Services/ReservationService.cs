using Application.DTOs.Reservation;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Enums;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
    }
}
