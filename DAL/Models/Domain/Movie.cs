﻿using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Movie
    {
        public int MovieId { get; set; }
        public string Title { get; set; } = String.Empty;
        public int DurationMinutes { get; set; }
        public decimal Rating { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<Genre> Genres { get; set; } = new List<Genre>();

    }
}
