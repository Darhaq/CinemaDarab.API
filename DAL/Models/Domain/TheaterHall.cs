using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class TheaterHall
    {
        public int TheaterHallId { get; set; }
        public string Name { get; set; } = String.Empty;
        public int AddressId { get; set; }
        public Address Address { get; set; } = null!;
        public int Capacity { get; set; }
        public List<Showtime> Showtimes { get; set; } = new List<Showtime>();
    }
}
