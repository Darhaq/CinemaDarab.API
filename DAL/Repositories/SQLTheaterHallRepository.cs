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
    public class SQLTheaterHallRepository : ITheaterHallRepository
    {
        private readonly MyDbContext dbContext;

        public SQLTheaterHallRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<TheaterHall>> GetAllAsync()
        {
            return await dbContext.TheaterHalls.ToListAsync(); 
        }

        public async Task<TheaterHall?> GetByIdAsync(int id)
        {
            return await dbContext.TheaterHalls.FirstOrDefaultAsync(th => th.TheaterHallId == id);
        }

        public async Task<TheaterHall> CreateAsync(TheaterHall theaterHall)
        {
            await dbContext.TheaterHalls.AddAsync(theaterHall);
            await dbContext.SaveChangesAsync();
            return theaterHall;
        }

        public async Task<TheaterHall?> UpdateAsync(int id, TheaterHall theaterHall)
        {
            var existingHall = await dbContext.TheaterHalls.FirstOrDefaultAsync(th => th.TheaterHallId == id);
            if (existingHall == null) return null;

            existingHall.Name = theaterHall.Name;
            existingHall.Capacity = theaterHall.Capacity;

            await dbContext.SaveChangesAsync();
            return existingHall;
        }

        public async Task<TheaterHall?> DeleteAsync(int id)
        {
            var existingHall = await dbContext.TheaterHalls.FirstOrDefaultAsync(th => th.TheaterHallId == id);
            if (existingHall == null) return null;

            dbContext.TheaterHalls.Remove(existingHall);
            await dbContext.SaveChangesAsync();
            return existingHall;
        }
    }
}
