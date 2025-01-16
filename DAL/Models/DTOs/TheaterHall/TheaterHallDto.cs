﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.TheaterHall
{
    public class TheaterHallDto
    {
        public int TheaterHallId { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        public int Capacity { get; set; }
    }
}