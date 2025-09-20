using Domain.Models.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IRoomRepository
    {
        void AddRoom(Room room);
        void UpdateRoom(Room room);
        void DeleteRoom(int id);
        Room? GetRoomById(int id);
        IEnumerable<Room> GetAllRooms();
        IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut);
    }
}
