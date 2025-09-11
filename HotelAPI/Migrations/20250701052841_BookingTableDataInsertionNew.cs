using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookingTableDataInsertionNew : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "RoomId",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: new object[] { new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7604), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7608), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7609), new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(7609) });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "CreatedDate", "Name", "TotalRooms", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 1, 10, 18, 31, 522, DateTimeKind.Local).AddTicks(2987), "Single Room", 1, "Deluxe", new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(586) },
                    { 2, new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2087), "Double", 2, "Luxury", new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2087) },
                    { 3, new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2089), "Triple", 3, "Super Luxury", new DateTime(2025, 7, 1, 10, 18, 31, 554, DateTimeKind.Local).AddTicks(2089) }
                });
        }
    }
}
