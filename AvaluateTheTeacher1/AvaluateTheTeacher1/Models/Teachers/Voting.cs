using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Voting
    {
        public int Id { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int OverallSubject { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int SomethingNew { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int ThePracticalValue { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int DepthPossessionOf { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int ClarityAndAccessibility { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int QualityTeachingMaterials { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int InterestInTheSubject { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int NumberOfAttendance { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int ActivityInClass { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int TheDifficultyOfTheCourse { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int PreparationTime { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int AvailabilityTeacherOutsideLessons { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int CommentsTheWork { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int RelevantToStudents { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int ProcedureGrading { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int HowWellTheProcedurePerformedGrading { get; set; }
        [Required]
        [RegularExpression(@"\d", ErrorMessage = "Виберіть значення.")]
        public int QualityMasteringTheSubject { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}