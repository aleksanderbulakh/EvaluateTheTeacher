using System.Web.Mvc;
using AvaluateTheTeacher1.CodeReview.Models;
using AvaluateTheTeacher1.CodeReview.ViewModels;
using AvaluateTheTeacher1.Models.Students;
using System.Collections.Generic;
using AvaluateTheTeacher1.Models;
using System.Linq;
using System;
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Controllers
{
    public class VotingsController : AccountController
    {
        // GET: Votings
        [Authorize(Roles = "student")]
        public async System.Threading.Tasks.Task<ActionResult> Votings(int? id)
        {
            var votingControle = new VotingModel();

            var studentData = await UserManager.FindByNameAsync(User.Identity.Name);

            if (votingControle.CheckVote(int.Parse(id.ToString()), studentData))
                return RedirectToRoute("VoteAccepted");

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
                return RedirectToRoute("VoteAccepted");

            votingControle.FixVoting(int.Parse(model.idTeacher.ToString()), studentData);

            votingControle.CalculateVotings(model);

            //--------------------------------------------------------------
            using (var db = new ApplicationDbContext())
            {
                var Group = db.Groups.Where(n => n.GroupId == studentData.GroupId).ToList();
                var listS = new List<int>();
                foreach (var s in Group)
                {
                    foreach (var st in s.TeachersSubjects)
                    {
                        listS.Add(st.Id);
                    }
                }

                var queryTeacherList = from listTeacher in db.Teachers
                                       from listRaiting in db.Ratings
                                       from listSubject in db.Subjects
                                       from listTeachersSubject in db.TeacherSubject
                                       .Where(listTeachersSubj => (listS.Contains(listTeachersSubj.Id) && listSubject.Id == listTeachersSubj.SubjectId && listTeacher.TeacherId == listTeachersSubj.TeacherId && listRaiting.TeacherId == listTeacher.TeacherId))
                                       orderby listRaiting.AvgRating descending
                                       select new ListOfTeachers()
                                       {
                                           TeacherId = listTeacher.TeacherId,
                                           Name = listTeacher.Name,
                                           SurName = listTeacher.SurName,
                                           LastName = listTeacher.LastName,
                                           PathToPhoto = listTeacher.PathToPhoto,
                                           Description = listTeacher.Description,
                                           AvgRating = listRaiting.AvgRating,
                                           IdForVoiting = listTeachersSubject.Id,
                                           SubjectName = listSubject.Name
                                       };
                IEnumerable<StudentVoting> votingUserList = db.StudentVotings.Where(m => m.StudentId == studentData.Id && m.Date.Month == DateTime.Now.Month);
                var teacherVote = new List<int>();
                foreach (var votingUserData in votingUserList)
                {
                    teacherVote.Add(int.Parse(votingUserData.TeachersSubjectId.ToString()));
                }
                foreach (var teacherData in queryTeacherList)
                {
                    if (!teacherVote.Contains(teacherData.IdForVoiting))
                        return RedirectToRoute("Votings", new { id = teacherData.IdForVoiting });
                }

                
                return RedirectToAction("VoitingMain", "Raiting");
            }
        }

        public ActionResult VoteAccepted()
        {
            return View();
        }
    }
}