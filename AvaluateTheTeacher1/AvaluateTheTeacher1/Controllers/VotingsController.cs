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
    public class VotingsController : AccountController
    {
        private static int TeacherIdInController;

        private ApplicationDbContext db = new ApplicationDbContext();
        
        // GET: Votings
        [Authorize(Roles ="student")]
        public async System.Threading.Tasks.Task<ActionResult> Votings(int? id)
        {
            //Перевірка, чи не голосував студент вже в цьому місяці//
            var student = await UserManager.FindByNameAsync(User.Identity.Name);
            var listStudentVotings = db.StudentVotings.Where(m => m.TeacherId == id && m.StudentId == student.Id).ToList();
            if(listStudentVotings!=null)
            {
                foreach (var stVt in listStudentVotings)
                {
                    if (stVt.Date.Month == DateTime.Now.Month) return RedirectToAction("TimeOut");
                }
            }
            //- - - - - - - - - - - - - - - - - - - - - - - -//

            if (id == null)
            {
                return HttpNotFound();
            }

            TeacherIdInController = Int32.Parse(id.ToString());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "student")]
        public async System.Threading.Tasks.Task<ActionResult> Votings(Voting model)
        {
            if (ModelState.IsValid)
            {
                var voting = new Voting
                {
                    ActivityInClass = model.ActivityInClass,
                    AvailabilityTeacherOutsideLessons = model.AvailabilityTeacherOutsideLessons,
                    ClarityAndAccessibility = model.ClarityAndAccessibility,
                    CommentsTheWork = model.CommentsTheWork,
                    DepthPossessionOf = model.DepthPossessionOf,
                    HowWellTheProcedurePerformedGrading = model.HowWellTheProcedurePerformedGrading,
                    InterestInTheSubject = model.InterestInTheSubject,
                    NumberOfAttendance = model.NumberOfAttendance,
                    OverallSubject = model.OverallSubject,
                    PreparationTime = model.PreparationTime,
                    ProcedureGrading = model.ProcedureGrading,
                    QualityMasteringTheSubject = model.QualityMasteringTheSubject,
                    QualityTeachingMaterials = model.QualityTeachingMaterials,
                    RelevantToStudents = model.RelevantToStudents,
                    SomethingNew = model.SomethingNew,
                    TheDifficultyOfTheCourse = model.TheDifficultyOfTheCourse,
                    ThePracticalValue = model.ThePracticalValue,
                    TeacherId = TeacherIdInController
                };

                db.Votings.Add(voting);
                db.SaveChanges();

                var listId = db.Votings.ToList();

                int id = TeacherIdInController;

                // Фіксація голосування за календарем
                var student = await UserManager.FindByNameAsync(User.Identity.Name);
                var StVoting = new Models.Students.StudentVoting();
                StVoting.Date = DateTime.Now.Date;
                StVoting.StudentId = student.Id;
                StVoting.TeacherId = id;
                db.StudentVotings.Add(StVoting);
                //- - - - - - - - - - - - - - - - - - - - - - - -//

                foreach (var num in listId)
                {
                    double AIC = 0, ATOL = 0, CAA = 0, CTW = 0, DPO = 0, HWTPPG = 0, IITS = 0, NOA = 0, OS = 0, PT = 0;
                    double PG = 0, QMTS = 0, QTM = 0, RTS = 0, SN = 0, TDOTC = 0, TPV = 0, avgRelevant = 0, count = 0;
                    foreach (var voit in listId)
                    {
                        if (id == voit.TeacherId)
                        {
                            AIC += voit.ActivityInClass;
                            ATOL += voit.AvailabilityTeacherOutsideLessons;
                            CAA += voit.ClarityAndAccessibility;
                            CTW += voit.CommentsTheWork;
                            DPO += voit.DepthPossessionOf;
                            HWTPPG += voit.HowWellTheProcedurePerformedGrading;
                            IITS += voit.InterestInTheSubject;
                            NOA += voit.NumberOfAttendance;
                            OS += voit.OverallSubject;
                            PT += voit.PreparationTime;
                            PG += voit.ProcedureGrading;
                            QMTS += voit.QualityMasteringTheSubject;
                            QTM += voit.QualityTeachingMaterials;
                            RTS += voit.RelevantToStudents;
                            SN += voit.SomethingNew;
                            TDOTC += voit.TheDifficultyOfTheCourse;
                            TPV += voit.ThePracticalValue;
                            avgRelevant += voit.RelevantToStudents;
                            count++;
                                                        
                        }
                    }
                    var query = from ord in db.Ratings where ord.TeacherId == id select ord;
                    foreach (Rating rating in query)
                    {
                        rating.ActivityInClass = float.Parse(Math.Round((AIC / count), 1).ToString());
                        rating.AvailabilityTeacherOutsideLessons = float.Parse(Math.Round((ATOL / count), 1).ToString());
                        rating.ClarityAndAccessibility = float.Parse(Math.Round((CAA / count), 1).ToString());
                        rating.CommentsTheWork = float.Parse(Math.Round((CTW / count), 1).ToString());
                        rating.DepthPossessionOf = float.Parse(Math.Round((DPO / count), 1).ToString());
                        rating.HowWellTheProcedurePerformedGrading = float.Parse(Math.Round((HWTPPG / count), 1).ToString());
                        rating.InterestInTheSubject = float.Parse(Math.Round((IITS / count), 1).ToString());
                        rating.NumberOfAttendance = float.Parse(Math.Round((NOA / count), 1).ToString());
                        rating.OverallSubject = float.Parse(Math.Round((OS / count), 1).ToString());
                        rating.PreparationTime = float.Parse(Math.Round((PT / count), 1).ToString());
                        rating.ProcedureGrading = float.Parse(Math.Round((PG / count), 1).ToString());
                        rating.QualityMasteringTheSubject = float.Parse(Math.Round((QMTS / count), 1).ToString());
                        rating.QualityTeachingMaterials = float.Parse(Math.Round((QTM / count), 1).ToString());
                        rating.RelevantToStudents = float.Parse(Math.Round((RTS / count), 1).ToString());
                        rating.SomethingNew = float.Parse(Math.Round((SN / count), 1).ToString());
                        rating.TheDifficultyOfTheCourse = float.Parse(Math.Round((TDOTC / count), 1).ToString());
                        rating.ThePracticalValue = float.Parse(Math.Round((TPV / count), 1).ToString());
                        rating.AvgRating = float.Parse(Math.Round(((AIC / count + ATOL / count + CAA / count + CTW / count + DPO / count + HWTPPG / count + IITS / count + NOA / count + OS / count + PT / count + PG / count + QMTS / count + QTM / count + RTS / count + SN / count + TDOTC / count + TPV / count) / 17), 1).ToString());
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }

        public ActionResult TimeOut()
        {
            return View();
        }
    }
}