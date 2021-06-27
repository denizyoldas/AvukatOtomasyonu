using AvukatOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvukatOtomasyonu.Controllers
{
    public class BackApiController : Controller
    {
        public AvukatContext db = new AvukatContext();

        // GET: BackApi
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult getDistricById(int provinceId)
        {
            var list = db.Districts.Where(d => d.ProvinceId == provinceId).ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}