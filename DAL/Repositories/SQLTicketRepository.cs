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
    public class SQLTicketRepository : ITicketRepository
    {
            private readonly MyDbContext dbContext;

            public SQLTicketRepository(MyDbContext dbContext)
            {
                this.dbContext = dbContext;
            }

            public async Task<List<Ticket>> GetAllAsync()
            {
                return await dbContext.Tickets.ToListAsync();
            }

            public async Task<Ticket?> GetByIdAsync(int id)
            {
                return await dbContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
            }

            public async Task<Ticket> CreateAsync(Ticket ticket)
            {
                await dbContext.Tickets.AddAsync(ticket);
                await dbContext.SaveChangesAsync();
                return ticket;
            }

            public async Task<Ticket?> UpdateAsync(int id, Ticket ticket)
            {
                var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
                if (existingTicket == null) return null;

                existingTicket.Price = ticket.Price;
                existingTicket.ShowtimeId = ticket.ShowtimeId;
                existingTicket.UserId = ticket.UserId;

                await dbContext.SaveChangesAsync();
                return existingTicket;
            }

            public async Task<Ticket?> DeleteAsync(int id)
            {
                var existingTicket = await dbContext.Tickets.FirstOrDefaultAsync(t => t.TicketId == id);
                if (existingTicket == null) return null;

                dbContext.Tickets.Remove(existingTicket);
                await dbContext.SaveChangesAsync();
                return existingTicket;
            }
    }
}