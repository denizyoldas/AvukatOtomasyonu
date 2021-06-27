using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvukatOtomasyonu.Models
{
    public class Login
    {
        [Display(Name = "email")]
        public string email { get; set; }
        [Display(Name = "şifre")]
        public string password { get; set; }
    }
}