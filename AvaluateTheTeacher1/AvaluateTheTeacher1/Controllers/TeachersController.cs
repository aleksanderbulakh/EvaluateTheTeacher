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
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            var teachers = db.Teachers.Include(t => t.Cathedra);
            return View(teachers.ToList());
        }

        // GET: Teachers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra");
            return View();
        }

        // POST: Teachers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
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
            var Subjects = db.Subjects.Where(m => m.CathedraId == teacher.CathedraId).ToList();
            var TeacherSubject = db.TeacherSubject.Where(m => m.TeacherId == teacher.TeacherId).ToList();
            var dictionarySTrue = new Dictionary<int, string>();
            var dictionarySFalse = new Dictionary<int, string>();
            string dictOut;
            int count_search = 0, count = 0;
            if (TeacherSubject.Count == 0)
                foreach (var Subj in Subjects)
                {
                    dictionarySFalse.Add(Subj.Id, Subj.Name);
                }
            else
            {
                foreach (var TeachSubj in TeacherSubject)
                {
                    count = count_search = 0;
                    foreach (var Subj in Subjects)
                    {
                        count_search++;
                        if (TeachSubj.SubjectId == Subj.Id)
                        {
                            dictionarySTrue.Add(Subj.Id, Subj.Name);
                            count++;
                        }
                    }
                }
                foreach (var Subj in Subjects)
                    if (!dictionarySTrue.TryGetValue(Subj.Id, out dictOut))
                            dictionarySFalse.Add(Subj.Id, Subj.Name);      
            }
            var dictionaryTS = new Dictionary<bool, Dictionary<int, string>>();
            dictionaryTS.Add(true, dictionarySTrue);
            dictionaryTS.Add(false, dictionarySFalse);
            ViewBag.DictionaryTS = dictionaryTS;
            
            return View(teacher);
        }

        // POST: Teachers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
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
                var TeacherSubjectId = db.TeacherSubject.Where(x => x.TeacherId == teacher.TeacherId);
                foreach (var lest in TeacherSubjectId.ToList())
                {
                    var raitingSubject = new RaitingTeacherSubject
                    {
                        ActivityInClass = 0,
                        AvailabilityTeacherOutsideLessons = 0,
                        ClarityAndAccessibility = 0,
                        CommentsTheWork = 0,
                        DepthPossessionOf = 0,
                        HowWellTheProcedurePerformedGrading = 0,
                        InterestInTheSubject = 0,
                        NumberOfAttendance = 0,
                        OverallSubject = 0,
                        PreparationTime = 0,
                        ProcedureGrading = 0,
                        QualityMasteringTheSubject = 0,
                        QualityTeachingMaterials = 0,
                        RelevantToStudents = 0,
                        SomethingNew = 0,
                        TheDifficultyOfTheCourse = 0,
                        ThePracticalValue = 0,
                        AvgRating = 0,
                        ForTheEntirePeriod = 0,
                        PreviousMonth = 0,
                        TeacherSubjectId = lest.Id
                    };
                    db.RaitingTeacherSubject.Add(raitingSubject);
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
            return View(teacher);
        }

        // GET: Teachers/Delete/5
        [Authorize(Roles = "admin")]
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
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Teacher teacher = db.Teachers.Find(id);
            db.Teachers.Remove(teacher);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Dashboard()
        {
            var TeachersRatings = db.Ratings.OrderByDescending(m => m.AvgRating).Where(x=>x.AvgRating !=0 ).ToList();


            Teacher teacher_buf = new Teacher();
            TopTeachersViewModel[] topTeacher = new TopTeachersViewModel[6];


            //Обираємо трьох найкращих та трьох найгірших викладачів
            int i = 0, j = 0;
            foreach (var TR in TeachersRatings)
            {
                if (i <= 2 || i >= TeachersRatings.Count() - 3)
                {
                    teacher_buf = db.Teachers.Find(TR.TeacherId);

                    topTeacher[j] = new TopTeachersViewModel();
                    topTeacher[j].Name = teacher_buf.Name;
                    topTeacher[j].LastName = teacher_buf.LastName;
                    topTeacher[j].SurName = teacher_buf.SurName;
                    topTeacher[j].Rating = Math.Round(TR.AvgRating, 1);
                    topTeacher[j].PathToPhoto = teacher_buf.PathToPhoto;
                    j++;
                }
                i++;
            }
            
            //Якщо в масиві є значення null - заповнюємо їх даними.
            for(int a=0; a<topTeacher.Length; a++)
            {
                if (topTeacher[a] == null) topTeacher[a] = new TopTeachersViewModel { Name = "Full", LastName = "Full", PathToPhoto = "07.jpg", Rating =404, SurName = "Full" };
            }
            return View(topTeacher);
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
