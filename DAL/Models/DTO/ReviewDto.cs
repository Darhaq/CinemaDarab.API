using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTO
{
    public class ReviewDto
    {
        public int ReviewId { get; set; }
        public int MovieId { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Content { get; set; } = string.Empty;
        public decimal Rating { get; set; }
        public DateTime ReviewDate { get; set; }

    }
}
