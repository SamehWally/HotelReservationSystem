using Domain.Enums;
using Domain.Models.Room;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;

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
            return  GetAllRooms().Where(r => r.IsAvailable)
                .Where(r => !_context.Reservations.Any(res =>
                res.RoomId == r.Id &&
                res.Status != ReservationStatus.Canceled &&
                res.CheckIn < checkOut &&
                checkIn < res.CheckOut));
        }
        public async Task<bool> CheckRoomAvilable(int id)
        {
            return await _context.Rooms
                .AsNoTracking()
                .AnyAsync(r => r.Id == id && r.IsAvailable && !r.IsDeleted);
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

        public bool IsRoomAvailable(int roomid, DateTime checkIn, DateTime checkOut)
        {
            return !_context.Reservations
             .Any(r =>
                 r.RoomId == roomid &&
     
                 (
                     (checkIn >= r.CheckIn && checkIn < r.CheckOut) ||   // CheckIn داخل فترة قديمة
                     (checkOut > r.CheckIn && checkOut <= r.CheckOut) || // CheckOut داخل فترة قديمة
                     (checkIn <= r.CheckIn && checkOut >= r.CheckOut)    // الفترة الجديدة تغطي حجز قديم
               )  );
        }
    }
}
