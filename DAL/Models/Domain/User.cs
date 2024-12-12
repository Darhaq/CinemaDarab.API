﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        [Required]
        public string LastName { get; set; } = null!;
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Navigation Property
        public Address Address { get; set; }
        public int AddressId { get; set; }
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}