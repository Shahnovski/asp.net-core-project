using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using University.Models;

namespace University.Controllers
{
    public class AdminTeachersController : Controller
    {
        private readonly UniversityContext db;
        public AdminTeachersController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult Index()
        {
            IEnumerable<Teacher> teachers = db.Teachers;
            return View(teachers);
        }

        public ViewResult Edit(int Id)
        {
            Teacher teacher = db.Teachers.FirstOrDefault(p => p.Id == Id);
            return View(teacher);
        }

        [HttpPost]
        public ActionResult Edit(Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                if (teacher.Id == 0)
                    db.Teachers.Add(teacher);
                else
                {
                    Teacher dbEntry = db.Teachers.Find(teacher.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.LastName = teacher.LastName;
                        dbEntry.FirstName = teacher.FirstName;
                        dbEntry.MiddleName = teacher.MiddleName;
                        dbEntry.ScienceDegree = teacher.ScienceDegree;
                        dbEntry.AcadimicTitle = teacher.AcadimicTitle;
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения преподавателя \"{0}\" были сохранены", teacher.LastName + " " + teacher.FirstName + " " + teacher.MiddleName);
                return RedirectToAction("Index");
            }
            else
            {
                return View(teacher);
            }
        }

        public ViewResult Create()
        {
            return View("Edit", new Teacher());
        }

        [HttpPost]
        public ActionResult Delete(int teacherId)
        {
            Teacher teacher = db.Teachers.Find(teacherId);
            if (teacher != null)
            {
                db.Teachers.Remove(teacher);
                db.SaveChanges();
            }
            if (teacher != null)
            {
                TempData["message"] = string.Format("Преподаватель \"{0}\" был удален", teacher.LastName + " " + teacher.FirstName + " " + teacher.MiddleName);
            }
            return RedirectToAction("Index");
        }
    }
}