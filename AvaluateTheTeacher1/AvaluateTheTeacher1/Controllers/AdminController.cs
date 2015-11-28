using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;

namespace AvaluateTheTeacher1.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult Home()
        {

            return View();
        }

        public ActionResult ListOfUsers()
        {
            ViewBag.Students = db.Users;
            
            return View();
        }
    }
}