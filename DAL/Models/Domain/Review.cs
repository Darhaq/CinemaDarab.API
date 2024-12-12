using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Review
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; } = null!;
        public int UserId { get; set; } 
        public User User { get; set; } = null!;   
        public string Content { get; set; } = String.Empty;
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; }
    }
}
