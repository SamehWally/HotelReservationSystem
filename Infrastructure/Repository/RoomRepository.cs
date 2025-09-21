using Domain.Models.Room;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            // throw new NotImplementedException();
            //var room = _context.Rooms.Include(r=>r.Pictures).FirstOrDefault(r=>r.Id==id);
            //if (room != null) { 
            //room.IsDeleted = true;
            //    foreach (var photo in room.Pictures)
            //    {
            //        photo.IsDeleted = true;
            //        _context.RoomPictures.Update(photo);
            //    }
            //    _context.Rooms.Update(room);
            //    _context.SaveChanges();
            //}
            var room = _context.Rooms.Find(id);
            if (room != null) 
            room.IsDeleted = true;
            _context.Rooms.Update(room);
            var photo = _context.RoomPictures.Where(p => p.RoomId == id);
            foreach (var photos in photo)
             photos.IsDeleted = true;
            _context.SaveChanges();
         
        }

        public IQueryable<Room> GetAllRooms()
        {
            return _context.Rooms.Where(r=>!r.IsDeleted);
        }

        public IEnumerable<Room> GetAvailableRooms(DateTime checkIn, DateTime checkOut)
        {
            throw new NotImplementedException();
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
