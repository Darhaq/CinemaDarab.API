﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.Review
{
    public class UpdateReviewDto
    {
        public string Comment { get; set; }
        public int Rating { get; set; }
    }
}
