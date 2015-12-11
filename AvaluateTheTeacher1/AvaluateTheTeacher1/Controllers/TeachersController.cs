using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Controllers
{
    public class TeachersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Teachers
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Cathedra);
            return View(teachers.ToList());
        }

        // GET: Teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: Teachers/Create
        public ActionResult Create()
        {
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra");
            return View();
        }

        // POST: Teachers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,Name,SurName,LastName,PathToPhoto,Description,CathedraId")] Teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.Teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
            return View(teacher);
        }

        // GET: Teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
            ViewBag.Subjects = db.Subjects.Where(m => m.CathedraId == teacher.CathedraId).ToList();
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TeacherId,Name,SurName,LastName,PathToPhoto,Description,CathedraId")] Teacher teacher, int [] selectedSubjects)
        {
            if (ModelState.IsValid)
            {
                Teacher newteacher = db.Teachers.Find(teacher.TeacherId);
                newteacher.Name = teacher.Name;
                newteacher.SurName = teacher.SurName;
                newteacher.LastName = teacher.LastName;
                newteacher.PathToPhoto = teacher.PathToPhoto;
                newteacher.Description = teacher.Description;

                newteacher.TeachersSubjects.Clear();
                teacher.TeachersSubjects.Clear();
                if (selectedSubjects != null)
                {
                    foreach (var c in db.Subjects.Where(co => selectedSubjects.Contains(co.Id)))
                    {
                        var teachersubject = new TeacherSubject
                        {
                            TeacherId = teacher.TeacherId,
                            SubjectId = c.Id
                        };
                        newteacher.TeachersSubjects.Add(teachersubject);
                    }

                }   
                db.Entry(newteacher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Teacher teacher = db.Teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: Teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
