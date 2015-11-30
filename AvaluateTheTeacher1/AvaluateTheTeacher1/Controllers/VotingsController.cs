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

                var listId = db.Votings.ToList();

                foreach (var num in listId)
                {
                    int id = int.Parse(num.TeacherId.ToString());
                    double avgRelevant = 0, avgInterest = 0, avgQuality = 0, count = 0;
                    foreach (var voit in listId)
                    {
                        if (id == voit.TeacherId)
                        {
                            avgInterest += voit.Interest;
                            avgRelevant += voit.RelevantToStudents;
                            avgQuality += voit.Quality;
                            count++;
                        }
                    }
                    int countFind = 0;
                    foreach (var h in db.Ratings.ToList())
                    {
                        if (h.TeacherId.Equals(id))
                            countFind++;
                    }
                    if (countFind == 0)
                    {
                        var rait = new Rating { TeacherId = id };
                        db.Ratings.Add(rait);
                        db.SaveChanges();
                    }
                    var query = from ord in db.Ratings where ord.TeacherId == id select ord;
                    foreach (Rating rating in query)
                    {
                        rating.AvgInterest = float.Parse(Math.Round((avgInterest / count), 1).ToString());
                        rating.AvgQuality = float.Parse(Math.Round((avgQuality / count), 1).ToString());
                        rating.AvgRelevantToStudents = float.Parse(Math.Round((avgRelevant / count), 1).ToString());
                        rating.AvgRating = float.Parse(Math.Round(((avgInterest / count + avgQuality / count + avgRelevant / count) / 3), 1).ToString());
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}