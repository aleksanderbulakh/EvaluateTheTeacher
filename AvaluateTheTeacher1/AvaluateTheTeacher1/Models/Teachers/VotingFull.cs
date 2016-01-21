using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class VotingFull 
    {
        public int idTeacher { get; set; }
        public string teacherName { get; set; }
        public string pathToPhoto { get; set; }

        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int OverallSubject { get; set; }//оцінка курсу
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int SomethingNew { get; set; }//чи дізнались щось нове
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int ThePracticalValue { get; set; }//практична ціність курсу
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int DepthPossessionOf { get; set; }//володіння викладачем матеріалом
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int ClarityAndAccessibility { get; set; }//зрозумілість та доступність матеріалу
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int QualityTeachingMaterials { get; set; }//якість навчальних матеріалів
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int InterestInTheSubject { get; set; }//зацікавленість предметом
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int NumberOfAttendance { get; set; }//кількість відвіданих занять
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int ActivityInClass { get; set; }//активність на заняттях
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int TheDifficultyOfTheCourse { get; set; }//складність курсу
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int PreparationTime { get; set; }//час для підготовки
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int AvailabilityTeacherOutsideLessons { get; set; }//доступність викладача
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int CommentsTheWork { get; set; }//зворотній зв'язок та коментарі
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int RelevantToStudents { get; set; }//предвзятість викладача
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int ProcedureGrading { get; set; }//зрозумілість процедури оцінки
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int HowWellTheProcedurePerformedGrading { get; set; }//виконання заявленої процедури оцінки
        [Required(ErrorMessage = "Виберіть значення.")]
        [Range(1, 10, ErrorMessage = "Виберіть значення.")]
        public int QualityMasteringTheSubject { get; set; }//засвоєння курсу
        public string Suggestions { get; set; }
    }
}