using Domain.Models.Reservation;
using Domain.Models.Room;
using Domain.Models.Users;
using Domain.Repositories;


namespace Infrastructure.Repository { 
internal class ReportRepository : IReportRepository
{
    private readonly Context _context;
    public ReportRepository(Context context)
    {
        _context = context;
    }


    public IQueryable<Reservation> GetAllReservations()
    {
        return _context.Reservations;
    }

    public IQueryable<Room> GetAllRooms()
    {
        return _context.Rooms;
    }

    public IQueryable<Customer> GetAllCustomers()
    {
        return _context.Customers;
    }
}}
