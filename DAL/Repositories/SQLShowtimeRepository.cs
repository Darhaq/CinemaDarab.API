using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Data;
using DAL.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories
{
    public class SQLShowtimeRepository : IShowtimeRepository
    {
        private readonly MyDbContext dbContext;

        public SQLShowtimeRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Showtime>> GetAllAsync()
        {
            return await dbContext.Showtimes
                .Include(st => st.Movie)
                .Include(st => st.TheaterHall)
                .ToListAsync();
        }

        public async Task<Showtime?> GetByIdAsync(int id)
        {
            return await dbContext.Showtimes
                .Include(st => st.Movie)
                .Include(st => st.TheaterHall)
                .FirstOrDefaultAsync(st => st.ShowtimeId == id);
        }

        public async Task<Showtime> CreateAsync(Showtime showtime)
        {
            await dbContext.Showtimes.AddAsync(showtime);
            await dbContext.SaveChangesAsync();
            return showtime;
        }

        public async Task<Showtime?> UpdateAsync(int id, Showtime showtime)
        {
            var existingShowtime = await dbContext.Showtimes.FirstOrDefaultAsync(st => st.ShowtimeId == id);
            if (existingShowtime == null) return null;

            existingShowtime.MovieId = showtime.MovieId;
            existingShowtime.TheaterHallId = showtime.TheaterHallId;
            existingShowtime.ShowtimeDateTime = showtime.ShowtimeDateTime;

            await dbContext.SaveChangesAsync();
            return existingShowtime;
        }

        public async Task<Showtime?> DeleteAsync(int id)
        {
            var existingShowtime = await dbContext.Showtimes.FirstOrDefaultAsync(st => st.ShowtimeId == id);
            if (existingShowtime == null) return null;

            dbContext.Showtimes.Remove(existingShowtime);
            await dbContext.SaveChangesAsync();
            return existingShowtime;
        }
    }
}
