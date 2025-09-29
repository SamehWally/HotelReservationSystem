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

        void AddReservation(Reservation reservation);

        Task UpdateStatusAsync(Reservation reservation); 

  
        Task<bool> UpdateAsync(Reservation reservation); 

        Task<bool> UpdateDatesAsync(int id, DateOnly newCheckIn, DateOnly newCheckOut);
      
        Task<bool> UpdateStatusAsync(int id, ReservationStatus newStatus);     
      
        IQueryable<Reservation> Search(
       int? roomId = null,
       int? customerId = null,
       DateOnly? from = null,
       DateOnly? to = null,
       ReservationStatus? status = null);

        Reservation? GetById(int id);
      
        IQueryable<Reservation> GetDetails(int id);

        Task<bool> UpdateDatesAsync(int id, DateTime newCheckIn, DateTime newCheckOut);
    

        Task<IQueryable<Reservation>> GetAllAsync();        

  
        Task<IQueryable<Reservation>> GetByCustomerAsync(int customerId, DateOnly? from, DateOnly? to, ReservationStatus? status = null);

        IQueryable<Reservation> GetByRoomAsync(int roomId, DateTime? from, DateTime? to, ReservationStatus? status = null);
        Task<bool> IsRoomAvailableAsync(int roomId, DateOnly checkIn, DateOnly checkOut);    
  
        Task<bool> SoftDeleteAsync(int id);
    }
}
