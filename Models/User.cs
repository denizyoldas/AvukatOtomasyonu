using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Adress { get; set; }
        public int District { get; set; }
        public int Province { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}