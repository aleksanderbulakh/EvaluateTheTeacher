using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Net;
using System.Web.Mvc;
using System.Drawing;
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
        public ActionResult ListOfTeachers(int? id)
        {
            //var teachers = db.Teachers;
            //foreach (var t in teachers)
            //{
            //    string path = AppDomain.CurrentDomain.BaseDirectory + "TeacherImg/";
            //    System.Drawing.Image oImage = System.Drawing.Image.FromFile(path + t.PathToPhoto);

            //    int sizeImg;
            //    if (oImage.Width > oImage.Height)
            //    {
            //        sizeImg = oImage.Height-20;
            //    }
            //    else
            //    {
            //        sizeImg = oImage.Width-20;
            //    }   

            //    var bmp = new System.Drawing.Bitmap(sizeImg, sizeImg, oImage.PixelFormat);
            //    var g = System.Drawing.Graphics.FromImage(bmp);                

            //    g.DrawImage(oImage, new Rectangle(0, 0, sizeImg, sizeImg), new Rectangle(0, 20, sizeImg, sizeImg), GraphicsUnit.Pixel);

            //    System.Drawing.Imaging.ImageFormat frm = oImage.RawFormat;
            //    oImage.Dispose();

            //    path = AppDomain.CurrentDomain.BaseDirectory + "TeacherAva/";
            //    string destFile = System.IO.Path.Combine(path, t.PathToPhoto);

            //    bmp.Save(destFile, frm);
            //}

            if (id == 0 || id == null)
            {
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && (listTeachers1.CathedraId == listCathedras.Id) && (listRaitings.AvgRating != 0))
                    orderby listRaitings.AvgRating descending, listRaitings.CountRaitingVoting descending, listRaitings.TheDifficultyOfTheCourse descending
                    select new ListOfTeachers()
                    {
                        TeacherId = listTeachers.TeacherId,
                        NameCathedra = listCathedras.NameCathedra,
                        Name = listTeachers.Name.Substring(0, 1),
                        SurName = listTeachers.SurName.Substring(0, 1),
                        LastName = listTeachers.LastName,
                        PathToPhoto = listTeachers.PathToPhoto,
                        Description = listTeachers.Description,
                        ForTheEntirePeriod = listRaitings.ForTheEntirePeriod,
                        PreviousMonth = listRaitings.PreviousMonth,
                        AvgRating = listRaitings.AvgRating,
                        Count = listRaitings.CountRaitingVoting,
                        TheDifficultyOfTheCourse = listRaitings.TheDifficultyOfTheCourse
                    };
            }
            else
            {
                SelectedCathedraId = id;
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && ((listTeachers1.CathedraId == SelectedCathedraId) && (listTeachers1.CathedraId == listCathedras.Id) && (listRaitings.AvgRating != 0)))
                    orderby listRaitings.AvgRating descending, listRaitings.CountRaitingVoting descending, listRaitings.TheDifficultyOfTheCourse descending
                    select new ListOfTeachers()
                    {
                        TeacherId = listTeachers.TeacherId,
                        NameCathedra = listCathedras.NameCathedra,
                        Name = listTeachers.Name.Substring(0, 1),
                        SurName = listTeachers.SurName.Substring(0, 1),
                        LastName = listTeachers.LastName,
                        PathToPhoto = listTeachers.PathToPhoto,
                        Description = listTeachers.Description,
                        ForTheEntirePeriod = listRaitings.ForTheEntirePeriod,
                        PreviousMonth = listRaitings.PreviousMonth,
                        AvgRating = listRaitings.AvgRating,
                        Count = listRaitings.CountRaitingVoting,
                        TheDifficultyOfTheCourse = listRaitings.TheDifficultyOfTheCourse
                    };
            }
            List<Cathedra> cathedra = db.Cathedras.ToList();
            cathedra.Insert(0, new Cathedra { NameCathedra = "Всі кафедри", Id = 0 });
            FilterDataModel data = new FilterDataModel
            {
                Teachers = query.ToList(),
                Cathedras = cathedra
            };

            return View(data);
        }
    }
}