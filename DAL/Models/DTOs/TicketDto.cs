using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class TicketDto
    {
        public int TicketId { get; set; }
        public int ShowtimeId { get; set; }
        public int UserId { get; set; } 
        public decimal Price { get; set; }
        public bool IsBooked { get; set; }
    }
}
