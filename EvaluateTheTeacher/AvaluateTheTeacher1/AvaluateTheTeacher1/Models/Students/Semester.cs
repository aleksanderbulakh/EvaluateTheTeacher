using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AvaluateTheTeacher1.Models.Teachers;

namespace AvaluateTheTeacher1.Models.Students
{
    public class Semester
    {
        public int Id { get; set; }
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public bool IsVote { get; set; }
        public int SemesterId { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<TeacherSubject> TeacherSubjects { get; set; }

        public Semester()
        {
            Subjects = new List<Subject>();
            TeacherSubjects = new List<TeacherSubject>();
        }
    }
}