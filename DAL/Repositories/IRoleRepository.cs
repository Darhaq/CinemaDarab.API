using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models.Domain;

namespace DAL.Repositories
{
    public interface IRoleRepository
    {
        // Henter alle roller
        Task<List<Role>> GetAllAsync();

        // Henter en rolle baseret på ID
        Task<Role?> GetByIdAsync(int id);

        // Opretter en ny rolle
        Task<Role> CreateAsync(Role role);

        // Opdaterer en eksisterende rolle
        Task<Role?> UpdateAsync(int id, Role updatedRole);

        // Sletter en rolle baseret på ID
        Task<Role?> DeleteAsync(int id);
    }
}
