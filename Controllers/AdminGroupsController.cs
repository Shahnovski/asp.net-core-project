using System.Collections.Generic;
using System.Linq;
using University.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace University.Controllers
{
    public class AdminGroupsController : Controller
    {
        private readonly UniversityContext db;
        public AdminGroupsController(UniversityContext context)
        {
            db = context;
        }
        public ViewResult Index()
        {
            IEnumerable<Group> groups = db.Groups.Include(p => p.Specialty);
            return View(groups);
        }

        public ViewResult Edit(int Id)
        {
            Group group = db.Groups.FirstOrDefault(p => p.Id == Id);
            SelectList specialties = new SelectList(db.Specialties, "Id", "Title");
            ViewBag.Specialties = specialties;
            return View(group);
        }

        [HttpPost]
        public ActionResult Edit(Group group)
        {
            SelectList specialties = new SelectList(db.Specialties, "Id", "Title");
            ViewBag.Specialties = specialties;
            if (ModelState.IsValid)
            {
                if (group.Id == 0)
                    db.Groups.Add(group);
                else
                {
                    Group dbEntry = db.Groups.Find(group.Id);
                    if (dbEntry != null)
                    {
                        dbEntry.Number = group.Number;
                        dbEntry.FormOfLearning = group.FormOfLearning;
                        dbEntry.SpecialtyId = group.SpecialtyId;
                    }
                }
                db.SaveChanges();
                TempData["message"] = string.Format("Изменения группы \"{0}\" были сохранены", group.Number);
                return RedirectToAction("Index");
            }
            else
            {
                return View(group);
            }
        }

        public ViewResult Create()
        {
            SelectList specialties = new SelectList(db.Specialties, "Id", "Title");
            ViewBag.Specialties = specialties;
            return View("Edit", new Group());
        }

        [HttpPost]
        public ActionResult Delete(int groupId)
        {
            Group group = db.Groups.Find(groupId);
            if (group != null)
            {
                db.Groups.Remove(group);
                db.SaveChanges();
            }
            if (group != null)
            {
                TempData["message"] = string.Format("Группа \"{0}\" была удалена", group.Number);
            }
            return RedirectToAction("Index");
        }
    }
}