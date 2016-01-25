using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Controllers
{
    public class MoreInfoForteacherController : Controller
    {
        private IQueryable<MoreInfoForTeacher> query { get; set; }
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: MoreInfoForteacher
        public ActionResult Index(int id)
        {
            Teacher teacher = db.Teachers.Find(id);


            Rating rating = db.Ratings.First(m => m.TeacherId == teacher.TeacherId);
            MoreInfoForTeacher TeacherInf = new MoreInfoForTeacher();
            TeacherInf.TeacherId = teacher.TeacherId;
            TeacherInf.NameCathedra = db.Cathedras.Find(teacher.CathedraId).NameCathedra;
            TeacherInf.Name = teacher.Name;
            TeacherInf.SurName = teacher.SurName;
            TeacherInf.LastName = teacher.LastName;
            TeacherInf.PathToPhoto = teacher.PathToPhoto;
            TeacherInf.Description = teacher.Description;
            TeacherInf.ForTheEntirePeriod = rating.ForTheEntirePeriod;
            TeacherInf.PreviousMonth = rating.PreviousMonth;
            TeacherInf.AvgRating = rating.AvgRating;
            TeacherInf.ActivityInClass = rating.ActivityInClass;
            TeacherInf.AvailabilityTeacherOutsideLessons = rating.AvailabilityTeacherOutsideLessons;
            TeacherInf.ClarityAndAccessibility = rating.ClarityAndAccessibility;
            TeacherInf.CommentsTheWork = rating.CommentsTheWork;
            TeacherInf.CountRaitingVoting = rating.CountRaitingVoting;
            TeacherInf.DepthPossessionOf = rating.DepthPossessionOf;
            TeacherInf.HowWellTheProcedurePerformedGrading = rating.HowWellTheProcedurePerformedGrading;
            TeacherInf.InterestInTheSubject = rating.InterestInTheSubject;
            TeacherInf.NumberOfAttendance = rating.NumberOfAttendance;
            TeacherInf.OverallSubject = rating.OverallSubject;
            TeacherInf.PreparationTime = rating.PreparationTime;
            TeacherInf.ProcedureGrading = rating.ProcedureGrading;
            TeacherInf.QualityMasteringTheSubject = rating.QualityMasteringTheSubject;
            TeacherInf.QualityTeachingMaterials = rating.QualityTeachingMaterials;
            TeacherInf.RelevantToStudents = rating.RelevantToStudents;
            TeacherInf.SomethingNew = rating.SomethingNew;
            TeacherInf.TheDifficultyOfTheCourse = rating.TheDifficultyOfTheCourse;
            TeacherInf.ThePracticalValue = rating.ThePracticalValue;
            TeacherInf.CountRaitingVoting = rating.CountRaitingVoting;


            return View(TeacherInf);
        }
    }
}