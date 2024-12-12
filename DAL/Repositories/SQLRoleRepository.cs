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
    public class SQLRoleRepository : IRoleRepository
    {
        private readonly MyDbContext dbContext;

        public SQLRoleRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Role>> GetAllAsync()
        {
            return await dbContext.Roles.ToListAsync();
        }

        public async Task<Role?> GetByIdAsync(int id)
        {
            return await dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
        }

        public async Task<Role> CreateAsync(Role role)
        {
            await dbContext.Roles.AddAsync(role);
            await dbContext.SaveChangesAsync();
            return role;
        }

        public async Task<Role?> UpdateAsync(int id, Role role)
        {
            var existingRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if (existingRole == null) return null;

            existingRole.RoleName = role.RoleName;

            await dbContext.SaveChangesAsync();
            return existingRole;
        }

        public async Task<Role?> DeleteAsync(int id)
        {
            var existingRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.RoleId == id);
            if (existingRole == null) return null;

            dbContext.Roles.Remove(existingRole);
            await dbContext.SaveChangesAsync();
            return existingRole;
        }
    }
}
