using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelAPI.Migrations
{
    /// <inheritdoc />
    public partial class BookingTableDataInsertionNewww : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Bookings",
                keyColumn: "BookingId",
                keyValue: 1,
                columns: new[] { "Address", "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: ["UttaraHalli", new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1095), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1101), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1101), new DateTime(2025, 7, 1, 18, 27, 49, 671, DateTimeKind.Local).AddTicks(1102)]);

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "RoomId", "CreatedDate", "Name", "TotalRooms", "Type", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 7, 1, 18, 27, 49, 668, DateTimeKind.Local).AddTicks(9046), "Single Room", 1, "Deluxe", new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(3176) },
                    { 2, new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4434), "Double", 2, "Luxury", new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4434) },
                    { 3, new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4437), "Triple", 3, "Super Luxury", new DateTime(2025, 7, 1, 18, 27, 49, 670, DateTimeKind.Local).AddTicks(4437) }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                columns: new[] { "Address", "CheckInDate", "CheckOutDate", "CreatedDate", "UpdatedDate" },
                values: new object[] { "UttaraHalli", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
