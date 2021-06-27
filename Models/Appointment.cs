using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public int CaseId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int Status { get; set; }
    }
}