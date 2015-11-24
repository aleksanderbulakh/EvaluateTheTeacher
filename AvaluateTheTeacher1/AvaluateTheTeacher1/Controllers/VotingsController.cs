using AvaluateTheTeacher1.Models;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Controllers
{
    public class VotingsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Votings
        public ActionResult Votings()
        {
            var votings = db.Votings.Include(v => v.Teacher).Include(t=>t.Teacher.Cathedra.NameCathedra);
            return View(votings.ToList());
        }
    }
}