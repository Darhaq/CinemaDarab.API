using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int ShowtimeId { get; set; }
        public Showtime Showtime { get; set; } = null!;
        public int UserId { get; set; }
        public User User { get; set; } = null!;    
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
