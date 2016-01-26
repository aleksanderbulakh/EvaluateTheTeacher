using System.Web.Mvc;
using AvaluateTheTeacher1.CodeReview.Models;
using AvaluateTheTeacher1.CodeReview.ViewModels;
using System.Collections.Generic;
using AvaluateTheTeacher1.Models.Teachers;
using AvaluateTheTeacher1.Models.Students;
using AvaluateTheTeacher1.Models;
using System.Linq;
using System;

namespace AvaluateTheTeacher1.Controllers
{
    public class VotingsController : AccountController
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Votings
        [Authorize(Roles = "student")]
        public async System.Threading.Tasks.Task<ActionResult> Votings(int? id)
        {
            var votingControle = new VotingModel();

            var studentData = await UserManager.FindByNameAsync(User.Identity.Name);

            if (votingControle.CheckVote(int.Parse(id.ToString()), studentData))
                return RedirectToAction("TimeOut");

            if (id == null)
                return HttpNotFound();

            var info = votingControle.Voiting(int.Parse(id.ToString()), studentData.GroupId, studentData.Id);

            return View(info);
        }

        [HttpPost]
        [Authorize(Roles = "student")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> Votings(VotingViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var votingControle = new VotingModel();

            var studentData = await UserManager.FindByNameAsync(User.Identity.Name);

            if (votingControle.CheckVote(model.idTeacher, studentData))
                return RedirectToAction("TimeOut");

            votingControle.FixVoting(int.Parse(model.idTeacher.ToString()), studentData);

            votingControle.CalculateVotings(model);

            return RedirectToAction("VoitingMain", "Raiting");
        }

        public ActionResult TimeOut()
        {
            return View();
        }
    }
}