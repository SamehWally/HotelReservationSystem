using Domain.Enums;
using Domain.Models.Reservation;

namespace Domain.Repositories
{
    public interface IReservationRepository
    {
        IQueryable<Reservation> GetAll();
        IQueryable<Reservation> GetByCustomer(int customerId);

        void AddReservation(Reservation reservation);
        Task UpdateStatusAsync(Reservation reservation);
        Task<Reservation?> GetByIdAsync(int id);
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
        IQueryable<Reservation> GetByRoomAsync(int roomId, DateTime? from, DateTime? to, ReservationStatus? status = null);
        Task<bool> SoftDeleteAsync(int id);
    }
}
