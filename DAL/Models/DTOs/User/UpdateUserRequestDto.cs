using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.User
{
    public class UpdateUserRequestDto
    {
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;   // NULL! ER "null forgiving operator".
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public DateTime CreateDate { get; set; }
        public int PostalCodeId { get; set; }
    }
}
