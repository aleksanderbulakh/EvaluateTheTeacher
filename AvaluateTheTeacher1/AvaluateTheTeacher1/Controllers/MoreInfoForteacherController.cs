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
            query =
                   from listCathedras in db.Cathedras
                   from listRaitings in db.Ratings
                   from listTeachers in db.Teachers
                   .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && (listTeachers1.CathedraId == listCathedras.Id))
                   orderby listRaitings.AvgRating descending
                   select new MoreInfoForTeacher()
                   {
                       TeacherId = listTeachers.TeacherId,
                       NameCathedra = listCathedras.NameCathedra,
                       Name = listTeachers.Name,
                       SurName = listTeachers.SurName,
                       LastName = listTeachers.LastName,
                       PathToPhoto = listTeachers.PathToPhoto,
                       Description = listTeachers.Description,
                       ForTheEntirePeriod = listRaitings.ForTheEntirePeriod,
                       PreviousMonth = listRaitings.PreviousMonth,
                       AvgRating = listRaitings.AvgRating,
                       ActivityInClass = listRaitings.ActivityInClass,
                       AvailabilityTeacherOutsideLessons = listRaitings.AvailabilityTeacherOutsideLessons,
                       ClarityAndAccessibility = listRaitings.ClarityAndAccessibility,
                       CommentsTheWork = listRaitings.CommentsTheWork,
                       CountRaitingVoting = listRaitings.CountRaitingVoting,
                       DepthPossessionOf = listRaitings.DepthPossessionOf,
                       HowWellTheProcedurePerformedGrading = listRaitings.HowWellTheProcedurePerformedGrading,
                       InterestInTheSubject = listRaitings.InterestInTheSubject,
                       NumberOfAttendance = listRaitings.NumberOfAttendance,
                       OverallSubject = listRaitings.OverallSubject,
                       PreparationTime = listRaitings.PreparationTime,
                       ProcedureGrading = listRaitings.ProcedureGrading,
                       QualityMasteringTheSubject = listRaitings.QualityMasteringTheSubject,
                       QualityTeachingMaterials = listRaitings.QualityTeachingMaterials,
                       RelevantToStudents = listRaitings.RelevantToStudents,
                       SomethingNew = listRaitings.SomethingNew,
                       TheDifficultyOfTheCourse = listRaitings.TheDifficultyOfTheCourse,
                       ThePracticalValue = listRaitings.ThePracticalValue
                   };
            return View();
        }
    }
}