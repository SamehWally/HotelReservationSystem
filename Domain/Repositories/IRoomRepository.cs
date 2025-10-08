using Domain.Models.Room;

namespace Domain.Repositories
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        Room? GetRoomById(int id);
        IQueryable<Room> GetAllRooms();
        IQueryable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut);
        bool IsRoomAvailable(int roomid, DateTime checkIn, DateTime checkOut);
    }
}
