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

namespace AvaluateTheTeacher1.Controllers
{
    public class RaitingController : AccountController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: Raiting
        [Authorize(Roles = "student")]
        public async System.Threading.Tasks.Task<ActionResult> VoitingMain()
        {
            var student = await UserManager.FindByNameAsync(User.Identity.Name);
            
            var Group = db.Groups.Where(n => n.GroupId == student.GroupId).ToList();
            var listS = new List<int>();
            foreach (var s in Group)
            {
                foreach (var st in s.TeachersSubjects)
                {
                    listS.Add(st.Id);
                }
            }
            var query = from listTeacher in db.Teachers
                    from listRaiting in db.RaitingTeacherSubject
                    from listSubject in db.Subjects
                    from listTeachersSubject in db.TeacherSubject
                    .Where(listTeachersSubj => (listS.Contains(listTeachersSubj.Id) && listTeachersSubj.Id == listRaiting.TeacherSubjectId && listSubject.Id==listTeachersSubj.SubjectId && listTeacher.TeacherId== listTeachersSubj.TeacherId))
                    orderby listRaiting.AvgRating descending 
                    select new ListOfTeachers()
                    {
                        TeacherId = listTeacher.TeacherId,
                        Name = listTeacher.Name,
                        SurName = listTeacher.SurName,
                        LastName = listTeacher.LastName,
                        PathToPhoto = listTeacher.PathToPhoto,
                        Description = listTeacher.Description,
                        ForTheEntirePeriod = listRaiting.ForTheEntirePeriod,
                        PreviousMonth = listRaiting.PreviousMonth,
                        AvgRating = listRaiting.AvgRating,
                        IdForVoiting = listTeachersSubject.Id,
                        SubjectName = listSubject.Name
                    };
            var data = new VotingList
            {
                Info=query.ToList()
            };
            return View(data);
        }
    }
}