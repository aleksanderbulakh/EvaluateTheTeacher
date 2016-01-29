using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.Entity;
using System.Net;
using AvaluateTheTeacher1.CodeReview.Models;

namespace AvaluateTheTeacher1.Controllers
{
    
    public class RaitingController : AccountController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Raiting
        [Authorize(Roles = "student")]
        public async System.Threading.Tasks.Task<ActionResult> VoitingMain()
        {
            if (User.IsInRole("admin"))
                return RedirectToAction("Home", "Admin");

            var student = await UserManager.FindByNameAsync(User.Identity.Name);

            var data = new VotingModel();

            var info = data.InfoForRaitingList(student.GroupId);

            return View(info);
        }
    }
}