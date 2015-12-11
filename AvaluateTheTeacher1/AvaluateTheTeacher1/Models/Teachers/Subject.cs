using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Subject
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int CathedraId { get; set; }

        public Cathedra Cathedra { get; set; }

        public virtual ICollection<TeacherSubject> TeachersSubjects { get; set; }
        

        public Subject()
        {
            TeachersSubjects = new List<TeacherSubject>();
        }
    }
}