using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace DAL.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<PostalCode > PostalCodes { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Showtime> Showtimes { get; set; }
        public DbSet<TheaterHall> TheaterHalls { get; set; }
        public DbSet<Seat> Seats { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // USER
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.FirstName)
                      .HasMaxLength(50);
                entity.Property(e => e.LastName)
                      .HasMaxLength(50);
                entity.Property(e => e.Email)
                      .HasMaxLength(100);
                entity.Property(e => e.CreateDate)
                      .HasDefaultValueSql("GETDATE()");
                

                // Configure User-Role many-to-many relationship
                entity.HasMany(u => u.Roles)
                      .WithMany(r => r.Users)
                      .UsingEntity(j => j.ToTable("UserRoles"));

                entity.HasOne(u => u.Address)
                      .WithMany(a => a.Users)
                      .HasForeignKey(u => u.AddressId)
                      .OnDelete(DeleteBehavior.Restrict); // One-to-many
            });

            // POSTALCODE
            modelBuilder.Entity<PostalCode>(entity =>
            {
                entity.Property(e => e.PostalCodeId)
                      .ValueGeneratedNever();
            });

            // MOVIE
            modelBuilder.Entity<Movie>(entity =>
            {
                entity.Property(e => e.Rating)
                      .HasPrecision(3, 1);

                // Configure Movie-Genre many-to-many relationship
                entity.HasMany(m => m.Genres)
                      .WithMany(g => g.Movies)
                      .UsingEntity(j => j.ToTable("MovieGenres"));
            });

            // REVIEW
            modelBuilder.Entity<Review>(entity =>
            {
                entity.Property(e => e.Rating)
                      .HasPrecision(3, 1);
                entity.Property(e => e.ReviewDate)
                      .HasDefaultValueSql("GETDATE()");

                entity.HasOne(r => r.Movie)
                      .WithMany(m => m.Reviews)
                      .HasForeignKey(r => r.MovieId); // One-to-many

                entity.HasOne(r => r.User)
                      .WithMany(u => u.Reviews)
                      .HasForeignKey(r => r.UserId); // One-to-many
            });

            // TICKET
            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.Property(e => e.Price)
                      .HasColumnType("decimal(10, 2)");
            });

            // THEATERHALL
            modelBuilder.Entity<TheaterHall>(entity =>
            {
                entity.Property(e => e.Name)
                      .HasMaxLength(100);
            });

            // ADDRESS
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.Street)
                      .HasMaxLength(200);
                entity.Property(e => e.City)
                      .HasMaxLength(100);
                entity.Property(e => e.Country)
                      .HasMaxLength(100);

                entity.HasMany(a => a.Users)
                      .WithOne(u => u.Address)
                      .HasForeignKey(u => u.AddressId)
                      .OnDelete(DeleteBehavior.Restrict); // One-to-many
            });

            // ROLE
            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.RoleName)
                      .HasMaxLength(50);
            });

            // SEAT
            modelBuilder.Entity<Seat>(entity =>
            {
                entity.Property(e => e.SeatNumber)
                      .HasMaxLength(10); // Eksempel: Maks længde for sædenummer

                // Relation: Seat -> TheaterHall (mange sæder til én theater hall)
                entity.HasOne(s => s.TheaterHall)
                      .WithMany(th => th.Seats)
                      .HasForeignKey(s => s.TheaterHallId)
                      .OnDelete(DeleteBehavior.Restrict); // One-to-many

                // Relation: Seat -> Ticket (én billet pr. sæde pr. forestilling)
                entity.HasOne(s => s.Ticket)
                      .WithOne(t => t.Seat)
                      .HasForeignKey<Ticket>(t => t.SeatId)
                      .OnDelete(DeleteBehavior.Restrict); // One-to-one
            });

            modelBuilder.SeedData();


        }
    }
}
