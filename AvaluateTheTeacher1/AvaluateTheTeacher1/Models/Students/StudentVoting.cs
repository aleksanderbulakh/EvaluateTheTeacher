using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Students
{
    public class StudentVoting
    {
        public int Id { get; set; }
        
        public string StudentId { get; set; }        
        public ApplicationUser Student { get; set; }

        public int? TeachersSubjectId { get; set; }
        public Teachers.TeacherSubject TeachersSubjects { get; set; }

        public DateTime Date { get; set; }
    }
}