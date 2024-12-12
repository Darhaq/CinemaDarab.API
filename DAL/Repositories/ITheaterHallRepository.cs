using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain;

namespace DAL.Repositories
{
    public interface ITheaterHallRepository
    {
        Task<List<TheaterHall>> GetAllAsync();
        Task<TheaterHall?> GetByIdAsync(int id);
        Task<TheaterHall> CreateAsync(TheaterHall theaterHall);
        Task<TheaterHall?> UpdateAsync(int id, TheaterHall theaterHall);
        Task<TheaterHall?> DeleteAsync(int id);
    }
}
