using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class AddSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Row",
                table: "Seats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "GenreName" },
                values: new object[,]
                {
                    { 1, "Action" },
                    { 2, "Comedy" },
                    { 3, "Drama" },
                    { 4, "Horror" },
                    { 5, "Sci-Fi" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "MovieId", "DurationMinutes", "Rating", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { 1, 148, 8.8m, new DateTime(2010, 7, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Inception" },
                    { 2, 152, 9.0m, new DateTime(2008, 7, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Dark Knight" },
                    { 3, 142, 9.3m, new DateTime(1994, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Shawshank Redemption" },
                    { 4, 175, 9.2m, new DateTime(1972, 3, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Godfather" },
                    { 5, 88, 6.2m, new DateTime(2000, 7, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Scary Movie" }
                });

            migrationBuilder.InsertData(
                table: "PostalCodes",
                columns: new[] { "PostalCodeId", "Name" },
                values: new object[,]
                {
                    { 1, "12345" },
                    { 2, "67890" },
                    { 3, "13579" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "RoleName" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Customer" }
                });

            migrationBuilder.InsertData(
                table: "TheaterHalls",
                columns: new[] { "TheaterHallId", "AddressId", "Capacity", "Name", "RowNumber", "SeatId", "SeatNumber" },
                values: new object[,]
                {
                    { 1, 0, 150, "Main Hall", 0, 0, 0 },
                    { 2, 0, 100, "Second Hall", 0, 0, 0 },
                    { 3, 0, 50, "Small Hall", 0, 0, 0 },
                    { 4, 0, 20, "VIP Hall", 0, 0, 0 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "City", "Country", "PostalCodeId", "Street" },
                values: new object[,]
                {
                    { 1, "Odense", "Denmark", 1, "123 Main St" },
                    { 2, "Copenhagen", "Denmark", 2, "456 Elm St" },
                    { 3, "Aarhus", "Denmark", 3, "789 Oak St" }
                });

            migrationBuilder.InsertData(
                table: "MovieGenres",
                columns: new[] { "GenresGenreId", "MoviesMovieId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 2, 5 },
                    { 3, 2 },
                    { 3, 3 },
                    { 3, 4 },
                    { 4, 5 },
                    { 5, 1 }
                });

            migrationBuilder.InsertData(
                table: "Seats",
                columns: new[] { "SeatId", "Row", "SeatNumber", "TheaterHallId", "TicketId" },
                values: new object[,]
                {
                    { 1, "A", 1, 1, null },
                    { 2, "A", 2, 1, null },
                    { 3, "A", 3, 1, null },
                    { 4, "A", 4, 1, null },
                    { 5, "A", 5, 1, null },
                    { 6, "A", 6, 1, null },
                    { 7, "B", 1, 2, null },
                    { 8, "B", 2, 2, null },
                    { 9, "B", 3, 2, null },
                    { 10, "B", 4, 2, null },
                    { 11, "B", 5, 2, null },
                    { 12, "C", 1, 3, null },
                    { 13, "C", 2, 3, null },
                    { 14, "C", 3, 3, null },
                    { 15, "C", 4, 3, null },
                    { 16, "VP", 1, 4, null },
                    { 17, "VP", 2, 4, null },
                    { 18, "VP", 3, 4, null }
                });

            migrationBuilder.InsertData(
                table: "Showtimes",
                columns: new[] { "ShowtimeId", "MovieId", "ShowtimeDateTime", "TheaterHallId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 10, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, 2, new DateTime(2025, 10, 1, 21, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, 3, new DateTime(2025, 10, 2, 19, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 4, 4, new DateTime(2025, 10, 2, 21, 0, 0, 0, DateTimeKind.Unspecified), 4 },
                    { 5, 5, new DateTime(2025, 10, 3, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "AddressId", "CreateDate", "Email", "FirstName", "LastName", "PasswordHash", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8709), "john.doe@example.com", "John", "Doe", "hashedpassword", 1 },
                    { 2, 2, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8714), "jane.smith@example.com", "Jane", "Smith", "hashedpassword2", 2 },
                    { 3, 3, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8717), "alice.johnson@example.com", "Alice", "Johnson", "hashedpassword3", 2 }
                });

            migrationBuilder.InsertData(
                table: "Reviews",
                columns: new[] { "ReviewId", "Content", "MovieId", "Rating", "ReviewDate", "UserId" },
                values: new object[,]
                {
                    { 1, "Very confusing but great movie!", 1, 8.8m, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8765), 1 },
                    { 2, "Heath Ledger was amazing!", 2, 9.0m, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8768), 2 },
                    { 3, "One of the best movies of all time!", 3, 9.3m, new DateTime(2025, 2, 11, 10, 26, 0, 46, DateTimeKind.Local).AddTicks(8771), 3 }
                });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "IsBooked", "Price", "SeatId", "ShowtimeId", "UserId" },
                values: new object[,]
                {
                    { 1, false, 0m, 0, 1, 1 },
                    { 2, false, 0m, 0, 3, 2 },
                    { 3, false, 0m, 0, 5, 3 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "RoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_RoleId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_RoleId",
                table: "Users");

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 4, 5 });

            migrationBuilder.DeleteData(
                table: "MovieGenres",
                keyColumns: new[] { "GenresGenreId", "MoviesMovieId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Reviews",
                keyColumn: "ReviewId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Seats",
                keyColumn: "SeatId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "ShowtimeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "ShowtimeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "ShowtimeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "ShowtimeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Showtimes",
                keyColumn: "ShowtimeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TheaterHalls",
                keyColumn: "TheaterHallId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Addresses",
                keyColumn: "AddressId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "MovieId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TheaterHalls",
                keyColumn: "TheaterHallId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TheaterHalls",
                keyColumn: "TheaterHallId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TheaterHalls",
                keyColumn: "TheaterHallId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PostalCodes",
                keyColumn: "PostalCodeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PostalCodes",
                keyColumn: "PostalCodeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PostalCodes",
                keyColumn: "PostalCodeId",
                keyValue: 3);

            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Row",
                table: "Seats");

            migrationBuilder.AddColumn<int>(
                name: "Row",
                table: "Seats",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
