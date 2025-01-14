using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Seat
    {
        public int SeatId { get; set; }
        public int RowNumber { get; set; }
        public int SeatNumber { get; set; }

        // Fremmednøgle til TheaterHall
        [ForeignKey("TheaterHall")]
        public int TheaterHallId { get; set; }
        public TheaterHall TheaterHall { get; set; } // Navigationsegenskab

        // Fremmednøgle til Ticket
        public int? TicketId { get; set; } // Ticket kan være valgfri
        public Ticket? Ticket { get; set; } // Navigationsegenskab
    }
}
