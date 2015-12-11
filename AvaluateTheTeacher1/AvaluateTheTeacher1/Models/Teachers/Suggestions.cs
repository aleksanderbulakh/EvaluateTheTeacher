using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Suggestions
    {
        public int Id { get; set; }
        public string SuggestionsForImprovement { get; set; }
        public int? TeacherSubjectId { get; set; }
        public TeacherSubject TeacherSubject { get; set; }
    }
}