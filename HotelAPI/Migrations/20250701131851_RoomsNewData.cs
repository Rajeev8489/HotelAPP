using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class RoomsNewData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3477), new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3569), new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3642), new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3709) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 48, 50, 626, DateTimeKind.Local).AddTicks(6164), new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(5556) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(6352), new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(6352) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(6354), new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(6354) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1095), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1101), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1101), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 27, 49, 668, DateTimeKind.Local).AddTicks(9046), new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(3176) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4434), new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4437), new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4437) });
        }
    }
}
