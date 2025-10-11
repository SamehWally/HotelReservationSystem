using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Report : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Staff",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "Number",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896), new DateTime(2025, 10, 11, 14, 54, 20, 548, DateTimeKind.Utc).AddTicks(2896) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Number",
                table: "Rooms");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HireDate",
                table: "Staff",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Staff",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 20,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 21,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 22,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Features",
                keyColumn: "Id",
                keyValue: 23,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1001,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1002,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1003,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1004,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1005,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1010,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1020,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1021,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1022,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "RoleFeatures",
                keyColumn: "Id",
                keyValue: 1023,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118), new DateTime(2025, 9, 29, 10, 21, 12, 136, DateTimeKind.Utc).AddTicks(7118) });
        }
    }
}
