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
        [RegularExpression(@"[2-5]", ErrorMessage = "Оцінка має бути в межах від 2-ці до 5-ки.")]
        public float Interest { get; set; }

        [Required]
        [RegularExpression(@"[2-5]", ErrorMessage = "Оцінка має бути в межах від 2-ці до 5-ки.")]
        public float Quality { get; set; }

        [Required]
        [RegularExpression(@"[2-5]", ErrorMessage = "Оцінка має бути в межах від 2-ці до 5-ки.")]
        public float RelevantToStudents { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        
    }
}