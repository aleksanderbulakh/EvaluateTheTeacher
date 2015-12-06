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

        public int? TeacherId { get; set; }
        public Teachers.Teacher Teacher { get; set; }

        public DateTime Date { get; set; }
    }
}