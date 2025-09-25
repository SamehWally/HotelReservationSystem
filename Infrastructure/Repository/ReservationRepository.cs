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
        public Task<Reservation?> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<IQueryable<Reservation>> GetByRoomAsync(int roomId, DateOnly? from, DateOnly? to, ReservationStatus? status = null)
        {
            throw new NotImplementedException();
        }
        public Task<Reservation?> GetDetailsAsync(int id)
        {
            throw new NotImplementedException();
        }
        public Task<bool> IsRoomAvailableAsync(int roomId, DateOnly checkIn, DateOnly checkOut)
        {
            throw new NotImplementedException();
        }
        public Task<IQueryable<Reservation>> SearchAsync(int? roomId = null, int? customerId = null, DateOnly? from = null, DateOnly? to = null, ReservationStatus? status = null)
        {
            throw new NotImplementedException();
        }
        public Task<bool> SoftDeleteAsync(int id)
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
