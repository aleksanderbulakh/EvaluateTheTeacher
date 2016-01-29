using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.CodeReview.ViewModels
{
    public class SubjectViewModel
    {
        public string Name { get; set; }

        public int CathedraId { get; set; }

        public List<AvaluateTheTeacher1.Models.Students.Semester> Semesters { get; set; }
    }
}