using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Showtime
    {
        public int ShowtimeId { get; set; }
        public DateTime ShowtimeDateTime { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int TheaterHallId { get; set; }
        public TheaterHall TheaterHall { get; set; } = null!;
        public List<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
