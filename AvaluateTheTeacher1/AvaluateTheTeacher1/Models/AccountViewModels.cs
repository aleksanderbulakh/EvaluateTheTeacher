using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace AvaluateTheTeacher1.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Код")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Запомнить браузер?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Адреса електронної пошти")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Логін")]
        public string userName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Display(Name = "Запа'ятати мене")]
        public bool RememberMe { get; set; }
    }

    public class AddNewStudentViewModel
    {
        [Required]
        [StringLength(100, ErrorMessage = "Значення {0} повинне містити не менше {2} символів.", MinimumLength = 5)]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Логін повинен містити лише цифри та літери латинського алфавіту.")]
        [Display(Name = "Логін")]
        public string userName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значення {0} повинне містити не менше {2} символів.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Підтвердження пароля")]
        [Compare("Password", ErrorMessage = "Пароль та його підтвердження не збігаються.")]
        public string ConfirmPassword { get; set; }
        
        [Display(Name ="Група студента")]
        public int SelectedGroupId { get; set; } 
        
        public   System.Web.Mvc.SelectList Groups { get; set; }     
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Адрес электронной почты")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Значение {0} должно содержать не менее {2} символов.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Подтверждение пароля")]
        [Compare("Password", ErrorMessage = "Пароль и его подтверждение не совпадают.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Почта")]
        public string Email { get; set; }
    }

    public class AddNewGroupViewModel
    {        
        [Required]
        [Display(Name ="Назва групи")]
        [RegularExpression(@"[А-ЯІ]{2,3}-\d\d*", ErrorMessage = "Назва групи повинна містити лише великі букви та цифри.")]
        public string GroupName { get; set; }

        [Required]
        [RegularExpression(@"[123]?\d", ErrorMessage = "Число студентів повинно бути не більше 40.")]
        [Display(Name = "Кількість студентів")]
        public int CountOfStudent { get; set; }

    }

    public class AddNewTeacherViewModel
    {
        [Required]
        [RegularExpression(@"[А-ЯІЄЇ][а-яієї']+", ErrorMessage = "Некоректне ім'я (ім'я повинно починатись з великої літери та не містити пробілів чи цифр)")]
        [StringLength(20, MinimumLength = 4, ErrorMessage = "Длина строки должна быть от 4 до 20 символов")]
        [Display(Name = "Ім'я викладача:")]
        public string Name { get; set; }

        [Required]
        [RegularExpression(@"[А-ЯІЄЇ][а-яієї']+", ErrorMessage = "Некоректне прізвище (прізвище повинно починатись з великої літери та не містити пробілів чи цифр)")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 20 символов")]
        [Display(Name = "Прізвище викладача:")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"[А-ЯІЄЇ][а-яієї']+", ErrorMessage = "Некоректне ім'я по-батькові (воно повинно починатись з великої літери та не містити пробілів чи цифр)")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Длина строки должна быть от 5 до 20 символов")]
        [Display(Name = "По-батькові викладача:")]
        public string SurName { get; set; }

        
        [Display(Name = "Кафедра викладача")]
        public int SelectedCathedraId { get; set; }
                
        public System.Web.Mvc.SelectList Cathedras { get; set; }

        [Required]
        [Display(Name = "Характеристика викладач:")]
        public string Description { get; set; }

        [Required]
        [Display(Name="Фото")]
        public System.Web.HttpPostedFileBase Photo { get; set; }
    }
   
       
}
