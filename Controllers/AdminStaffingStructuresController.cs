using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Controllers
{
    public class AdminStaffingStructuresController : Controller
    {
        private readonly UniversityContext db;
        public AdminStaffingStructuresController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult Index()
        {
            IEnumerable<StaffingStructure> staffingStructures = db.StaffingStructures.Include(p => p.Teacher).Include(p => p.Department);
            return View(staffingStructures);
        }

        public ViewResult Edit(int TeacherId, int DepartmentId)
        {
            StaffingStructure staffingStructure = db.StaffingStructures.FirstOrDefault(p => p.TeacherId == TeacherId && p.DepartmentId == DepartmentId);
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Teachers = teachers;
            ViewBag.Departments = departments;
            return View(staffingStructure);
        }

        [HttpPost]
        public ActionResult Edit(StaffingStructure staffingStructure)
        {
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Teachers = teachers;
            ViewBag.Departments = departments;
            if (ModelState.IsValid)
            {
                if (staffingStructure.TeacherId == 0 && staffingStructure.DepartmentId == 0)
                    db.StaffingStructures.Add(staffingStructure);
                else
                {
                    StaffingStructure dbEntry = db.StaffingStructures.Find(staffingStructure.TeacherId, staffingStructure.DepartmentId);
                    if (dbEntry != null)
                    {
                        dbEntry.Post = staffingStructure.Post;
                        dbEntry.Rate = staffingStructure.Rate;
                        dbEntry.TeacherId = staffingStructure.TeacherId;
                        dbEntry.DepartmentId = staffingStructure.DepartmentId;
                    }
                    else
                    {
                        db.StaffingStructures.Add(staffingStructure);
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения в штатном расписании были сохранены");
                return RedirectToAction("Index");
            }
            else
            {
                return View(staffingStructure);
            }
        }

        public ViewResult Create()
        {
            SelectList teachers = new SelectList(db.Teachers, "Id", "LastName");
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Teachers = teachers;
            ViewBag.Departments = departments;
            return View("Edit", new StaffingStructure());
        }

        [HttpPost]
        public ActionResult Delete(int TeacherId, int DepartmentId)
        {
            StaffingStructure staffingStructure = db.StaffingStructures.Find(TeacherId, DepartmentId);
            if (staffingStructure != null)
            {
                db.StaffingStructures.Remove(staffingStructure);
                db.SaveChanges();
            }
            if (staffingStructure != null)
            {
                TempData["message"] = string.Format("Изменения в штатном расписании были сохранены");
            }
            return RedirectToAction("Index");
        }
    }
}