using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Seeding : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Features",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "IsActive", "IsDeleted", "Key", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "role.read", "عرض الأدوار", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 2, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "role.create", "إنشاء دور", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 3, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "role.update", "تعديل دور", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 4, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "role.delete", "حذف دور", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 5, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "role.assignFeatures", "تعيين الصلاحيات", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 10, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "feature.read", "عرض الصلاحيات", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 20, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "staff.read", "عرض الموظفين", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 21, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "staff.create", "إنشاء موظف", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 22, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "staff.update", "تعديل موظف", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 23, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), true, false, "staff.delete", "حذف موظف", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "Description", "IsActive", "IsDeleted", "Name", "UpdatedBy", "UpdatedDate" },
                values: new object[] { 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), "النظام/كل الصلاحيات", true, false, "Admin", null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.InsertData(
                table: "RoleFeatures",
                columns: new[] { "Id", "CreatedBy", "CreatedDate", "FeatureId", "IsActive", "IsDeleted", "RoleId", "UpdatedBy", "UpdatedDate" },
                values: new object[,]
                {
                    { 1001, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 1, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1002, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 2, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1003, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 3, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1004, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 4, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1005, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 5, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1010, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 10, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1020, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 20, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1021, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 21, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1022, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 22, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) },
                    { 1023, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), 23, true, false, 1, null, new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1001);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1002);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1003);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1004);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1005);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1010);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1020);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1021);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1022);

            migrationBuilder.DeleteData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1023);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
