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

        public virtual ICollection<Teachers.Teacher> Teachers { get; set; }

        public virtual ICollection<Teachers.Subject> Subjects { get; set; }
        public Group()
        {
            Users = new List<ApplicationUser>();
            Teachers = new List<Teachers.Teacher>();
            Subjects = new List<Teachers.Subject>();
        }    
    }
}