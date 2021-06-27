using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class CaseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string CategoryName { get; set; }
        public string Message { get; set; }
        public string ProvinceName { get; set; }
        public string DisctrictName { get; set; }        
    }
}