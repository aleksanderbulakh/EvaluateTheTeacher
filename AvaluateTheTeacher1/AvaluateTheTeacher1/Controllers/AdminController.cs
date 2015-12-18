using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Students;

namespace AvaluateTheTeacher1.Controllers
{
    public class AdminController : Controller
    {
        private IQueryable<ListOfUsers> query { get; set; }
        // GET: Admin
        ApplicationDbContext db = new ApplicationDbContext();

        [Authorize(Roles = "admin")]
        public ActionResult Home()
        {

            return View();
        }

        [Authorize(Roles = "admin")]
        public ActionResult ListOfUsers(FilterUser model)
        {
            //ViewBag.Students = db.Users;
            if (model.SelectedId == null || model.SelectedId == 0)
            {
                query = from listGroup in db.Groups 
                        from list in db.Users
                        select new ListOfUsers()
                        {
                            UserName = list.UserName,
                            Password = list.PasswordTxt
                        };
            }
            else
            {
                query = from listGroup in db.Groups
                        from list in db.Users
                        .Where(x => (x.GroupId == listGroup.GroupId))
                        select new ListOfUsers()
                        {
                            UserName = list.UserName,
                            Password = list.PasswordTxt
                        };
            }
            List<Group> group = db.Groups.ToList();
            group.Insert(0, new Group { GroupId = 0, Name = "All" });
            var data = new FilterUser
            {
                List = query.ToList(),
                Group = new SelectList(group, "GroupId", "Name")
            };
            return View(data);
        }
    }
}