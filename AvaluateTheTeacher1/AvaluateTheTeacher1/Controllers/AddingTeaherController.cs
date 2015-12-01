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
            var teacherModel = new AddNewTeacherViewModel();
            teacherModel.Cathedras = new SelectList(db.Cathedras, "Id", "NameCathedra");
            return View(teacherModel);
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
                teacher.Description = model.Description;
                teacher.CathedraId = model.SelectedCathedraId;

                string path = AppDomain.CurrentDomain.BaseDirectory + "TeacherImg/";
                string filename = System.IO.Path.GetFileName(model.Photo.FileName);
                model.Photo.SaveAs(System.IO.Path.Combine(path, filename));
                teacher.PathToPhoto = System.IO.Path.GetFileName(model.Photo.FileName);

                db.Teachers.Add(teacher);
                db.SaveChanges();
                var querty =
                    from list in db.Teachers
                    .Where(q => (q.Name == model.Name && q.LastName == model.LastName && q.SurName == model.SurName))
                    select list;
                var teacherId = querty.ToList();
                foreach (var obj in teacherId)
                {
                    var raiting = new Models.Teachers.Rating
                    {
                        AvgInterest = 0,
                        AvgQuality = 0,
                        AvgRating = 0,
                        AvgRelevantToStudents = 0,
                        ForTheEntirePeriod = 0,
                        PreviousMonth = 0,
                        TeacherId = obj.TeacherId
                    };
                    db.Ratings.Add(raiting);
                    db.SaveChanges();
                }
                
                return RedirectToAction("Index", "Home");
            }

            model.Cathedras = new SelectList(db.Cathedras, "Id", "NameCathedra");
            return View(model);
        }
    }
}