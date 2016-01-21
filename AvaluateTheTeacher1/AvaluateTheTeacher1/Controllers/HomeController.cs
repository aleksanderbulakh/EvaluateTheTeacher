using AvaluateTheTeacher1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Index()
        {
            /*var first = from list in db.StudentVotings select list;
            foreach (var time in first.ToList())
            {
                if (time.Date.Month < DateTime.Now.Month || time.Date.Year < DateTime.Now.Year)
                {
                    var query = from list in db.Teachers
                                select list;
                    foreach (var data in query.ToList())
                    {
                        var rait = db.Ratings.Where(x => x.TeacherId == data.TeacherId);
                        foreach (var change in rait.ToList())
                        {
                            if (change.ForTheEntirePeriod != 0f)
                                change.ForTheEntirePeriod = (float)Math.Round((((change.ForTheEntirePeriod + change.PreviousMonth) / 2) - (((change.ForTheEntirePeriod + change.PreviousMonth) / 2) * 0.0035f)), 1);
                            else
                                change.ForTheEntirePeriod = change.PreviousMonth;
                            change.PreviousMonth = change.AvgRating;
                            change.ActivityInClass = 0;
                            change.AvailabilityTeacherOutsideLessons = 0;
                            change.ClarityAndAccessibility = 0;
                            change.CommentsTheWork = 0;
                            change.DepthPossessionOf = 0;
                            change.HowWellTheProcedurePerformedGrading = 0;
                            change.InterestInTheSubject = 0;
                            change.NumberOfAttendance = 0;
                            change.OverallSubject = 0;
                            change.PreparationTime = 0;
                            change.ProcedureGrading = 0;
                            change.QualityMasteringTheSubject = 0;
                            change.QualityTeachingMaterials = 0;
                            change.RelevantToStudents = 0;
                            change.SomethingNew = 0;
                            change.TheDifficultyOfTheCourse = 0;
                            change.ThePracticalValue = 0;
                            change.AvgRating = 0;
                            change.CountRaitingVoting = 0;
                        }
                        var RaitTeacherSubj = from list in db.RaitingTeacherSubject
                                              .Where(x => x.TeacherSubject.TeacherId == data.TeacherId)
                                              select list;
                        foreach (var row in RaitTeacherSubj.ToList())
                        {
                            if (row.ForTheEntirePeriod != 0f)
                                row.ForTheEntirePeriod = (float)Math.Round((((row.ForTheEntirePeriod + row.PreviousMonth) / 2) - (((row.ForTheEntirePeriod + row.PreviousMonth) / 2) * 0.0035f)), 1);
                            else
                                row.ForTheEntirePeriod = row.PreviousMonth;
                            row.PreviousMonth = row.AvgRating;
                            row.ActivityInClass = 0;
                            row.AvailabilityTeacherOutsideLessons = 0;
                            row.ClarityAndAccessibility = 0;
                            row.CommentsTheWork = 0;
                            row.DepthPossessionOf = 0;
                            row.HowWellTheProcedurePerformedGrading = 0;
                            row.InterestInTheSubject = 0;
                            row.NumberOfAttendance = 0;
                            row.OverallSubject = 0;
                            row.PreparationTime = 0;
                            row.ProcedureGrading = 0;
                            row.QualityMasteringTheSubject = 0;
                            row.QualityTeachingMaterials = 0;
                            row.RelevantToStudents = 0;
                            row.SomethingNew = 0;
                            row.TheDifficultyOfTheCourse = 0;
                            row.ThePracticalValue = 0;
                            row.AvgRating = 0;
                            row.CountVoting = 0;
                        }
                        db.SaveChanges();
                    }
                    var DelVoiting = from list in db.Votings
                                     select list;
                    foreach (var del in DelVoiting.ToList())
                        db.Votings.Remove(del);
                    db.SaveChanges();

                    var DelStudVoit = from list in db.StudentVotings
                                      select list;
                    foreach (var del in DelStudVoit.ToList())
                        db.StudentVotings.Remove(del);
                    db.SaveChanges();
                    break;
                }
            }*/
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}