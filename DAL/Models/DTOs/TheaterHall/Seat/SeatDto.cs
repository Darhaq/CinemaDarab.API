using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.TheaterHall.Seat
{
    public class SeatDto
    {
        public int Id { get; set; }
        public string Row { get; set; }
        public int SeatNumber { get; set; }
        public int TheaterHallId { get; set; }
    }
}
