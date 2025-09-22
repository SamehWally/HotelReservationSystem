using Domain.Models.Room;
using Domain.Repositories;

namespace Infrastructure.Repository
{
    public class RoomRepository : IRoomRepository
    {
        private readonly Context _context;

        public RoomRepository(Context context)
        {
            _context = context;
        }

        public void AddRoom(Room room)
        {
            _context.Rooms.Add(room);
            _context.SaveChanges();
        }

        public void DeleteRoom(int id)
        {
            var room = _context.Rooms.Find(id);
            if (room != null)
                room.IsDeleted = true;

            var photo = _context.RoomPictures.Where(p => p.RoomId == id);
            foreach (var photos in photo)
                photos.IsDeleted = true;

            _context.SaveChanges();
        }

        public IQueryable<Room> GetAllRooms()
        {
            return _context.Rooms.Where(r => !r.IsDeleted);
        }

        public IQueryable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            var avilableRomms = _context.Rooms.Where((c) => c.IsAvailable);
            return avilableRomms;
        }


        public Room? GetRoomById(int id)
        {
            var room = _context.Rooms.FirstOrDefault(r => r.Id == id);
            return room;
        }

        public void UpdateRoom(Room room)
        {
            _context.Rooms.Update(room);
            _context.SaveChanges();
        }
    }
}
