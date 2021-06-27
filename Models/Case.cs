using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class Case
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string Email { get; set; }
        public string message { get; set; }
    }
}