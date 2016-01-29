using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.CodeReview.ViewModels
{
    public class SubjectEditViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CathedraId { get; set; }

        public List<SemesterForSubject> Semesters { get; set; }
    }

    public class SemesterForSubject
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsChange { get; set; }
    }
}