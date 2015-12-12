using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class ListOfTeachers 
    {
        public string NameCathedra { get; set; }
        public int TeacherId { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string LastName { get; set; }
        public string PathToPhoto { get; set; }
        public string Description { get; set; }
        public float ForTheEntirePeriod { get; set; }
        public float PreviousMonth { get; set; }
        public float AvgRating { get; set; }
        public List<Subject> Subjects { get; set; }
    }
}