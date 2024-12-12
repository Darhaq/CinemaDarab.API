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
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly MyDbContext dbContext;

        public SQLAddressRepository(MyDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<Address>> GetAllAsync()
        {
            return await dbContext.Addresses
                .Include(a => a.PostalCodeId)
                .ToListAsync();
        }

        public async Task<Address?> GetByIdAsync(int id)
        {
            return await dbContext.Addresses
                .Include(a => a.PostalCodeId)
                .FirstOrDefaultAsync(a => a.AddressId == id);
        }

        public async Task<Address> CreateAsync(Address address)
        {
            await dbContext.Addresses.AddAsync(address);
            await dbContext.SaveChangesAsync();
            return address;
        }

        public async Task<Address?> UpdateAsync(int id, Address address)
        {
            var existingAddress = await dbContext.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
            if (existingAddress == null) return null;

            existingAddress.Street = address.Street;
            existingAddress.City = address.City;
            existingAddress.PostalCodeId = address.PostalCodeId;

            await dbContext.SaveChangesAsync();
            return existingAddress;
        }

        public async Task<Address?> DeleteAsync(int id)
        {
            var existingAddress = await dbContext.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
            if (existingAddress == null) return null;

            dbContext.Addresses.Remove(existingAddress);
            await dbContext.SaveChangesAsync();
            return existingAddress;
        }
    }
}
