using ClinicManagement.Core;
using ClinicManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ClinicManagement.Controllers
{
    public class HomeController : Controller
    {
       
        private ApplicationDbContext _db;
        private IUnitofWork _unit;
        public HomeController(ApplicationDbContext db,IUnitofWork unit)
        {
            _db = db;
            _unit = unit;
        }
        
        public ActionResult Index()
        {
            var data = _db.Cities.ToList();
            var docs = _unit.Doctors.GetDoctors();
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}