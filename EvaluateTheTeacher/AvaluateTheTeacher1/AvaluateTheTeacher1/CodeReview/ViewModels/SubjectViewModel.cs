using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AvaluateTheTeacher1.CodeReview.ViewModels
{
    public class SubjectViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int CathedraId { get; set; }
                
        public List<AvaluateTheTeacher1.Models.Students.Semester> Semesters { get; set; }
    }

    public class SubjectDetailsViewModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Cathedra { get; set; }

        public List<AvaluateTheTeacher1.Models.Students.Semester> Semesters { get; set; }
    }
}