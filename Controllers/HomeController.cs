using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using University.Models;

namespace University.Controllers
{
    public class HomeController : Controller
    {
        private readonly UniversityContext db;
        public HomeController(UniversityContext context)
        {
            db = context;
        }
        public ActionResult Index()
        {
            IEnumerable<Department> departments = db.Departments;
            ViewBag.Departments = departments;
            return View();
        }
    }
}