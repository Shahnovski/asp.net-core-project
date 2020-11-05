using Microsoft.AspNetCore.Mvc;

namespace University.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}