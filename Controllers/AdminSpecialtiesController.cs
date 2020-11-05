using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Controllers
{
    public class AdminSpecialtiesController : Controller
    {
        private readonly UniversityContext db;
        public AdminSpecialtiesController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult Index()
        {
            IEnumerable<Specialty> specialties = db.Specialties.Include(p => p.Department);
            return View(specialties);
        }

        public ViewResult Edit(int Id)
        {
            Specialty specialty = db.Specialties.FirstOrDefault(p => p.Id == Id);
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Departemnts = departments;
            return View(specialty);
        }

        [HttpPost]
        public ActionResult Edit(Specialty specialty)
        {
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Departemnts = departments;
            if (ModelState.IsValid)
            {
                if (specialty.Id == 0)
                    db.Specialties.Add(specialty);
                else
                {
                    Specialty dbEntry = db.Specialties.Find(specialty.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Title = specialty.Title;
                        dbEntry.DepartmentId = specialty.DepartmentId;
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения специальности \"{0}\" были сохранены", specialty.Title);
                return RedirectToAction("Index");
            }
            else
            {
                return View(specialty);
            }
        }

        public ViewResult Create()
        {
            SelectList departments = new SelectList(db.Departments, "Id", "Title");
            ViewBag.Departemnts = departments;
            return View("Edit", new Specialty());
        }

        [HttpPost]
        public ActionResult Delete(int specialtyId)
        {
            Specialty specialty = db.Specialties.Find(specialtyId);
            if (specialty != null)
            {
                db.Specialties.Remove(specialty);
                db.SaveChanges();
            }
            if (specialty != null)
            {
                TempData["message"] = string.Format("Специальность \"{0}\" была удалена", specialty.Title);
            }
            return RedirectToAction("Index");
        }
    }
}