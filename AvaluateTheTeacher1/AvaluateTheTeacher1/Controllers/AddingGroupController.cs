using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;

namespace AvaluateTheTeacher1.Controllers
{
    public class AddingGroupController : AccountController
    {
        public ApplicationDbContext db = new ApplicationDbContext();

        // GET: AddingGroup
        [Authorize(Roles ="admin")]
        public ActionResult AddNewGroup()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async System.Threading.Tasks.Task<ActionResult> AddNewGroup(AddNewGroupViewModel model)
        {
            if (ModelState.IsValid)
            {
                var group = new Models.Students.Group();
                group.Name = model.GroupName;
                db.Groups.Add(group);
                db.SaveChanges();
                int n;
                string password = "", s1, st;
                st = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                Random rnd = new Random();

                for (int index = 0; index < model.CountOfStudent; index++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        n = rnd.Next(0, 61);
                        Guid.NewGuid();
                        s1 = st.Substring(n, 1);
                        password += s1;
                    }

                    var student = new ApplicationUser { UserName = model.GroupName + "_" + index, GroupId = group.GroupId };
                    var result = await UserManager.CreateAsync(student, password);
                    if (result.Succeeded)
                    {
                       
                        await UserManager.AddToRoleAsync(student.Id, "student");
                                               
                    }
                    AddErrors(result);                   
                    password = "";

                }
                return RedirectToAction("Index", "Home");
            }


            return View(model);
        }
    }
}