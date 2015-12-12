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
            if(DateTime.Now.Day==1)
            {
                var query = from list in db.Ratings
                            select list;
                
                foreach(var data in query)
                {
                    var rait = db.Ratings.Where(x=>x.TeacherId==data.TeacherId);
                    foreach(var change in rait)
                    {
                        change.PreviousMonth = data.AvgRating;
                    }
                    db.SaveChanges();
                }
            }
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