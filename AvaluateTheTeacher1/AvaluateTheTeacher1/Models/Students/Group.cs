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
        
        public ICollection<ApplicationUser>  Users { get; set; }

        
        public ICollection<Teachers.Teacher> Teachers { get; set; }
        public Group()
        {
            Users = new List<ApplicationUser>();
            Teachers = new List<Teachers.Teacher>();
        }    
    }
}