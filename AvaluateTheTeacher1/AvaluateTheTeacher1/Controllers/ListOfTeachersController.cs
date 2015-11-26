using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Net;
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
            
            var teachers = db.Teachers.Include(t => t.Cathedra).Include(c=>c.Ratings).ToList();
            return View(teachers);
        }
    }
}