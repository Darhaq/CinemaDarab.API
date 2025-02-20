using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.DTOs.User
{
    public class AddUserRequestDto
    {
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string Password { get; set; }
        public int PostalCodeId { get; set; }
        public int RoleId { get; set; }
        public int AddressId { get; set; }
    }
}
