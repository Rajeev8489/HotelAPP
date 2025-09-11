using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookingTableDataInsertion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bookings",
                columns: new[] { "BookingId", "Address", "CheckInDate", "CheckOutDate", "City", "CreatedDate", "CustomerName", "PhoneNumber", "RoomId", "TotalPrice", "UpdatedDate" },
                values: new object[] { 1, "UtharaHalli", new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7604), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7608), "Bangalore", new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7609), "Rajeev", 123456789, 1, 0.0, new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7609) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 10, 18, 31, 522, DateTimeKind.Local).AddTicks(2987), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(586) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2087), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2087) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2089), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2089) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1);

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 14, 28, 48, 663, DateTimeKind.Local).AddTicks(6022) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 14, 28, 48, 664, DateTimeKind.Local).AddTicks(5837) });

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3,
                columns: new[] { "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2025, 6, 30, 14, 28, 48, 664, DateTimeKind.Local).AddTicks(5840) });
        }
    }
}
