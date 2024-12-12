using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain;

namespace DAL.Repositories
{
    public interface IShowtimeRepository
    {
        Task<List<Showtime>> GetAllAsync();
        Task<Showtime?> GetByIdAsync(int id);
        Task<Showtime> CreateAsync(Showtime showtime);
        Task<Showtime?> UpdateAsync(int id, Showtime showtime);
        Task<Showtime?> DeleteAsync(int id);
    }
}
