using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Controllers
{
    public class ListOfTeachersController : Controller
    {
        private int? SelectedCathedraId { get; set; }
        private IQueryable<ListOfTeachers> query { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ListOfTeachers

        [HttpGet]
        public ActionResult ListOfTeachers(FilterDataModel model)
        {
            if(model.SelectedId == null || model.SelectedId == 0)
            {
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && (listTeachers1.CathedraId == listCathedras.Id))
                    orderby listRaitings.AvgRating descending
                    select new ListOfTeachers()
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
                        AvgInterest = listRaitings.AvgRating,
                        AvgQuality = listRaitings.AvgQuality,
                        AvgRelevantToStudents = listRaitings.AvgRelevantToStudents
                    };
            }
            else
            {
                SelectedCathedraId = model.SelectedId;
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && ((listTeachers1.CathedraId == SelectedCathedraId) && (listTeachers1.CathedraId == listCathedras.Id)))
                    orderby listRaitings.AvgRating descending
                    select new ListOfTeachers()
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
                        AvgInterest = listRaitings.AvgRating,
                        AvgQuality = listRaitings.AvgQuality,
                        AvgRelevantToStudents = listRaitings.AvgRelevantToStudents
                    };
            }
            List<Cathedra> cathedra = db.Cathedras.ToList();
            cathedra.Insert(0, new Cathedra { NameCathedra = "Всі", Id = 0 });
            FilterDataModel data = new FilterDataModel
            {
                Teachers = query.ToList(),
                Cathedras=new SelectList(cathedra, "Id", "NameCathedra")
            };
            return View(data);
        }
    }
}