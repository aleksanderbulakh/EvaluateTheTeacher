using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Controllers
{
    public class VotingsController : Controller
    {
        private static int TeacherIdInController;

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Votings
        public ActionResult Votings(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            
            TeacherIdInController = Int32.Parse(id.ToString());
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Votings(Voting model)
        {
            if (ModelState.IsValid)
            {
                var voting = new Models.Teachers.Voting();
                voting.Interest = model.Interest;
                voting.Quality = model.Quality;
                voting.RelevantToStudents = model.RelevantToStudents;
                voting.TeacherId = TeacherIdInController;

                db.Votings.Add(voting);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
    }
}