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
using Domain.Helpers;

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


        public DbSet<User> Users { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Staff> Staff {  get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<RoleFeature> RoleFeatures { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }



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

                b.HasMany(x => x.UserRoles)
                 .WithOne(s => s.Role)
                 .HasForeignKey(s => s.RoleId)
                 .OnDelete(DeleteBehavior.Restrict)
                 .IsRequired(false);

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

            // ===== Users =====
            var user1 = new User
            {
                Id = 1,
                Username = "customer1",
                Email = "customer1@email.com",
                PasswordHash = "hashed_password_1",
                FirstName = "Ali",
                LastName = "Mahmoud",
                PhoneNumber = "0100000001",
                Address = "Cairo",
                City = "Cairo",
                Country = "Egypt",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var user2 = new User
            {
                Id = 2,
                Username = "staff1",
                Email = "staff1@email.com",
                PasswordHash = "hashed_password_2",
                FirstName = "Sara",
                LastName = "Youssef",
                PhoneNumber = "0100000002",
                Address = "Giza",
                City = "Giza",
                Country = "Egypt",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // ===== Customers =====
            var customer1 = new Customer
            {
                Id = 1,
                UserId = 1,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // ===== Staff =====
            var staff1 = new Staff
            {
                Id = 1,
                UserId = 2,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // ===== Roles =====
            //var roleAdmin = new Role
            //{
            //    Id = 1,
            //    Name = "Admin",
            //    Description = "System administrator with full access",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now
            //};

            //var roleCustomer = new Role
            //{
            //    Id = 2,
            //    Name = "Customer",
            //    Description = "Can make reservations and manage bookings",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now
            //};

            //var roleStaff = new Role
            //{
            //    Id = 3,
            //    Name = "Staff",
            //    Description = "Handles reservations and room management",
            //    IsActive = true,
            //    IsDeleted = false,
            //    CreatedDate = DateTime.Now,
            //    UpdatedDate = DateTime.Now
            //};

            // ===== Features =====
            var featureBooking = new Feature
            {
                Id = 1,
                Key = "BOOKING_MANAGEMENT",
                Name = "Manage Bookings",
                Description="Allows creating, updating, and cancelling bookings",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var featureRooms = new Feature
            {
                Id = 2,
                Key = "ROOM_MANAGEMENT",
                Name = "Manage Rooms",
                Description =" Allows adding, updating, and removing rooms",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var featureReports = new Feature
            {
                Id = 3,
                Key = "REPORTS_VIEW",
                Name = "View Reports",
                Description= "Allows viewing various system reports",
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // ===== RoleFeatures =====
            var roleFeatureAdmin1 = new RoleFeature
            {
                Id = 1,
                RoleId = 1,
                FeatureId = 1,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var roleFeatureAdmin2 = new RoleFeature
            {
                Id = 2,
                RoleId = 1,
                FeatureId = 2,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var roleFeatureAdmin3 = new RoleFeature
            {
                Id = 3,
                RoleId = 1,
                FeatureId = 3,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var roleFeatureStaff = new RoleFeature
            {
                Id = 4,
                RoleId = 3,
                FeatureId = 1,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var roleFeatureCustomer = new RoleFeature
            {
                Id = 5,
                RoleId = 2,
                FeatureId = 1,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // ===== UserRoles =====
            var userRoleCustomer = new UserRole
            {
                Id = 1,
                UserId = 1,
                RoleId = 2,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            var userRoleStaff = new UserRole
            {
                Id = 2,
                UserId = 2,
                RoleId = 3,
                IsActive = true,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                UpdatedDate = DateTime.Now
            };

            // Add to modelBuilder
            modelBuilder.Entity<User>().HasData(user1, user2);
            modelBuilder.Entity<Customer>().HasData(customer1);
            modelBuilder.Entity<Staff>().HasData(staff1);
            modelBuilder.Entity<Role>().HasData(roleAdmin, roleCustomer, roleStaff);
            modelBuilder.Entity<Feature>().HasData(featureBooking, featureRooms, featureReports);
            modelBuilder.Entity<RoleFeature>().HasData(
                roleFeatureAdmin1, roleFeatureAdmin2, roleFeatureAdmin3,
                roleFeatureStaff, roleFeatureCustomer
            );
            modelBuilder.Entity<UserRole>().HasData(userRoleCustomer, userRoleStaff);

            #endregion


            #region Composite Design

            #endregion
            modelBuilder.Entity<Customer>(b =>
            {
                b.ToTable("Customers");
                b.HasKey(c => c.Id);
                b.HasIndex(c => c.UserId).IsUnique();
                b.HasOne(c => c.User)
                 .WithOne(u => u.Customer)
                 .HasForeignKey<Customer>(c => c.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Staff>(b =>
            {
                b.ToTable("Staff");
                b.HasKey(s => s.Id);
                b.HasIndex(s => s.UserId).IsUnique();
                b.HasOne(s => s.User)
                 .WithOne(u => u.Staff)
                 .HasForeignKey<Staff>(s => s.UserId)
                 .OnDelete(DeleteBehavior.Cascade);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
