using AvukatOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvukatOtomasyonu.Controllers
{
    public class HomeController : Controller
    {
        AvukatContext db = new AvukatContext();

        public ActionResult Index()
        {
            HomeViewModel hv = new HomeViewModel();

            hv.Categories = db.Categories.ToList();
            hv.Provinces = db.Provinces.ToList();
            hv.Districts = db.Districts.ToList();

            return View(hv);
        }

        [HttpPost]
        public ActionResult Index(Case value)
        {
            if(value != null)
            {
                db.Cases.Add(value);
                db.SaveChanges();
            }

            HomeViewModel hv = new HomeViewModel();

            hv.Categories = db.Categories.ToList();
            hv.Provinces = db.Provinces.ToList();
            hv.Districts = db.Districts.ToList();

            return View(hv);
        }
    }
}