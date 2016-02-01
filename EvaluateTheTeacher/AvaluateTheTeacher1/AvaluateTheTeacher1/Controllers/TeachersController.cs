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
        ApplicationDbContext dbList = new ApplicationDbContext();
        // GET: Teachers
        [Authorize(Roles = "admin")]
        public ActionResult Index()
        {
            using (var db = new ApplicationDbContext())
            {
                var teachers = db.Teachers.Include(t => t.Cathedra);
                return View(teachers.ToList());
            }
        }

        // GET: Teachers/Create
        [Authorize(Roles = "admin")]
        public ActionResult Create()
        {
            using (var db = new ApplicationDbContext())
            {
                ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra");
                return View();
            }
        }

        // POST: Teachers/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TeacherId,Name,SurName,LastName,PathToPhoto,Description,CathedraId")] Teacher teacher)
        {
            using (var db = new ApplicationDbContext())
            {
                if (ModelState.IsValid)
                {
                    db.Teachers.Add(teacher);
                    db.SaveChanges();
                    return RedirectToRoute("TeachersList");
                }

                ViewBag.CathedraId = new SelectList(db.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
                return View(teacher);
            }
        }

        // GET: Teachers/Edit/5
        [Authorize(Roles = "admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
                Teacher teacher = dbList.Teachers.Find(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }

                ViewBag.CathedraId = new SelectList(dbList.Cathedras, "Id", "NameCathedra", teacher.CathedraId);

                var Subjects = dbList.Subjects.Where(m => m.CathedraId == teacher.CathedraId).ToList();
                var TeacherSubject = dbList.TeacherSubject.Where(m => m.TeacherId == teacher.TeacherId && m.TeacherId != 0).ToList();

                var subjectsFirstSemesterNotSelected = new Dictionary<int, string>();
                var subjectsSecondSemesterNotSelected = new Dictionary<int, string>();
                var subjectsThreeSemesterNotSelected = new Dictionary<int, string>();
                var subjectsFourSemesterNotSelected = new Dictionary<int, string>();
                var subjectsFifthSemesterNotSelected = new Dictionary<int, string>();
                var subjectsSixSemesterNotSelected = new Dictionary<int, string>();
                var subjectsSevenSemesterNotSelected = new Dictionary<int, string>();
                var subjectsEightSemesterNotSelected = new Dictionary<int, string>();

                var subjectsFirstSemesterSelected = new Dictionary<int, string>();
                var subjectsSecondSemesterSelected = new Dictionary<int, string>();
                var subjectsThreeSemesterSelected = new Dictionary<int, string>();
                var subjectsFourSemesterSelected = new Dictionary<int, string>();
                var subjectsFifthSemesterSelected = new Dictionary<int, string>();
                var subjectsSixSemesterSelected = new Dictionary<int, string>();
                var subjectsSevenSemesterSelected = new Dictionary<int, string>();
                var subjectsEightSemesterSelected = new Dictionary<int, string>();

                string dictOut;


                foreach (var TeachSubj in TeacherSubject)
                {
                    switch (TeachSubj.SemesterId)
                    {
                        case 1:
                            {
                                subjectsFirstSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 2:
                            {
                                subjectsSecondSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 3:
                            {
                                subjectsThreeSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 4:
                            {
                                subjectsFourSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 5:
                            {
                                subjectsFifthSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 6:
                            {
                                subjectsSixSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 7:
                            {
                                subjectsSevenSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;
                        case 8:
                            {
                                subjectsEightSemesterSelected.Add(TeachSubj.Subjects.Id, TeachSubj.Subjects.Name);
                            }
                            break;

                    }
                }
                foreach (var Subj in Subjects)
                {
                    foreach (var semesterData in Subj.Semesters)
                    {
                        if (!subjectsFirstSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 1)
                            subjectsFirstSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsSecondSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 2)
                            subjectsSecondSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsThreeSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 3)
                            subjectsThreeSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsFourSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 4)
                            subjectsFourSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsFifthSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 5)
                            subjectsFifthSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsSixSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 6)
                            subjectsSixSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsSevenSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 7)
                            subjectsSevenSemesterNotSelected.Add(Subj.Id, Subj.Name);

                        if (!subjectsEightSemesterSelected.TryGetValue(Subj.Id, out dictOut) && semesterData.SemesterId == 8)
                            subjectsEightSemesterNotSelected.Add(Subj.Id, Subj.Name);
                    }
                }
                //}
                var subjectSemecterSelected = new Dictionary<int, Dictionary<int, string>>();
                subjectSemecterSelected.Add(1, subjectsFirstSemesterSelected);
                subjectSemecterSelected.Add(2, subjectsSecondSemesterSelected);
                subjectSemecterSelected.Add(3, subjectsThreeSemesterSelected);
                subjectSemecterSelected.Add(4, subjectsFourSemesterSelected);
                subjectSemecterSelected.Add(5, subjectsFifthSemesterSelected);
                subjectSemecterSelected.Add(6, subjectsSixSemesterSelected);
                subjectSemecterSelected.Add(7, subjectsSevenSemesterSelected);
                subjectSemecterSelected.Add(8, subjectsEightSemesterSelected);

                var subjectSemecterNotSelected = new Dictionary<int, Dictionary<int, string>>();
                subjectSemecterNotSelected.Add(1, subjectsFirstSemesterNotSelected);
                subjectSemecterNotSelected.Add(2, subjectsSecondSemesterNotSelected);
                subjectSemecterNotSelected.Add(3, subjectsThreeSemesterNotSelected);
                subjectSemecterNotSelected.Add(4, subjectsFourSemesterNotSelected);
                subjectSemecterNotSelected.Add(5, subjectsFifthSemesterNotSelected);
                subjectSemecterNotSelected.Add(6, subjectsSixSemesterNotSelected);
                subjectSemecterNotSelected.Add(7, subjectsSevenSemesterNotSelected);
                subjectSemecterNotSelected.Add(8, subjectsEightSemesterNotSelected);

                var subjectList = new Dictionary<bool, Dictionary<int, Dictionary<int, string>>>();
                subjectList.Add(true, subjectSemecterSelected);
                subjectList.Add(false, subjectSemecterNotSelected);
                ViewBag.DictionaryTS = subjectList;

                return View(teacher);
            
        }

        // POST: Teachers/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "admin")]
        public ActionResult Edit([Bind(Include = "TeacherId,Name,SurName,LastName,PathToPhoto,Description,CathedraId")] Teacher teacher, int[] selectedSubjects)
        {
                if (!ModelState.IsValid)
                {
                    ViewBag.CathedraId = new SelectList(dbList.Cathedras, "Id", "NameCathedra", teacher.CathedraId);
                    return View(teacher);
                }

                Teacher newteacher = dbList.Teachers.Find(teacher.TeacherId);
                newteacher.Name = teacher.Name;
                newteacher.SurName = teacher.SurName;
                newteacher.LastName = teacher.LastName;
                newteacher.PathToPhoto = teacher.PathToPhoto;
                newteacher.Description = teacher.Description;

                if (selectedSubjects != null)
                {
                    var lastTeacherSubjects = dbList.TeacherSubject.Where(m => m.TeacherId == newteacher.TeacherId).ToList();
                    var dictionarySubjects = new Dictionary<int, int>();

                    int semesterId = 0, subjectId = 0;
                    for (int i = 0; i < selectedSubjects.Length; i++)
                    {
                        if (selectedSubjects[i] <= 99)
                        {
                            semesterId = int.Parse((selectedSubjects[i] / 10).ToString());
                            subjectId = int.Parse((((selectedSubjects[i] / 10f) - semesterId) * 10).ToString());
                        }
                        if (selectedSubjects[i] <= 999 && selectedSubjects[i] >= 101)
                        {
                            if (selectedSubjects[i] <= 109)
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 10).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 10f) - semesterId) * 10).ToString());
                            }
                            else
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 100).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 100f) - semesterId) * 100).ToString());
                            }
                        }
                        if (selectedSubjects[i] <= 9999 && selectedSubjects[i] >= 1001)
                        {
                            if (selectedSubjects[i] <= 1099)
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 100).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 100f) - semesterId) * 100).ToString());
                            }
                            else
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 1000).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 1000f) - semesterId) * 1000).ToString());
                            }
                        }
                        if (selectedSubjects[i] >= 10001 && selectedSubjects[i] <= 99999)
                        {
                            if (selectedSubjects[i] <= 10999)
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 1000).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 1000f) - semesterId) * 1000).ToString());
                            }
                            else
                            {
                                semesterId = int.Parse((selectedSubjects[i] / 10000).ToString());
                                subjectId = int.Parse((((selectedSubjects[i] / 10000f) - semesterId) * 10000).ToString());
                            }
                        }
                        var s = dbList.TeacherSubject.Where(m => (int)m.TeacherId == teacher.TeacherId && (int)m.SubjectId == subjectId && (int)m.SemesterId == semesterId);
                        int countSearch = 0;
                        foreach (var element in s)
                        {
                            countSearch++;
                        }
                        if (countSearch == 0)
                        {
                            var teacherData = new TeacherSubject
                            {
                                TeacherId = teacher.TeacherId,
                                SubjectId = subjectId,
                                SemesterId = semesterId
                            };
                            dbList.TeacherSubject.Add(teacherData);
                        }
                        dictionarySubjects.Add(semesterId, subjectId);
                    }
                    int count = 0;
                    var data = dbList.TeacherSubject.Where(m => m.TeacherId == teacher.TeacherId);

                    foreach (var r in data.ToList())
                    {
                        count = 0;
                        foreach (var d in dictionarySubjects)
                        {
                            if (r.SubjectId == d.Value && r.SemesterId == d.Key)
                            {
                                count++;
                            }
                        }
                        if (count == 0)
                        {
                            r.RaitingTeacherSubject.Clear();
                            r.Votings.Clear();
                            r.StudentVoting.Clear();
                            r.Groups.Clear();
                            dbList.TeacherSubject.Remove(r);
                        }
                    }
                }
                else
                {
                    var teacherSubject = dbList.TeacherSubject.Where(m => m.TeacherId == teacher.TeacherId).ToList();
                    foreach (var data in teacherSubject)
                    {
                        data.RaitingTeacherSubject.Clear();
                        data.Votings.Clear();
                        data.StudentVoting.Clear();
                        data.Groups.Clear();
                        dbList.TeacherSubject.Remove(data);

                    }
                }
                dbList.Entry(newteacher).State = EntityState.Modified;
                dbList.SaveChanges();

                var TeacherSubjectId = dbList.TeacherSubject.Where(x => x.TeacherId == teacher.TeacherId);

                foreach (var lest in TeacherSubjectId.ToList())
                {
                    if (lest.RaitingTeacherSubject.Count == 0)
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
                        lest.RaitingTeacherSubject.Add(raitingSubject);
                    }
                }
                dbList.Entry(newteacher).State = EntityState.Modified;
                dbList.SaveChanges();
                return RedirectToRoute("TeachersList");
            
        }

        // GET: Teachers/Delete/5
        [Authorize(Roles = "admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using (var db = new ApplicationDbContext())
            {
                Teacher teacher = db.Teachers.Find(id);
                if (teacher == null)
                {
                    return HttpNotFound();
                }
                return View(teacher);
            }
        }

        // POST: Teachers/Delete/5
        [Authorize(Roles = "admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            using (var db = new ApplicationDbContext())
            {
                Teacher teacher = db.Teachers.Include(a => a.Ratings).Include(b => b.TeachersSubjects).Include(c => c.Suggestion).Include(d => d.Message).FirstOrDefault(m => m.TeacherId == id);
                db.Teachers.Remove(teacher);
                db.SaveChanges();
                return RedirectToRoute("TeachersList");
            }
        }

        public ActionResult Dashboard()
        {
            using (var db = new ApplicationDbContext())
            {
                var TeachersRatings = db.Ratings.OrderByDescending(q => q.TheDifficultyOfTheCourse).OrderByDescending(t => t.CountRaitingVoting).OrderByDescending(m => m.AvgRating).Where(x => x.AvgRating != 0).ToList();


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
                        topTeacher[j].TeacherId = teacher_buf.TeacherId;
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
                for (int a = 0; a < topTeacher.Length; a++)
                {
                    if (topTeacher[a] == null) topTeacher[a] = new TopTeachersViewModel { Name = "Full", LastName = "Full", PathToPhoto = "07.jpg", Rating = 404, SurName = "Full" };
                }
                return View(topTeacher);
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
