using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public static class ModelBuilderExtensions
    {
        public static void SeedData(this ModelBuilder modelBuilder)
        {
            // Seed Genres
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Action" },
                new Genre { GenreId = 2, GenreName = "Comedy" },
                new Genre { GenreId = 3, GenreName = "Drama" },
                new Genre { GenreId = 4, GenreName = "Horror" },
                new Genre { GenreId = 5, GenreName = "Sci-Fi" }
            );

            // Seed Movies
            modelBuilder.Entity<Movie>().HasData(
                new Movie { MovieId = 1, Title = "Inception", DurationMinutes = 148, Rating = 8.8m, ReleaseDate = new DateTime(2010, 7, 16) },
                new Movie { MovieId = 2, Title = "The Dark Knight", DurationMinutes = 152, Rating = 9.0m, ReleaseDate = new DateTime(2008, 7, 18) },
                new Movie { MovieId = 3, Title = "The Shawshank Redemption", DurationMinutes = 142, Rating = 9.3m, ReleaseDate = new DateTime(1994, 10, 14) },
                new Movie { MovieId = 4, Title = "The Godfather", DurationMinutes = 175, Rating = 9.2m, ReleaseDate = new DateTime(1972, 3, 24) },
                new Movie { MovieId = 5, Title = "Scary Movie", DurationMinutes = 88, Rating = 6.2m, ReleaseDate = new DateTime(2000, 7, 7) }
            );

            // Seed join table for Movies and Genres
            modelBuilder.Entity<Movie>()
                .HasMany(m => m.Genres)
                .WithMany(g => g.Movies)
                .UsingEntity(j => j.HasData(
                    new { MoviesMovieId = 1, GenresGenreId = 1 },
                    new { MoviesMovieId = 1, GenresGenreId = 5 },
                    new { MoviesMovieId = 2, GenresGenreId = 1 },
                    new { MoviesMovieId = 2, GenresGenreId = 3 },
                    new { MoviesMovieId = 3, GenresGenreId = 3 },
                    new { MoviesMovieId = 4, GenresGenreId = 3 },
                    new { MoviesMovieId = 5, GenresGenreId = 4 },
                    new { MoviesMovieId = 5, GenresGenreId = 2 }
                ));

            // Seed TheaterHalls
            modelBuilder.Entity<TheaterHall>().HasData(
                new TheaterHall { TheaterHallId = 1, Name = "Main Hall", Capacity = 150 },
                new TheaterHall { TheaterHallId = 2, Name = "Second Hall", Capacity = 100 },
                new TheaterHall { TheaterHallId = 3, Name = "Small Hall", Capacity = 50 },
                new TheaterHall { TheaterHallId = 4, Name = "VIP Hall", Capacity = 20 }
            );

            // Seed Seats
            modelBuilder.Entity<Seat>().HasData(
                // Seats for Main Hall
                new Seat { SeatId = 1, Row = "A", SeatNumber = 1, TheaterHallId = 1 },
                new Seat { SeatId = 2, Row = "A", SeatNumber = 2, TheaterHallId = 1 },
                new Seat { SeatId = 3, Row = "A", SeatNumber = 3, TheaterHallId = 1 },
                new Seat { SeatId = 4, Row = "A", SeatNumber = 4, TheaterHallId = 1 },
                new Seat { SeatId = 5, Row = "A", SeatNumber = 5, TheaterHallId = 1 },
                new Seat { SeatId = 6, Row = "A", SeatNumber = 6, TheaterHallId = 1 },

                // Seats for Second Hall
                new Seat { SeatId = 7, Row = "B", SeatNumber = 1, TheaterHallId = 2 },
                new Seat { SeatId = 8, Row = "B", SeatNumber = 2, TheaterHallId = 2 },
                new Seat { SeatId = 9, Row = "B", SeatNumber = 3, TheaterHallId = 2 },
                new Seat { SeatId = 10, Row = "B", SeatNumber = 4, TheaterHallId = 2 },
                new Seat { SeatId = 11, Row = "B", SeatNumber = 5, TheaterHallId = 2 },

                // Seats for Small Hall
                new Seat { SeatId = 12, Row = "C", SeatNumber = 1, TheaterHallId = 3 },
                new Seat { SeatId = 13, Row = "C", SeatNumber = 2, TheaterHallId = 3 },
                new Seat { SeatId = 14, Row = "C", SeatNumber = 3, TheaterHallId = 3 },
                new Seat { SeatId = 15, Row = "C", SeatNumber = 4, TheaterHallId = 3 },

                // Seats for VIP Hall
                new Seat { SeatId = 16, Row = "VP", SeatNumber = 1, TheaterHallId = 4 },
                new Seat { SeatId = 17, Row = "VP", SeatNumber = 2, TheaterHallId = 4 },
                new Seat { SeatId = 18, Row = "VP", SeatNumber = 3, TheaterHallId = 4 }
            );

            // Seed Roles
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "Customer" }
            );

            // Seed PostalCodes
            modelBuilder.Entity<PostalCode>().HasData(
                new PostalCode { PostalCodeId = 1, Name = "12345" },
                new PostalCode { PostalCodeId = 2, Name = "67890" },
                new PostalCode { PostalCodeId = 3, Name = "13579" }
            );

            // Seed Addresses
            modelBuilder.Entity<Address>().HasData(
                new Address { AddressId = 1, Street = "123 Main St", City = "Odense", PostalCodeId = 1, Country = "Denmark" },
                new Address { AddressId = 2, Street = "456 Elm St", City = "Copenhagen", PostalCodeId = 2, Country = "Denmark" },
                new Address { AddressId = 3, Street = "789 Oak St", City = "Aarhus", PostalCodeId = 3, Country = "Denmark" }
            );

            // Seed Users
            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PasswordHash = "hashedpassword", CreateDate = DateTime.Now, AddressId = 1, RoleId = 1 },
                new User { UserId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PasswordHash = "hashedpassword2", CreateDate = DateTime.Now, AddressId = 2, RoleId = 2 },
                new User { UserId = 3, FirstName = "Alice", LastName = "Johnson", Email = "alice.johnson@example.com", PasswordHash = "hashedpassword3", CreateDate = DateTime.Now, AddressId = 3, RoleId = 2 }
            );

            // Seed Showtimes
            modelBuilder.Entity<Showtime>().HasData(
                new Showtime { ShowtimeId = 1, ShowtimeDateTime = new DateTime(2025, 10, 1, 19, 0, 0), MovieId = 1, TheaterHallId = 1 },
                new Showtime { ShowtimeId = 2, ShowtimeDateTime = new DateTime(2025, 10, 1, 21, 0, 0), MovieId = 2, TheaterHallId = 1 },
                new Showtime { ShowtimeId = 3, ShowtimeDateTime = new DateTime(2025, 10, 2, 19, 0, 0), MovieId = 3, TheaterHallId = 3 },
                new Showtime { ShowtimeId = 4, ShowtimeDateTime = new DateTime(2025, 10, 2, 21, 0, 0), MovieId = 4, TheaterHallId = 4 },
                new Showtime { ShowtimeId = 5, ShowtimeDateTime = new DateTime(2025, 10, 3, 19, 0, 0), MovieId = 5, TheaterHallId = 2 }
            ); 

            // Seed Reviews
            modelBuilder.Entity<Review>().HasData(
                new Review { ReviewId = 1, MovieId = 1, UserId = 1, Content = "Very confusing but great movie!", Rating = 8.8m, ReviewDate = DateTime.Now },
                new Review { ReviewId = 2, MovieId = 2, UserId = 2, Content = "Heath Ledger was amazing!", Rating = 9.0m, ReviewDate = DateTime.Now },
                new Review { ReviewId = 3, MovieId = 3, UserId = 3, Content = "One of the best movies of all time!", Rating = 9.3m, ReviewDate = DateTime.Now }
            );

            // Seed Tickets
            modelBuilder.Entity<Ticket>().HasData(
                new Ticket { TicketId = 1, ShowtimeId = 1, UserId = 1 },
                new Ticket { TicketId = 2, ShowtimeId = 3, UserId = 2 },
                new Ticket { TicketId = 3, ShowtimeId = 5, UserId = 3 }
            );
        }
    }
}
