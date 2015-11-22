using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Cathedra
    {
        public int Id { get; set; }
        
        public string NameCathedra { get; set; }

        public ICollection<Teacher> Teachers { get; set; }
        public ICollection<Subject> Subjects { get; set; }
        public Cathedra()
        {
            Teachers = new List<Teacher>();
            Subjects = new List<Subject>();
        }
             
    }
}