using AvukatOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvukatOtomasyonu.Controllers
{
    public class AdminController : Controller
    {
        public AvukatContext db = new AvukatContext();
        // GET: Admin
        public ActionResult Index()
        {
            if (UserControl())
                return RedirectToAction("Login");

            IEnumerable<Case> objects = db.Cases;

            var cases = (from c in db.Cases
                         join cg in db.Categories on c.CategoryId equals cg.Id
                         join p in db.Provinces on c.ProvinceId equals p.Id
                         join d in db.Districts on c.DistrictId equals d.Id
                         select new CaseDTO() {
                             Id = c.Id,
                             Name = c.UserName,
                             Surname = c.UserSurname,
                             CategoryName = cg.Name,
                             ProvinceName = p.Name,
                             DisctrictName = d.Name,
                         }).ToList();

            ViewBag.categoryCount = db.Categories.Count();
            ViewBag.userCount = db.Users.Count();
            ViewBag.caseCount = db.Cases.Count();

            return View(cases);
        }

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // POST: Login
        [HttpPost]
        public ActionResult Login(Login data)
        {
            if (!UserControl())
                return RedirectToAction("Index");
            var user = db.Users.Where(u => u.Email == data.email && u.Password == data.password).FirstOrDefault();
            if (user == null)
            {
                return View();
            }

            Session.Add("user", user);
            return RedirectToAction("Index");
        }

        public ActionResult Category(Boolean success = false)
        {
            if (UserControl())
                return RedirectToAction("Login");
            ViewBag.success = success;
            IEnumerable < Category > obj = db.Categories;
            return View(obj);
        }

        public RedirectToRouteResult Logout()
        {
            Session.RemoveAll();
            return RedirectToAction("Login");
        }

        public ActionResult AddCategory()
        {
            if (UserControl())
                return RedirectToAction("Login");
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category value)
        {
            if (UserControl())
                return RedirectToAction("Login");
            if (value.Name != null && value.Description != null)
            {
                db.Categories.Add(value);
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }

        public ActionResult EditCategory(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            Category category = db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
            if (category == null)
            {
                return RedirectToAction("Category");
            }
            return View(category);
        }

        [HttpPost]
        public ActionResult EditCategory(Category value)
        {
            if (UserControl())
                return RedirectToAction("Login");
            if (value.Name != null && value.Description != null)
            {
                Category category = db.Categories.Where(cat => cat.Id == value.Id).FirstOrDefault();
                category.Name = value.Name;
                category.Description = value.Description;
                db.SaveChanges();
            }
            return RedirectToAction("Category");
        }

        public ActionResult DeleteCategory(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            Category category = db.Categories.Where(cat => cat.Id == id).FirstOrDefault();
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Category", new { success = true });
        }

        public ActionResult User()
        {
            if (UserControl())
                return RedirectToAction("Login");

            IEnumerable<User> users = db.Users;
            return View(users);
        }

        public ActionResult AddUser()
        {
            if(UserControl())
                return RedirectToAction("Login");
            UserViewModel vm = new UserViewModel();

            vm.districts = db.Districts.ToList();
            vm.provinces = db.Provinces.ToList();

            return View(vm);
        }

        [HttpPost]
        public ActionResult AddUser(User value)
        {
            if (UserControl())
                return RedirectToAction("Login");
            value.Province = Convert.ToInt32(value.Province);
            value.District = Convert.ToInt32(value.District);
            db.Users.Add(value);
            db.SaveChanges();
            return RedirectToAction("User");
        }

        public ActionResult DeleteUser(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            User data = db.Users.Where(user => user.Id == id).FirstOrDefault();
            db.Users.Remove(data);
            db.SaveChanges();
            return RedirectToAction("User", new { success = true });
        }

        public ActionResult UpdateUser(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            User user = db.Users.Where(cat => cat.Id == id).FirstOrDefault();
            if (user == null)
            {
                return RedirectToAction("User");
            }

            UserViewModel vm = new UserViewModel();

            vm.districts = db.Districts.ToList();
            vm.provinces = db.Provinces.ToList();
            vm.user = user;

            return View(vm);
        }

        [HttpPost]
        public ActionResult UpdateUser(User value)
        {
            if (UserControl())
                return RedirectToAction("Login");
            User user = db.Users.Where(cat => cat.Id == value.Id).FirstOrDefault();

            user.Name = value.Name;
            user.Surname = value.Surname;
            user.Email = value.Email;
            user.PhoneNumber = value.PhoneNumber;
            user.Password = value.Password;
            user.Province = value.Province;
            user.District = value.District;

            db.SaveChanges();
            return RedirectToAction("User");
        }

        public ActionResult Case()
        {
            if (UserControl())
                return RedirectToAction("Login");
            IEnumerable<Case> objects = db.Cases;

            var cases = (from c in db.Cases
                         join cg in db.Categories on c.CategoryId equals cg.Id
                         join p in db.Provinces on c.ProvinceId equals p.Id
                         join d in db.Districts on c.DistrictId equals d.Id
                         select new CaseDTO()
                         {
                             Id = c.Id,
                             Name = c.UserName,
                             Surname = c.UserSurname,
                             CategoryName = cg.Name,
                             ProvinceName = p.Name,
                             DisctrictName = d.Name,
                         }).ToList();

            return View(cases);
        }

        public ActionResult DeleteCase(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            Case data = db.Cases.Where(c => c.Id == id).FirstOrDefault();
            db.Cases.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Case");
        }

        public ActionResult Appointment()
        {
            if (UserControl())
                return RedirectToAction("Login");
            var appo = (from a in db.Appointments
                         join c in db.Cases on a.CaseId equals c.Id
                         join cg in db.Categories on c.CategoryId equals cg.Id
                         select new AppointmentDTO()
                         {
                             Id = c.Id,
                             UserName = c.UserName + " " + c.UserSurname,
                             CategoryName = cg.Name,
                             StartDate = a.StartDate,
                             EndDate = a.EndDate
                         }).ToList();

            return View(appo);
        }

        public ActionResult AddAppointment()
        {
            if (UserControl())
                return RedirectToAction("Login");
            IEnumerable<Case> cas = db.Cases.ToList();
            return View(cas);
        }


        [HttpPost]
        public ActionResult AddAppointment(Appointment value)
        {
            if (UserControl())
                return RedirectToAction("Login");
            Appointment ap = new Appointment();
            ap.CaseId = 1;
            ap.StartDate = value.StartDate;
            ap.EndDate = value.EndDate;
            ap.Status = 1;
            db.Appointments.Add(ap);
            db.SaveChanges();
            return RedirectToAction("Appointment");
        }


        public ActionResult DeleteAppointment(int id)
        {
            if (UserControl())
                return RedirectToAction("Login");
            Appointment ap = db.Appointments.Where(a => a.Id == id).FirstOrDefault();
            db.Appointments.Remove(ap);
            db.SaveChanges();
            return RedirectToAction("Appointment");
        }

        public Boolean UserControl()
        {
            if(Session["user"] == null)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}