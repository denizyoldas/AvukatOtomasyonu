using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class HomeViewModel
    {
        public IEnumerable<Province> Provinces { get; set; }
        public IEnumerable<District> Districts{ get; set; }
        public IEnumerable<Category> Categories { get; set; }
    }
}