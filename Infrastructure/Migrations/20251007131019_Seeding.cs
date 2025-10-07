using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Users_UserId1",
                table: "Customers");

            migrationBuilder.DropForeignKey(
                name: "FK_Staff_Users_UserId1",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Staff_UserId1",
                table: "Staff");

            migrationBuilder.DropIndex(
                name: "IX_Customers_UserId1",
                table: "Customers");

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Staff");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Customers");

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "DateOfBirth", "IsActive", "IsDeleted", "NationalId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, null, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8588), null, true, false, null, null, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8590), 1 });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8636), "Allows creating, updating, and cancelling bookings", "BOOKING_MANAGEMENT", "Manage Bookings", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8638) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8644), " Allows adding, updating, and removing rooms", "ROOM_MANAGEMENT", "Manage Rooms", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8646) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8652), "Allows viewing various system reports", "REPORTS_VIEW", "View Reports", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8654) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8661), new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8663) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8668), new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8670) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8676), new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8678) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "FeatureId", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8683), 1, 3, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8685) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "FeatureId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8690), 1, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8692) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8610), "System administrator with full access", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8612) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8618), "Can make reservations and manage bookings", "Customer", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8620) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8626), "Handles reservations and room management", "Staff", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8628) });

            migrationBuilder.InsertData(
                table: "Staff",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Department", "HireDate", "IsActive", "IsDeleted", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 1, null, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8599), null, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8592), true, false, null, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8600), 2 });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8700), 2, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8702) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8707), 3, new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8709) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UpdatedDate", "Username" },
                values: new object[] { "Cairo", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8568), "customer1@email.com", "Ali", "Mahmoud", "hashed_password_1", "0100000001", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8570), "customer1" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UpdatedDate", "Username" },
                values: new object[] { "Giza", "Giza", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8578), "staff1@email.com", "Sara", "Youssef", "hashed_password_2", "0100000002", new DateTime(2025, 10, 7, 16, 10, 17, 535, DateTimeKind.Local).AddTicks(8580), "staff1" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Staff",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Staff",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Customers",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3579), "Create new user", "USER_CREATE", "CanCreateUser", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3581) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3585), "View all users", "USER_VIEW", "CanViewUsers", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3586) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Key", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3589), "Assign role to user", "ROLE_ASSIGN", "CanAssignRoleToUser", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3590) });

            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDeleted", "Key", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 4, null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3593), "Assign feature to role", true, false, "FEATURE_ASSIGN", "CanAssignFeatureToRole", null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3594) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4031), new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4033) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4035), new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4036) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4038), new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4039) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "FeatureId", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4041), 4, 1, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4042) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "FeatureId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4044), 2, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4045) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Description", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3486), "System Administrator", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3529) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3537), "Hotel Staff", "Staff", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3538) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "Description", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3541), "Regular Customer", "Customer", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3542) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3999), 1, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4002) });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "RoleId", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4006), 2, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4007) });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Address", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UpdatedDate", "Username" },
                values: new object[] { "HQ Office", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3607), "admin@hotel.com", "System", "Admin", "6G94qKPK8LYNjnTllCqm2G3BUM08AzOK7yW30tfjrMc=", "01000000001", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3609), "jGl25bVBBBW96Qi9Te4V37Fnqchz/Eu4qB9vKrRIqRg=" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Address", "City", "CreatedDate", "Email", "FirstName", "LastName", "PasswordHash", "PhoneNumber", "UpdatedDate", "Username" },
                values: new object[] { "Hotel Reception", "Cairo", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3881), "staff@hotel.com", "Hotel", "Staff", "39SPNjOKo2Io67niBLumtOGNsLYj4lxFiQHtyDH7GOk=", "01000000002", new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3884), "FWIgZUPadkEjwhvVJGdPCoqvSciol0TJc1L+Z39+QAY=" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Address", "City", "Country", "CreatedBy", "CreatedDate", "Email", "FirstName", "IsActive", "IsDeleted", "LastName", "PasswordHash", "PhoneNumber", "UpdatedBy", "UpdatedDate", "Username" },
                values: new object[] { 3, "Main Street", "Giza", "Egypt", null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3913), "customer@hotel.com", "John", true, false, "Doe", "mOxlSo3yj48PjwIiBIPUaRa4UBfeC3TY7HVcKMuFOag=", "01000000003", null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(3914), "tsRYY4deNEh8o8FV7RRe/hKnRYHie+/sWqZhuO6Mpt0=" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "RoleId", "UpdatedBy", "UpdatedDate", "UserId" },
                values: new object[] { 3, null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4010), true, false, 3, null, new DateTime(2025, 10, 4, 22, 8, 8, 732, DateTimeKind.Local).AddTicks(4011), 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Staff_UserId1",
                table: "Staff",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_UserId1",
                table: "Customers",
                column: "UserId1",
                unique: true,
                filter: "[UserId1] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Users_UserId1",
                table: "Customers",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Staff_Users_UserId1",
                table: "Staff",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
