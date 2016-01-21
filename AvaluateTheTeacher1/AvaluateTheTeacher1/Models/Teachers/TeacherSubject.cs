using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class TeacherSubject
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teachers { get; set; }
        public int? SubjectId { get; set; }
        public Subject Subjects { get; set; }
        public virtual ICollection<Students.Group> Groups { get; set; }
        public virtual ICollection<Students.StudentVoting> StudentVoting { get; set; }
        public virtual ICollection<Voting> Votings { get; set; }
        public virtual ICollection<RaitingTeacherSubject> RaitingTeacherSubject { get; set; }

        public TeacherSubject()
        {
            StudentVoting = new List<Students.StudentVoting>();
            Votings = new List<Voting>();
            RaitingTeacherSubject = new List<RaitingTeacherSubject>();
        }
    }
}