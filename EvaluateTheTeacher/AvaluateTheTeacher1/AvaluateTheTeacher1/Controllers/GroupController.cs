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
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Controllers
{
    public class GroupController : Controller
    {
        ApplicationDbContext dbList = new ApplicationDbContext();
        // GET: Group
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                return View(db.Groups.ToList());
            }
        }

        // GET: Group/Details/5
        [Authorize(Roles = "admin")]
        public ActionResult Details(int? id)
        {
            using (var db = new ApplicationDbContext())
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
                    if (c.TeacherId != null)
                    {
                        teacher_buf = db.Teachers.Find(c.TeacherId);
                        subj_buf = db.Subjects.Find(c.SubjectId);
                        GTS.Add(teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString() + " / " + subj_buf.Name);
                    }
                }
                ViewBag.Teachers = GTS;
                ViewBag.CountStudents = group.Users.Count();
                return View(group);
            }
        }

        // GET: Group/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Group/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Create([Bind(Include = "GroupId,Name")] Group group)
        {
            using (var db = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Groups.Add(group);
                    db.SaveChanges();
                    return RedirectToRoute("GroupsList");
                }

                return View(group);
            }
        }

        // GET: Group/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var search = dbList.TeacherSubject.Where(x => x.TeacherId == null);
            foreach (var del in search.ToList())
                dbList.TeacherSubject.Remove(del);

            Group group = dbList.Groups.Find(id);

            if (group == null)
            {
                return HttpNotFound();
            }

            var GroupTeacherSubject = group.TeachersSubjects.ToList();
            var TeacherSubject = dbList.TeacherSubject.ToList();
            
            var tsFirstSemesterNotChecked = new Dictionary<int, string>();
            var tsSecondSemesterNotChecked = new Dictionary<int, string>();
            var tsThreeSemesterNotChecked = new Dictionary<int, string>();
            var tsFourSemesterNotChecked = new Dictionary<int, string>();
            var tsFiveSemesterNotChecked = new Dictionary<int, string>();
            var tsSixSemesterNotChecked = new Dictionary<int, string>();
            var tsSevenSemesterNotChecked = new Dictionary<int, string>();
            var tsEightSemesterNotChecked = new Dictionary<int, string>();
            var tsNinthSemesterNotChecked = new Dictionary<int, string>();
            var tsTenSemesterNotChecked = new Dictionary<int, string>();

            var tsFirstSemesterChecked = new Dictionary<int, string>();
            var tsSecondSemesterChecked = new Dictionary<int, string>();
            var tsThreeSemesterChecked = new Dictionary<int, string>();
            var tsFourSemesterChecked = new Dictionary<int, string>();
            var tsFiveSemesterChecked = new Dictionary<int, string>();
            var tsSixSemesterChecked = new Dictionary<int, string>();
            var tsSevenSemesterChecked = new Dictionary<int, string>();
            var tsEightSemesterChecked = new Dictionary<int, string>();
            var tsNinthSemesterChecked = new Dictionary<int, string>();
            var tsTenSemesterChecked = new Dictionary<int, string>();

            //Якщо у групі немає зареєстрованих викладачів та пердметів
            //Додаємо у словник весь перелік викладачів та предметів
            Teacher teacher_buf = new Models.Teachers.Teacher();
            Subject subj_buf = new Models.Teachers.Subject();
            if (GroupTeacherSubject.Count == 0)
            {

                foreach (var c in TeacherSubject)
                {
                    if (c.TeacherId != null)
                    {
                        switch (c.SemesterId)
                        {
                            case 1:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsFirstSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 2:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsSecondSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 3:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsThreeSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 4:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsFourSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 5:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsFiveSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 6:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsSixSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 7:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsSevenSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 8:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsEightSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 9:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsNinthSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 10:
                                {
                                    teacher_buf = dbList.Teachers.Find(c.TeacherId);
                                    subj_buf = dbList.Subjects.Find(c.SubjectId);
                                    tsTenSemesterNotChecked.Add(c.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            default: break;
                        }
                    }
                }
            }

            //В іншому випадку - розділяємо їх на два словники
            else
            {
                foreach (var GTS in GroupTeacherSubject)
                {
                    if (GTS.TeacherId != null)
                    {
                        switch (GTS.SemesterId)
                        {
                            case 1:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsFirstSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 2:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsSecondSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 3:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsThreeSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 4:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsFourSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 5:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsFiveSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 6:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsSixSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 7:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsSevenSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 8:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsEightSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 9:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsNinthSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            case 10:
                                {
                                    teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                    subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                    tsTenSemesterChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                }
                                break;
                            default: break;
                        }
                    }
                }

                foreach (var GTS in TeacherSubject)
                {
                    
                        switch (GTS.SemesterId)
                        {
                            case 1:
                                {
                                    if (tsFirstSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsFirstSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 2:
                                {
                                    if (tsSecondSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsSecondSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 3:
                                {
                                    if (tsThreeSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsThreeSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 4:
                                {
                                    if (tsFourSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsFourSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 5:
                                {
                                    if (tsFiveSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsFiveSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 6:
                                {
                                    if (tsSixSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsSixSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 7:
                                {
                                    if (tsSevenSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsSevenSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 8:
                                {
                                    if (tsEightSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsEightSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 9:
                                {
                                    if (tsNinthSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsNinthSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            case 10:
                                {
                                    if (tsTenSemesterChecked.Any(m => m.Key == GTS.Id) == false && GTS.TeacherId != null)
                                    {
                                        teacher_buf = dbList.Teachers.Find(GTS.TeacherId);
                                        subj_buf = dbList.Subjects.Find(GTS.SubjectId);
                                        tsTenSemesterNotChecked.Add(GTS.Id, subj_buf.Name + " / " + teacher_buf.SurName + " " + teacher_buf.Name + " " + teacher_buf.LastName.ToString());
                                    }
                                }
                                break;
                            default: break;
                        }
                    }
                
            }

            var semestredTSNotChecked = new Dictionary<int, Dictionary<int, string>>();
            var semestredTSChecked = new Dictionary<int, Dictionary<int, string>>();

            semestredTSChecked.Add(1, tsFirstSemesterChecked);
            semestredTSChecked.Add(2, tsSecondSemesterChecked);
            semestredTSChecked.Add(3, tsThreeSemesterChecked);
            semestredTSChecked.Add(4, tsFourSemesterChecked);
            semestredTSChecked.Add(5, tsFiveSemesterChecked);
            semestredTSChecked.Add(6, tsSixSemesterChecked);
            semestredTSChecked.Add(7, tsSevenSemesterChecked);
            semestredTSChecked.Add(8, tsEightSemesterChecked);
            semestredTSChecked.Add(9, tsNinthSemesterChecked);
            semestredTSChecked.Add(10, tsTenSemesterChecked);

            semestredTSNotChecked.Add(1, tsFirstSemesterNotChecked);
            semestredTSNotChecked.Add(2, tsSecondSemesterNotChecked);
            semestredTSNotChecked.Add(3, tsThreeSemesterNotChecked);
            semestredTSNotChecked.Add(4, tsFourSemesterNotChecked);
            semestredTSNotChecked.Add(5, tsFiveSemesterNotChecked);
            semestredTSNotChecked.Add(6, tsSixSemesterNotChecked);
            semestredTSNotChecked.Add(7, tsSevenSemesterNotChecked);
            semestredTSNotChecked.Add(8, tsEightSemesterNotChecked);
            semestredTSNotChecked.Add(9, tsNinthSemesterNotChecked);
            semestredTSNotChecked.Add(10, tsTenSemesterNotChecked);

            var tsDictionary = new Dictionary<bool, Dictionary<int, Dictionary<int, string>>>();

            tsDictionary.Add(true, semestredTSChecked);
            tsDictionary.Add(false, semestredTSNotChecked);

            ViewBag.DictionaryTS = tsDictionary;

            return View(group);

        }

        // POST: Group/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "GroupId,Name")] Group group, int[] TeachersSubjects)
        {
                if (ModelState.IsValid)
                {
                    Group newgroup = dbList.Groups.Find(group.GroupId);
                    newgroup.Name = group.Name;

                    newgroup.TeachersSubjects.Clear();
                    if (TeachersSubjects != null)
                    {
                        foreach (var c in dbList.TeacherSubject.Where(co => TeachersSubjects.Contains(co.Id)))
                        {
                            newgroup.TeachersSubjects.Add(c);
                        }
                    }

                    dbList.Entry(newgroup).State = EntityState.Modified;
                    dbList.SaveChanges();
                    return RedirectToRoute("GroupsList");
                }
                return View(group);
        }

        // GET: Group/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            using (var db = new ApplicationDbContext())
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
        }

        // POST: Group/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Group group = db.Groups.Find(id);
                db.Groups.Remove(group);
                db.SaveChanges();
                return RedirectToRoute("GroupsList");
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                dbList.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
