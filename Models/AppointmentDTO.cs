using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class AppointmentDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string CategoryName { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}