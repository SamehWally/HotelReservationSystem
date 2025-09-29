using Domain.Models.AccessControl;
using Domain.Models.Reservation;
using Domain.Models.Room;
using Domain.Models.Users;
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
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region RoomFacilitiesConfigurations
            modelBuilder.Entity<RoomFacility>().Ignore(r => r.Id);

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

            #endregion

            #region RolesConfigurations
            // =========================
            // Role
            // =========================
            modelBuilder.Entity<Role>(b =>
            {
                b.ToTable("Roles");

                b.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(100);

                b.HasIndex(x => x.Name).IsUnique();

                b.Property(x => x.Description)
                 .HasMaxLength(300);

                // SoftDelete filter
                b.HasQueryFilter(x => !x.IsDeleted);

                b.HasMany(x => x.StaffMembers)
                 .WithOne(s => s.Role)
                 .HasForeignKey(s => s.RoleId)
                 .OnDelete(DeleteBehavior.Restrict);

                b.HasMany(x => x.RoleFeatures)
                 .WithOne(rf => rf.Role)
                 .HasForeignKey(rf => rf.RoleId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // Feature
            // =========================
            modelBuilder.Entity<Feature>(b =>
            {
                b.ToTable("Features");

                b.Property(x => x.Key)
                 .IsRequired()
                 .HasMaxLength(150);

                b.HasIndex(x => x.Key).IsUnique();

                b.Property(x => x.Name)
                 .IsRequired()
                 .HasMaxLength(150);

                b.HasQueryFilter(x => !x.IsDeleted);

                b.HasMany(x => x.RoleFeatures)
                 .WithOne(rf => rf.Feature)
                 .HasForeignKey(rf => rf.FeatureId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            // =========================
            // RoleFeature (Join)
            // =========================
            modelBuilder.Entity<RoleFeature>(b =>
            {
                b.ToTable("RoleFeatures");

                b.Property(x => x.RoleId).IsRequired();
                b.Property(x => x.FeatureId).IsRequired();

                b.HasIndex(x => new { x.RoleId, x.FeatureId }).IsUnique();

                b.HasOne(x => x.Role)
                 .WithMany(r => r.RoleFeatures)
                 .HasForeignKey(x => x.RoleId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasOne(x => x.Feature)
                 .WithMany(f => f.RoleFeatures)
                 .HasForeignKey(x => x.FeatureId)
                 .OnDelete(DeleteBehavior.Cascade);

                b.HasQueryFilter(x => !x.IsDeleted);
            });
            #endregion

            #region Seeding
            var seedAt = DateTime.UtcNow;

            // 1) Features
            modelBuilder.Entity<Feature>().HasData(
                new Feature { Id = 1, Key = "role.read", Name = "عرض الأدوار", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 2, Key = "role.create", Name = "إنشاء دور", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 3, Key = "role.update", Name = "تعديل دور", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 4, Key = "role.delete", Name = "حذف دور", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 5, Key = "role.assignFeatures", Name = "تعيين الصلاحيات", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },

                new Feature { Id = 10, Key = "feature.read", Name = "عرض الصلاحيات", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },

                new Feature { Id = 20, Key = "staff.read", Name = "عرض الموظفين", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 21, Key = "staff.create", Name = "إنشاء موظف", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 22, Key = "staff.update", Name = "تعديل موظف", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new Feature { Id = 23, Key = "staff.delete", Name = "حذف موظف", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt }
            );

            // 2) Role: Admin
            modelBuilder.Entity<Role>().HasData(
                new Role { Id = 1, Name = "Admin", Description = "النظام/كل الصلاحيات", IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt }
            );

            // 3) RoleFeatures:  Admin Access to all Features
            modelBuilder.Entity<RoleFeature>().HasData(
                new RoleFeature { Id = 1001, RoleId = 1, FeatureId = 1, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1002, RoleId = 1, FeatureId = 2, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1003, RoleId = 1, FeatureId = 3, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1004, RoleId = 1, FeatureId = 4, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1005, RoleId = 1, FeatureId = 5, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },

                new RoleFeature { Id = 1010, RoleId = 1, FeatureId = 10, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },

                new RoleFeature { Id = 1020, RoleId = 1, FeatureId = 20, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1021, RoleId = 1, FeatureId = 21, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1022, RoleId = 1, FeatureId = 22, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt },
                new RoleFeature { Id = 1023, RoleId = 1, FeatureId = 23, IsActive = true, IsDeleted = false, CreatedDate = seedAt, UpdatedDate = seedAt }
            ); 
            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}
