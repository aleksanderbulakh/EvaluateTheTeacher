using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;

namespace AvaluateTheTeacher1.Controllers
{
    public class AddingTeacherController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: AddingTeaher
        [Authorize(Roles = "admin")]
        public ActionResult AddNewTeacher()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult AddNewTeacher (AddNewTeacherViewModel model)
        {
            if (ModelState.IsValid)
            {
                var teacher = new Models.Teachers.Teacher();
                teacher.Name = model.Name;
                teacher.SurName = model.SurName;
                teacher.LastName = model.LastName;
                

                string path = AppDomain.CurrentDomain.BaseDirectory + "TeacherImg/";
                string filename = System.IO.Path.GetFileName(model.Photo.FileName);
                model.Photo.SaveAs(System.IO.Path.Combine(path, filename));
                teacher.PathToPhoto = Server.MapPath(model.Photo.FileName);

                db.Teachers.Add(teacher);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}