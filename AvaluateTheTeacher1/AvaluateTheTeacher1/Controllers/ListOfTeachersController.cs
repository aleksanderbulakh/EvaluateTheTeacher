using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;

namespace AvaluateTheTeacher1.Controllers
{
    public class ListOfTeachersController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: ListOfTeachers
        public ActionResult ListOfTeachers()
        {
            ViewBag.Teachers = db.Teachers;
            return View();
        }
    }
}