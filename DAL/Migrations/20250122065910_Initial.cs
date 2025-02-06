using System;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            {
                // Drop the foreign key constraints referencing the Movies table
                migrationBuilder.Sql("IF OBJECT_ID('FK_Showtimes_Movies_MovieId', 'F') IS NOT NULL ALTER TABLE Showtimes DROP CONSTRAINT FK_Showtimes_Movies_MovieId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_Reviews_Movies_MovieId', 'F') IS NOT NULL ALTER TABLE Reviews DROP CONSTRAINT FK_Reviews_Movies_MovieId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_MovieGenres_Movies_MoviesMovieId', 'F') IS NOT NULL ALTER TABLE MovieGenres DROP CONSTRAINT FK_MovieGenres_Movies_MoviesMovieId");

                // Drop the foreign key constraints referencing the Genres table
                migrationBuilder.Sql("IF OBJECT_ID('MovieGenres', 'U') IS NOT NULL ALTER TABLE MovieGenres DROP CONSTRAINT FK_MovieGenres_Genres_GenresGenreId");

                // Drop the foreign key constraints referencing the PostalCodes table
                migrationBuilder.Sql("IF OBJECT_ID('FK_Addresses_PostalCodes_PostalCodeId', 'F') IS NOT NULL ALTER TABLE Addresses DROP CONSTRAINT FK_Addresses_PostalCodes_PostalCodeId");

                // Drop the foreign key constraints referencing the Roles table
                migrationBuilder.Sql("IF OBJECT_ID('FK_UserRoles_Roles_RolesRoleId', 'F') IS NOT NULL ALTER TABLE UserRoles DROP CONSTRAINT FK_UserRoles_Roles_RolesRoleId");

                // Drop the foreign key constraints referencing the Addresses table
                migrationBuilder.Sql("IF OBJECT_ID('FK_TheaterHalls_Addresses_AddressId', 'F') IS NOT NULL ALTER TABLE TheaterHalls DROP CONSTRAINT FK_TheaterHalls_Addresses_AddressId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_Users_Addresses_AddressId','F') IS NOT NULL ALTER TABLE Users DROP CONSTRAINT FK_Users_Addresses_AddressId");

                // Drop the foreign key constraints referencing the TheaterHalls table
                migrationBuilder.Sql("IF OBJECT_ID('FK_Seats_TheaterHalls_TheaterHallId', 'F') IS NOT NULL ALTER TABLE Seats DROP CONSTRAINT FK_Seats_TheaterHalls_TheaterHallId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_Showtimes_TheaterHalls_TheaterHallId', 'F') IS NOT NULL ALTER TABLE Showtimes DROP CONSTRAINT FK_Showtimes_TheaterHalls_TheaterHallId");

                // Drop the foreign key constraints referencing the Users table
                migrationBuilder.Sql("IF OBJECT_ID('FK_Reviews_Users_UserId', 'F') IS NOT NULL ALTER TABLE Reviews DROP CONSTRAINT FK_Reviews_Users_UserId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_Tickets_Users_UserId', 'F') IS NOT NULL ALTER TABLE Tickets DROP CONSTRAINT FK_Tickets_Users_UserId");
                migrationBuilder.Sql("IF OBJECT_ID('FK_UserRoles_Users_UsersUserId', 'F') IS NOT NULL ALTER TABLE UserRoles DROP CONSTRAINT FK_UserRoles_Users_UsersUserId");

                // Drop the foreign key constraints referencing the Showtimes table
                migrationBuilder.Sql("IF OBJECT_ID('FK_Tickets_Showtimes_ShowtimeId', 'F') IS NOT NULL ALTER TABLE Tickets DROP CONSTRAINT FK_Tickets_Showtimes_ShowtimeId");

                // Drop the existing Genres table if it exists
                migrationBuilder.Sql("IF OBJECT_ID('MovieGenres', 'U') IS NOT NULL DROP TABLE MovieGenres");
                migrationBuilder.Sql("IF OBJECT_ID('Genres', 'U') IS NOT NULL DROP TABLE Genres");
                migrationBuilder.Sql("IF OBJECT_ID('Movies', 'U') IS NOT NULL DROP TABLE Movies");
                migrationBuilder.Sql("IF OBJECT_ID('PostalCodes', 'U') IS NOT NULL DROP TABLE PostalCodes");
                migrationBuilder.Sql("IF OBJECT_ID('Roles', 'U') IS NOT NULL DROP TABLE Roles");
                migrationBuilder.Sql("IF OBJECT_ID('Addresses', 'U') IS NOT NULL DROP TABLE Addresses");
                migrationBuilder.Sql("IF OBJECT_ID('TheaterHalls', 'U') IS NOT NULL DROP TABLE TheaterHalls");
                migrationBuilder.Sql("IF OBJECT_ID('Users', 'U') IS NOT NULL DROP TABLE Users");
                migrationBuilder.Sql("IF OBJECT_ID('Seats', 'U') IS NOT NULL DROP TABLE Seats");
                migrationBuilder.Sql("IF OBJECT_ID('Showtimes', 'U') IS NOT NULL DROP TABLE Showtimes");
                migrationBuilder.Sql("IF OBJECT_ID('Reviews', 'U') IS NOT NULL DROP TABLE Reviews");
                migrationBuilder.Sql("IF OBJECT_ID('Tickets', 'U') IS NOT NULL DROP TABLE Tickets");
                migrationBuilder.Sql("IF OBJECT_ID('UserRoles', 'U') IS NOT NULL DROP TABLE UserRoles");


                migrationBuilder.CreateTable(
                name: "Genres",
                columns: table => new
                {
                    GenreId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Genres", x => x.GenreId);
                });

                migrationBuilder.CreateTable(
                    name: "Movies",
                    columns: table => new
                    {
                        MovieId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        DurationMinutes = table.Column<int>(type: "int", nullable: false),
                        Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                        ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Movies", x => x.MovieId);
                    });

                migrationBuilder.CreateTable(
                    name: "PostalCodes",
                    columns: table => new
                    {
                        PostalCodeId = table.Column<int>(type: "int", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_PostalCodes", x => x.PostalCodeId);
                    });

                migrationBuilder.CreateTable(
                    name: "Roles",
                    columns: table => new
                    {
                        RoleId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        RoleName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Roles", x => x.RoleId);
                    });

                migrationBuilder.CreateTable(
                    name: "MovieGenres",
                    columns: table => new
                    {
                        GenresGenreId = table.Column<int>(type: "int", nullable: false),
                        MoviesMovieId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_MovieGenres", x => new { x.GenresGenreId, x.MoviesMovieId });
                        table.ForeignKey(
                            name: "FK_MovieGenres_Genres_GenresGenreId",
                            column: x => x.GenresGenreId,
                            principalTable: "Genres",
                            principalColumn: "GenreId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_MovieGenres_Movies_MoviesMovieId",
                            column: x => x.MoviesMovieId,
                            principalTable: "Movies",
                            principalColumn: "MovieId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "Addresses",
                    columns: table => new
                    {
                        AddressId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        Street = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                        City = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                        PostalCodeId = table.Column<int>(type: "int", nullable: false),
                        Country = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Addresses", x => x.AddressId);
                        table.ForeignKey(
                            name: "FK_Addresses_PostalCodes_PostalCodeId",
                            column: x => x.PostalCodeId,
                            principalTable: "PostalCodes",
                            principalColumn: "PostalCodeId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "TheaterHalls",
                    columns: table => new
                    {
                        TheaterHallId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        SeatId = table.Column<int>(type: "int", nullable: false),
                        RowNumber = table.Column<int>(type: "int", nullable: false),
                        SeatNumber = table.Column<int>(type: "int", nullable: false),
                        Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                        AddressId = table.Column<int>(type: "int", nullable: false),
                        Capacity = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_TheaterHalls", x => x.TheaterHallId);
                        table.ForeignKey(
                            name: "FK_TheaterHalls_Addresses_AddressId",
                            column: x => x.AddressId,
                            principalTable: "Addresses",
                            principalColumn: "AddressId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "Users",
                    columns: table => new
                    {
                        UserId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                        LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                        Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                        PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()"),
                        AddressId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Users", x => x.UserId);
                        table.ForeignKey(
                            name: "FK_Users_Addresses_AddressId",
                            column: x => x.AddressId,
                            principalTable: "Addresses",
                            principalColumn: "AddressId",
                            onDelete: ReferentialAction.Restrict);
                    });

                migrationBuilder.CreateTable(
                    name: "Seats",
                    columns: table => new
                    {
                        SeatId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        RowNumber = table.Column<int>(type: "int", nullable: false),
                        SeatNumber = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                        TheaterHallId = table.Column<int>(type: "int", nullable: false),
                        TicketId = table.Column<int>(type: "int", nullable: true)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Seats", x => x.SeatId);
                        table.ForeignKey(
                            name: "FK_Seats_TheaterHalls_TheaterHallId",
                            column: x => x.TheaterHallId,
                            principalTable: "TheaterHalls",
                            principalColumn: "TheaterHallId",
                            onDelete: ReferentialAction.Restrict);
                    });

                migrationBuilder.CreateTable(
                    name: "Showtimes",
                    columns: table => new
                    {
                        ShowtimeId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ShowtimeDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                        MovieId = table.Column<int>(type: "int", nullable: false),
                        TheaterHallId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Showtimes", x => x.ShowtimeId);
                        table.ForeignKey(
                            name: "FK_Showtimes_Movies_MovieId",
                            column: x => x.MovieId,
                            principalTable: "Movies",
                            principalColumn: "MovieId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_Showtimes_TheaterHalls_TheaterHallId",
                            column: x => x.TheaterHallId,
                            principalTable: "TheaterHalls",
                            principalColumn: "TheaterHallId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(

                    name: "Reviews",
                    columns: table => new
                    {
                        ReviewId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        MovieId = table.Column<int>(type: "int", nullable: false),
                        UserId = table.Column<int>(type: "int", nullable: false),
                        Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                        Rating = table.Column<decimal>(type: "decimal(3,1)", precision: 3, scale: 1, nullable: false),
                        ReviewDate = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETDATE()")
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Reviews", x => x.ReviewId);
                        table.ForeignKey(
                            name: "FK_Reviews_Movies_MovieId",
                            column: x => x.MovieId,
                            principalTable: "Movies",
                            principalColumn: "MovieId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_Reviews_Users_UserId",
                            column: x => x.UserId,
                            principalTable: "Users",
                            principalColumn: "UserId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "UserRoles",
                    columns: table => new
                    {
                        RolesRoleId = table.Column<int>(type: "int", nullable: false),
                        UsersUserId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_UserRoles", x => new { x.RolesRoleId, x.UsersUserId });
                        table.ForeignKey(
                            name: "FK_UserRoles_Roles_RolesRoleId",
                            column: x => x.RolesRoleId,
                            principalTable: "Roles",
                            principalColumn: "RoleId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_UserRoles_Users_UsersUserId",
                            column: x => x.UsersUserId,
                            principalTable: "Users",
                            principalColumn: "UserId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateTable(
                    name: "Tickets",
                    columns: table => new
                    {
                        TicketId = table.Column<int>(type: "int", nullable: false)
                            .Annotation("SqlServer:Identity", "1, 1"),
                        ShowtimeId = table.Column<int>(type: "int", nullable: false),
                        UserId = table.Column<int>(type: "int", nullable: false),
                        Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                        IsBooked = table.Column<bool>(type: "bit", nullable: false),
                        SeatId = table.Column<int>(type: "int", nullable: false)
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Tickets", x => x.TicketId);
                        table.ForeignKey(
                            name: "FK_Tickets_Seats_SeatId",
                            column: x => x.SeatId,
                            principalTable: "Seats",
                            principalColumn: "SeatId",
                            onDelete: ReferentialAction.Restrict);
                        table.ForeignKey(
                            name: "FK_Tickets_Showtimes_ShowtimeId",
                            column: x => x.ShowtimeId,
                            principalTable: "Showtimes",
                            principalColumn: "ShowtimeId",
                            onDelete: ReferentialAction.Cascade);
                        table.ForeignKey(
                            name: "FK_Tickets_Users_UserId",
                            column: x => x.UserId,
                            principalTable: "Users",
                            principalColumn: "UserId",
                            onDelete: ReferentialAction.Cascade);
                    });

                migrationBuilder.CreateIndex(
                    name: "IX_Addresses_PostalCodeId",
                    table: "Addresses",
                    column: "PostalCodeId");

                migrationBuilder.CreateIndex(
                    name: "IX_MovieGenres_MoviesMovieId",
                    table: "MovieGenres",
                    column: "MoviesMovieId");

                migrationBuilder.CreateIndex(
                    name: "IX_Reviews_MovieId",
                    table: "Reviews",
                    column: "MovieId");

                migrationBuilder.CreateIndex(
                    name: "IX_Reviews_UserId",
                    table: "Reviews",
                    column: "UserId");

                migrationBuilder.CreateIndex(
                    name: "IX_Seats_TheaterHallId",
                    table: "Seats",
                    column: "TheaterHallId");

                migrationBuilder.CreateIndex(
                    name: "IX_Showtimes_MovieId",
                    table: "Showtimes",
                    column: "MovieId");

                migrationBuilder.CreateIndex(
                    name: "IX_Showtimes_TheaterHallId",
                    table: "Showtimes",
                    column: "TheaterHallId");

                migrationBuilder.CreateIndex(
                    name: "IX_TheaterHalls_AddressId",
                    table: "TheaterHalls",
                    column: "AddressId");

                migrationBuilder.CreateIndex(
                    name: "IX_Tickets_SeatId",
                    table: "Tickets",
                    column: "SeatId",
                    unique: true);

                migrationBuilder.CreateIndex(
                    name: "IX_Tickets_ShowtimeId",
                    table: "Tickets",
                    column: "ShowtimeId");

                migrationBuilder.CreateIndex(
                    name: "IX_Tickets_UserId",
                    table: "Tickets",
                    column: "UserId");

                migrationBuilder.CreateIndex(
                    name: "IX_UserRoles_UsersUserId",
                    table: "UserRoles",
                    column: "UsersUserId");

                migrationBuilder.CreateIndex(
                    name: "IX_Users_AddressId",
                    table: "Users",
                    column: "AddressId");
            }
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Drop the foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenresGenreId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Movies_MoviesMovieId",
                table: "MovieGenres");

            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_PostalCodes_PostalCodeId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Seats_TheaterHalls_TheaterHallId",
                table: "Seats");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_Movies_MovieId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Showtimes_TheaterHalls_TheaterHallId",
                table: "Showtimes");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Addresses_AddressId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Movies_MovieId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Reviews_Users_UserId",
                table: "Reviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Seats_SeatId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Showtimes_ShowtimeId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_Tickets_Users_UserId",
                table: "Tickets");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Roles_RolesRoleId",
                table: "UserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserRoles_Users_UsersUserId",
                table: "UserRoles");

            // Drop the foreign key constraints
            migrationBuilder.DropForeignKey(
                name: "FK_MovieGenres_Genres_GenresGenreId",
                table: "MovieGenres");

            migrationBuilder.DropTable(
                name: "MovieGenres");

            migrationBuilder.DropTable(
                name: "Reviews");

            migrationBuilder.DropTable(
                name: "Tickets");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Genres");

            migrationBuilder.DropTable(
                name: "Seats");

            migrationBuilder.DropTable(
                name: "Showtimes");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "TheaterHalls");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "PostalCodes");
        }
    }
}
