using Domain.Models.Reservation;
using Domain.Models.Room;
using Domain.Models.Users;


namespace Domain.Repositories
{
    public interface IReportRepository
    {
        IQueryable<Reservation> GetAllReservations();
        IQueryable<Room> GetAllRooms();
        IQueryable<Customer> GetAllCustomers();
    }
}