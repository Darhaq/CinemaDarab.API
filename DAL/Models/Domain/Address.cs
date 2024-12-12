using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models.Domain
{
    public class Address
    {
        public int AddressId { get; set; }
        public string Street { get; set; } = String.Empty;
        public string City { get; set; } = String.Empty;
        public int PostalCodeId { get; set; }
        public string Country { get; set; } = String.Empty;
        public PostalCode PostalCode { get; set; } = null!;
        public List<User> Users { get; set; } = new List<User>();
    }
}
