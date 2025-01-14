using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain;

namespace DAL.Repositories
{
    public interface ISeatRepository
    {
        Task<List<Seat>> GetAllAsync();
        Task<Seat?> GetByIdAsync(int id);
        Task<Seat> CreateAsync(Seat seat);
        Task<Seat?> UpdateAsync(int id, Seat seat);
        Task<Seat?> DeleteAsync(int id);
    }
}
