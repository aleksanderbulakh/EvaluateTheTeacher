using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Students;

namespace AvaluateTheTeacher1.Controllers
{
    public class GroupController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Group
        public ActionResult Index()
        {
            return View(db.Groups.ToList());
        }

        // GET: Group/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            var GroupTeacherSubject = group.TeachersSubjects.ToList();
            List<string> GTS = new List<string>();

            Models.Teachers.Teacher teacher_buf = new Models.Teachers.Teacher();
            Models.Teachers.Subject subj_buf = new Models.Teachers.Subject();

            foreach (var c in GroupTeacherSubject)
            {
                teacher_buf = db.Teachers.Find(c.TeacherId);
                subj_buf = db.Subjects.Find(c.SubjectId);
                GTS.Add(teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString() + " / " + subj_buf.Name);
            }
            ViewBag.Teachers = GTS;
            ViewBag.CountStudents = group.Users.Count();
            return View(group);
        }

        // GET: Group/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GroupId,Name")] Group group)
        {
            if (ModelState.IsValid)
            {
                db.Groups.Add(group);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(group);
        }

        // GET: Group/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);

            if (group == null)
            {
                return HttpNotFound();
            }
            var GroupTeacherSubject = group.TeachersSubjects.ToList();
            var TeacherSubject = db.TeacherSubject.ToList();

            var dictionaryTSTrue = new Dictionary<int, string>();                // Викладач і предмет, які вже зареєстровані в групі
            var dictionaryTSFalse = new Dictionary<int, string>();               // які не зареєстровані в групі

            //Якщо у групі немає зареєстрованих викладачів та пердметів
            //Додаємо у словник весь перелік викладачів та предметів
            Models.Teachers.Teacher teacher_buf = new Models.Teachers.Teacher();
            Models.Teachers.Subject subj_buf = new Models.Teachers.Subject();
            if (GroupTeacherSubject.Count == 0)
            {

                foreach (var c in TeacherSubject)
                {
                    teacher_buf = db.Teachers.Find(c.TeacherId);
                    subj_buf = db.Subjects.Find(c.SubjectId);
                    dictionaryTSFalse.Add(c.Id, teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString() + " / " + subj_buf.Name);
                }
            }

            //В іншому випадку - розділяємо їх на два словники
            else
            {
                foreach (var GTS in GroupTeacherSubject)
                {
                    teacher_buf = db.Teachers.Find(GTS.TeacherId);
                    subj_buf = db.Subjects.Find(GTS.SubjectId);
                    dictionaryTSTrue.Add(GTS.Id, teacher_buf.SurName.ToString() + " " + teacher_buf.Name.ToString()+ " " + teacher_buf.LastName.ToString() + " / " + subj_buf.Name.ToString());
                }

                foreach (var GTS in TeacherSubject)
                {
                    if (dictionaryTSTrue.Any(m => m.Key == GTS.Id) == false)
                    {
                        teacher_buf = db.Teachers.Find(GTS.TeacherId);
                        subj_buf = db.Subjects.Find(GTS.SubjectId);
                        dictionaryTSFalse.Add(GTS.Id, teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString() + " / " + subj_buf.Name);
                    }
                }
            }

            var dictionaryTS = new Dictionary<bool, Dictionary<int, string>>();
            dictionaryTS.Add(true, dictionaryTSTrue);
            dictionaryTS.Add(false, dictionaryTSFalse);
            ViewBag.DictionaryTS = dictionaryTS;

            return View(group);
        }

        // POST: Group/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GroupId,Name")] Group group, int[] TeachersSubjects)
        {
            if (ModelState.IsValid)
            {
                Group newgroup = db.Groups.Find(group.GroupId);
                newgroup.Name = group.Name;

                newgroup.TeachersSubjects.Clear();
                if (TeachersSubjects != null)
                {
                    foreach (var c in db.TeacherSubject.Where(co => TeachersSubjects.Contains(co.Id)))
                    {
                        newgroup.TeachersSubjects.Add(c);
                    }
                }

                db.Entry(newgroup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(group);
        }

        // GET: Group/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Group group = db.Groups.Find(id);
            if (group == null)
            {
                return HttpNotFound();
            }
            return View(group);
        }

        // POST: Group/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Group group = db.Groups.Find(id);
            db.Groups.Remove(group);
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
