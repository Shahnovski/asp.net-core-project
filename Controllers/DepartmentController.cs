using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using University.Models;

namespace University.Views.Home
{
    public class DepartmentController : Controller
    {
        private readonly UniversityContext db;
        public DepartmentController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult viewDepartment(int departmentId)
        {
            Department department = db.Departments.Include(p => p.StaffingStructures).Include(p => p.Specialties).Include(p => p.HeadOfDepartment).FirstOrDefault(p => p.Id == departmentId);
            department.StaffingStructures = db.StaffingStructures.Include(p => p.Teacher).Where(p => p.DepartmentId == departmentId).OrderBy(p => p.Teacher.LastName).ToList();
            return View(department);
        }
    }
}