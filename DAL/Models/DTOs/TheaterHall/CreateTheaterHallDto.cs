using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.TheaterHall
{
    public class CreateTheaterHallDto
    {
        public string Name { get; set; }
        public int Capacity { get; set; }
    }
}
