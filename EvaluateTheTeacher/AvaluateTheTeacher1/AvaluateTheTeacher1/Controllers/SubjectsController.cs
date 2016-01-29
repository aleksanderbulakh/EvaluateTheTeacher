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
using AvaluateTheTeacher1.Models.Students;
using AvaluateTheTeacher1.CodeReview.ViewModels;

namespace AvaluateTheTeacher1.Controllers
{
    public class SubjectsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Subjects
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var subjects = db.Subjects.Include(s => s.Cathedra);
            return View(subjects.ToList());
        }

        // GET: Subjects/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            SubjectDetailsViewModel detailsSubject = new SubjectDetailsViewModel();

            detailsSubject.Name = subject.Name;
            detailsSubject.Cathedra = db.Cathedras.Find(subject.CathedraId).NameCathedra;
            detailsSubject.Semesters = subject.Semesters.ToList();
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(detailsSubject);
        }

        // GET: Subjects/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            var subject = new CodeReview.ViewModels.SubjectViewModel();
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra");
            subject.Semesters = db.Semesters.ToList();
            ViewBag.NoChange = false;

            return View(subject);
        }

        // POST: Subjects/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CathedraId")] CodeReview.ViewModels.SubjectViewModel subject, int [] semesters)
        {
            if (ModelState.IsValid&&semesters!=null)
            {
                Subject newSubject = new Subject();

                newSubject.Name = subject.Name;
                newSubject.CathedraId = subject.CathedraId;

                foreach(int s in semesters)
                {                    
                    newSubject.Semesters.Add(db.Semesters.Find(s));
                }

                db.Subjects.Add(newSubject);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            subject.Semesters = db.Semesters.ToList();
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", subject.CathedraId);
            ViewBag.NoChange = true;
            return View(subject);
        }

        // GET: Subjects/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }

            var semestersForSubject = subject.Semesters.ToList();

            var editSubject = new SubjectEditViewModel();
            editSubject.Id = subject.Id;
            editSubject.Name = subject.Name;
            editSubject.CathedraId = subject.CathedraId;
            editSubject.Semesters = new List<SemesterForSubject>();

            foreach(var s in db.Semesters)
            {
                SemesterForSubject addSemester = new SemesterForSubject();
                addSemester.Id = s.Id;
                addSemester.From = s.From;
                addSemester.To = s.To;
                if (subject.Semesters.FirstOrDefault(subS => subS.Id == s.Id) == null)
                    addSemester.IsChange = false;
                else
                    addSemester.IsChange = true;

                editSubject.Semesters.Add(addSemester);
            }

            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", subject.CathedraId);
            return View(editSubject);
        }

        // POST: Subjects/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CathedraId")] SubjectEditViewModel subject, int [] Semesters)
        {
            Subject updateSubject = new Subject();
            if (ModelState.IsValid && Semesters != null)
            {
                
                updateSubject = db.Subjects.Find(subject.Id);

                updateSubject.Name = subject.Name;
                updateSubject.CathedraId = subject.CathedraId;

                updateSubject.Semesters.Clear();
                var allSemesters = db.Semesters;
                foreach(var item in Semesters)
                {
                    Semester addSemester = allSemesters.Find(item);
                    updateSubject.Semesters.Add(addSemester);
                }

                                    
                db.Entry(updateSubject).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", subject.CathedraId);
            
            return View(subject);
        }

        // GET: Subjects/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Subject subject = db.Subjects.Find(id);
            if (subject == null)
            {
                return HttpNotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Subject subject = db.Subjects.Find(id);
            db.Subjects.Remove(subject);
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
