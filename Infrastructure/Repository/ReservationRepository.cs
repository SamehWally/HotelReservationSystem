using Domain.Enums;
using Domain.Models.Reservation;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    internal class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;
        public ReservationRepository(Context context)
        {
            _context = context;
        }

        public Task<bool> AddAsync(Reservation reservation)
        {
            throw new NotImplementedException();
        }
        public Task<IQueryable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IQueryable<Reservation>> GetByCustomerAsync(int customerId, DateOnly? from, DateOnly? to, ReservationStatus? status = null)
        {
            throw new NotImplementedException();
        }
       
        public Task<IQueryable<Reservation>> GetByRoomAsync(int roomId, DateOnly? from, DateOnly? to, ReservationStatus? status = null)
        {
            throw new NotImplementedException();
        }
        public Reservation? GetById(int id)
        {
            return _context.Reservations.FirstOrDefault(r => r.Id == id);
        }

        public IQueryable<Reservation> GetDetails(int id)
        {
            // هنا ممكن تستخدم Include لو عايز تجيب بيانات إضافية (مثلاً Room, Customer ...)
            return _context.Reservations
                           .Where(r => r.Id == id);
        }

        public Task<bool> IsRoomAvailableAsync(int roomId, DateOnly checkIn, DateOnly checkOut)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Reservation> Search(
        int? roomId = null,
        int? customerId = null,
        DateOnly? from = null,
        DateOnly? to = null,
        ReservationStatus? status = null)
        {
            var query = _context.Reservations.AsQueryable();

            if (roomId.HasValue)
                query = query.Where(r => r.RoomId == roomId.Value);

            if (customerId.HasValue)
                query = query.Where(r => r.CustomerId == customerId.Value);

            if (from.HasValue)
                query = query.Where(r => r.CheckIn >= from.Value.ToDateTime(TimeOnly.MinValue));

            if (to.HasValue)
                query = query.Where(r => r.CheckOut <= to.Value.ToDateTime(TimeOnly.MaxValue));

            if (status.HasValue)
                query = query.Where(r => r.Status == status.Value);

            return query;
        }
            public Task<bool> SoftDeleteAsync(int id)
            {
                throw new NotImplementedException();
            }
            public Task<bool> UpdateAsync(Reservation reservation)
            {
                throw new NotImplementedException();
            }
            public Task<bool> UpdateDatesAsync(int id, DateOnly newCheckIn, DateOnly newCheckOut)
            {
                throw new NotImplementedException();
            }
            public Task<bool> UpdateStatusAsync(int id, ReservationStatus newStatus)
            {
                throw new NotImplementedException();
            }
        }
    }
