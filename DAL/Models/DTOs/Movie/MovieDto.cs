using DAL.Models.Domain;
using DAL.Models.DTOs.Genre;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.Movie
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string Title { get; set; }
        public int DurationMinutes { get; set; }
        public string Description { get; set; }
        public DateTime ReleaseDate { get; set; }
        public List<GenreDto> Genres { get; set; } = new List<GenreDto>();

        //public List<Genre> Genres { get; set; } = new List<Genre>();
    }
}
