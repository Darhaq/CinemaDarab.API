using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class ShowtimeDto
    {
        public int ShowtimeId { get; set; }
        public DateTime ShowtimeDateTime { get; set; }
        public int MovieId { get; set; }
        public int TheaterHallId { get; set; }
    }
}
