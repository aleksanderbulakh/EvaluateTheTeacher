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
        //List<SelectListItem> Cathedras { get; set; }

        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ListOfTeachers
        public ActionResult ListOfTeachers()
        {
            var q =
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
            /*var cathedra = db.Cathedras.ToList();
            Cathedras = new List<SelectListItem>();
            foreach(var item in cathedra)
            {
                Cathedras.Add(new SelectListItem
                {
                    Text =item.NameCathedra,
                    Value =item.Id.ToString()
                });
            }
            ViewBag.CahtedrasList = Cathedras;*/
            return View(q.ToList());
        }

        /*[HttpGet]
        public ActionResult ListOfTeachers(int? CathedraId)
        {
            /*var q =
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
            var CathedraList = new CathedraList();
            CathedraList.Cathedras = new SelectList(db.Cathedras, "Id", "NameCathedra", 1);
            ViewBag.List = CathedraList;
            return View();
        }*/
    }
}