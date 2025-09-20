using Domain.Models.Room;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Room> Rooms { get; set; }
        public DbSet<Facility> Facilities { get; set; }
        public DbSet<RoomFacility> RoomFacilities { get; set; }
        public DbSet<RoomPicture> RoomPictures { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RoomFacility>()
                .HasKey(rf => new { rf.RoomId, rf.FacilityId });

            modelBuilder.Entity<RoomFacility>()
                .HasOne(rf => rf.Room)
                .WithMany(r => r.RoomFacilities)
                .HasForeignKey(rf => rf.RoomId);

            modelBuilder.Entity<RoomFacility>()
                .HasOne(rf => rf.Facility)
                .WithMany(f => f.RoomFacilities)
                .HasForeignKey(rf => rf.FacilityId);

            modelBuilder.Entity<Facility>().HasData(
                    new Facility { Id = 1, Name = "Wi-Fi" },
                    new Facility { Id = 2, Name = "Air Conditioning" },
                    new Facility { Id = 3, Name = "TV" },
                    new Facility { Id = 4, Name = "Private Bathroom" },
                    new Facility { Id = 5, Name = "Work Desk" },
                    new Facility { Id = 6, Name = "Private Balcony" },
                    new Facility { Id = 7, Name = "Jacuzzi" },
                    new Facility { Id = 8, Name = "Hair Dryer" },
                    new Facility { Id = 9, Name = "Electric Kettle" },
                    new Facility { Id = 10, Name = "Daily Housekeeping" },
                    new Facility { Id = 11, Name = "Sea View" }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}
