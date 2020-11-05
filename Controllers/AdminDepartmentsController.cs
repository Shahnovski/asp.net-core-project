using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using University.Models;
using Microsoft.EntityFrameworkCore;

namespace University.Controllers
{
    public class AdminDepartmentsController : Controller
    {
        private readonly UniversityContext db;
        public AdminDepartmentsController(UniversityContext context)
        {
            db = context;
        }

        public ViewResult Index()
        {
            IEnumerable<Department> departments = db.Departments.Include(p => p.HeadOfDepartment);
            return View(departments);
        }

        public ViewResult Edit(int Id)
        {
            Department department = db.Departments.FirstOrDefault(p => p.Id == Id);
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            ViewBag.Teachers = teachers;
            return View(department);
        }

        [HttpPost]
        public ActionResult Edit(Department department)
        {
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            ViewBag.Teachers = teachers;
            if (ModelState.IsValid)
            {
                if (department.Id == 0)
                    db.Departments.Add(department);
                else
                {
                    Department dbEntry = db.Departments.Find(department.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Title = department.Title;
                        dbEntry.NumberOfCabinet = department.NumberOfCabinet;
                        dbEntry.PhoneNumber = department.PhoneNumber;
                        dbEntry.HeadOfDepartmentId = department.HeadOfDepartmentId;
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения кафедры \"{0}\" были сохранены", department.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(department);
            }
        }

        public ViewResult Create()
        {
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            ViewBag.Teachers = teachers;
            return View("Edit", new Department());
        }

        [HttpPost]
        public ActionResult Delete(int departmentId)
        {
            Department department = db.Departments.Find(departmentId);
            if (department != null)
            {
                db.Departments.Remove(department);
                db.SaveChanges();
            }
            if (department != null)
            {
                TempData["message"] = string.Format("Кафедра \"{0}\" была удалена", department.Title);
            }
            return RedirectToAction("Index");
        }
    }
}