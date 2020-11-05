using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using University.Models;

namespace University.Controllers
{
    public class SpecialtyController : Controller
    {
        private readonly UniversityContext db;
        public SpecialtyController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult viewSpecialty(int specialtyId)
        {
            Specialty specialty = db.Specialties.Include(p => p.Groups).FirstOrDefault(p => p.Id == specialtyId);
            return View(specialty);
        }
    }
}