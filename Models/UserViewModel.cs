using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvukatOtomasyonu.Models
{
    public class UserViewModel
    {
        public IEnumerable<District> districts { get; set; }
        public IEnumerable<Province> provinces { get; set; }
        public User user { get; set; }
    }
}