﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AvaluateTheTeacher1.Models;
using System.Threading.Tasks;

namespace AvaluateTheTeacher1.Controllers
{
    public class AddingStudentController : AccountController
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: /Account/Register
        [Authorize(Roles = "admin")]
        public ActionResult AddNewStudent()
        {
            var teachModel = new AddNewStudentViewModel();
            teachModel.Groups = new SelectList(db.Groups, "GroupId", "Name", 1);
            
            ViewBag.Groups = db.Groups;
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [Authorize(Roles = "admin")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddNewStudent(AddNewStudentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var student = new ApplicationUser { UserName = model.userName };
                var result = await UserManager.CreateAsync(student, model.Password);
                if (result.Succeeded)
                {
                    await UserManager.AddToRoleAsync(student.Id, "student");

                    // Дополнительные сведения о том, как включить подтверждение учетной записи и сброс пароля, см. по адресу: http://go.microsoft.com/fwlink/?LinkID=320771
                    // Отправка сообщения электронной почты с этой ссылкой
                    // string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    // var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    // await UserManager.SendEmailAsync(user.Id, "Подтверждение учетной записи", "Подтвердите вашу учетную запись, щелкнув <a href=\"" + callbackUrl + "\">здесь</a>");

                    return RedirectToAction("Index", "Home");
                }
                AddErrors(result);
            }

            // Появление этого сообщения означает наличие ошибки; повторное отображение формы
            return RedirectToAction("Index", "Home");
        }
    }
}