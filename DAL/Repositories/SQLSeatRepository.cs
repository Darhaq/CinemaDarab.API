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
    public class SQLSeatRepository : ISeatRepository
    {
        private readonly MyDbContext dbContext;

        public SQLSeatRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Seat>> GetAllAsync()
        {
            return await dbContext.Seats.ToListAsync();
        }

        public async Task<Seat?> GetByIdAsync(int id)
        {
            return await dbContext.Seats.FirstOrDefaultAsync(s => s.SeatId == id);
        }

        public async Task<Seat> CreateAsync(Seat seat)
        {
            await dbContext.Seats.AddAsync(seat);
            await dbContext.SaveChangesAsync();
            return seat;
        }

        public async Task<Seat?> UpdateAsync(int id, Seat seat)
        {
            var existingSeat = await dbContext.Seats.FirstOrDefaultAsync(s => s.SeatId == id);
            if (existingSeat == null) return null;

            existingSeat.RowNumber = seat.RowNumber;
            existingSeat.SeatNumber = seat.SeatNumber;
            existingSeat.TheaterHallId = seat.TheaterHallId;

            await dbContext.SaveChangesAsync();
            return existingSeat;
        }

        public async Task<Seat?> DeleteAsync(int id)
        {
            var existingSeat = await dbContext.Seats.FirstOrDefaultAsync(s => s.SeatId == id);
            if (existingSeat == null) return null;

            dbContext.Seats.Remove(existingSeat);
            await dbContext.SaveChangesAsync();
            return existingSeat;
        }
    }
}
