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
using AvaluateTheTeacher1.CodeReview.Models;

namespace AvaluateTheTeacher1.Controllers
{

    public class ListOfTeachersController : Controller
    {
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

            var raitingModel = new RaitingModel();

            var raitingDataList = raitingModel.ListOfTeacherData(id);

            return View(raitingDataList);
        }
    }
}