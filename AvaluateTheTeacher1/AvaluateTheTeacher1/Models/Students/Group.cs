using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace AvaluateTheTeacher1.Models.Students
{
    public class Group
    {
        public int GroupId { get; set; }
                
        public string Name { get; set; }  
        
        public virtual ICollection<ApplicationUser>  Users { get; set; }
        public virtual ICollection<Teachers.TeacherSubject> TeachersSubjects { get; set; }

        public Group()
        {
            Users = new List<ApplicationUser>();
            TeachersSubjects = new List<Teachers.TeacherSubject>();
        }    
    }
}