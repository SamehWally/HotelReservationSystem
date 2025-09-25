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
        public async Task<Reservation?> GetByIdAsync(int id)
        {
            var reservation = await _context.Reservations.FirstOrDefaultAsync(res=>res.Id==id&&!res.IsDeleted);
            return reservation;
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
        public async Task UpdateAsync(Reservation reservation)
        {
            _context.Reservations.Update(reservation);
            await _context.SaveChangesAsync();
        }
        public Task<bool> UpdateDatesAsync(int id, DateOnly newCheckIn, DateOnly newCheckOut)
        {
            throw new NotImplementedException();
        }

        //public Task<bool> UpdateStatusAsync(int id, ReservationStatus newStatus)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
