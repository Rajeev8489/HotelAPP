using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class DeletingDateinBooking : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 20, 19, 788, DateTimeKind.Local).AddTicks(658), "Single", new DateTime(2025, 7, 3, 10, 20, 19, 808, DateTimeKind.Local).AddTicks(5129) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 20, 19, 808, DateTimeKind.Local).AddTicks(8246), new DateTime(2025, 7, 3, 10, 20, 19, 808, DateTimeKind.Local).AddTicks(8246) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 3, 10, 20, 19, 808, DateTimeKind.Local).AddTicks(8251), new DateTime(2025, 7, 3, 10, 20, 19, 808, DateTimeKind.Local).AddTicks(8252) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "Address", "CheckInDate", "CheckOutDate", "City", "CreatedDate", "CustomerName", "PhoneNumber", "RoomId", "TotalPrice", "UpdatedDate" },
                values: new object[] { 1, "UttaraHalli", new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3477), new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3569), "Bangalore", new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3642), "Rajeev", 123456789, 1, 0.0, new DateTime(2025, 7, 1, 18, 48, 50, 628, DateTimeKind.Local).AddTicks(3709) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 18, 48, 50, 626, DateTimeKind.Local).AddTicks(6164), "Single Room", new DateTime(2025, 7, 1, 18, 48, 50, 627, DateTimeKind.Local).AddTicks(5556) });

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
    }
}
