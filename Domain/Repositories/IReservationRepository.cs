using Domain.Enums;
using Domain.Models.Reservation;
using Domain.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IReservationRepository
    {
        Task<bool> AddAsync(Reservation reservation);
        Task<bool> UpdateAsync(Reservation reservation); 
        Task<bool> UpdateDatesAsync(int id, DateTime newCheckIn, DateTime newCheckOut);
        Task<bool> UpdateStatusAsync(int id, ReservationStatus newStatus);
        Task<IQueryable<Reservation>> GetAllAsync();    
        Task<Reservation?> GetByIdAsync(int id);
        Task<Reservation?> GetDetailsAsync(int id);  //WhichRoom,Customer
        Task<IQueryable<Reservation>> GetByCustomerAsync(int customerId, DateOnly? from, DateOnly? to, ReservationStatus? status = null);
        Task<IQueryable<Reservation>> GetByRoomAsync(int roomId, DateOnly? from, DateOnly? to, ReservationStatus? status = null);
        Task<bool> IsRoomAvailableAsync(int roomId, DateOnly checkIn, DateOnly checkOut);
        Task<IQueryable<Reservation>> SearchAsync(int? roomId = null, int? customerId = null, DateOnly? from = null, DateOnly? to = null, ReservationStatus? status = null);
        Task<bool> SoftDeleteAsync(int id);
    }
}
