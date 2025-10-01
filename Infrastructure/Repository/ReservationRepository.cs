using Domain.Enums;
using Domain.Models.Reservation;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly Context _context;
        public ReservationRepository(Context context)
        {
            _context = context;
        }

        public void AddReservation(Reservation reservation)
        {
            _context.Reservations.Add(reservation);
            _context.SaveChanges();
        }
        public Task<IQueryable<Reservation>> GetAllAsync()
        {
            throw new NotImplementedException();
        }
        public Task<IQueryable<Reservation>> GetByCustomerAsync(int customerId, DateOnly? from, DateOnly? to, ReservationStatus? status = null)
        {
            throw new NotImplementedException();
        }
        public async Task<Reservation?> GetByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(res => res.Id == id && !res.IsDeleted);
            return reservation;
        }
        public IQueryable<Reservation> GetByRoomAsync(int roomId, DateTime? from, DateTime? to, ReservationStatus? status = null)
        {
            var q = _context.Reservations
                           .AsNoTracking()
                           .Where(r => r.RoomId == roomId);

            if (status.HasValue)
                q = q.Where(r => r.Status == status.Value);

            if (from.HasValue && to.HasValue)
            {
                var f = from.Value;
                var t = to.Value;
                q = q.Where(r => r.CheckIn < t && r.CheckOut > f);
            }
            else if (from.HasValue)
            {
                var f = from.Value;
                q = q.Where(r => r.CheckOut > f);
            }
            else if (to.HasValue)
            {
                var t = to.Value;
                q = q.Where(r => r.CheckIn < t);
            }

            return q;
        }
        public Task<Reservation?> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
        public IQueryable<Reservation> GetDetails(int id)
        {
            return _context.Reservations
                           .Where(r => r.Id == id);
        }
        public async Task UpdateStatusAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
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
        public Task<bool> UpdateDatesAsync(int id, DateOnly newCheckIn, DateOnly newCheckOut)
        {
            throw new NotImplementedException();
        }
        public Task<bool> UpdateStatusAsync(int id, ReservationStatus newStatus)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAsync(Reservation reservation)
        {
            var rows = await _context.Reservations
             .Where(r => r.RoomId == reservation.RoomId)
             .ExecuteUpdateAsync(setters => setters
             .SetProperty(r => r.CheckIn, reservation.CheckIn)
             .SetProperty(r => r.CheckOut, reservation.CheckOut)
             .SetProperty(r => r.Status, reservation.Status)
             .SetProperty(r => r.UpdatedDate, DateTime.UtcNow));

            return rows == 1;
        }
        public async Task<bool> UpdateDatesAsync(int id, DateTime newCheckIn, DateTime newCheckOut)
        {
            var rows = await _context.Reservations
             .Where(r => r.RoomId == id)
             .ExecuteUpdateAsync(setters => setters
             .SetProperty(r => r.CheckIn, newCheckIn)
             .SetProperty(r => r.CheckOut, newCheckOut)
             .SetProperty(r => r.UpdatedDate, DateTime.UtcNow));

            return rows == 1;

        }

    }
}
