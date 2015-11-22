using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Teacher
    {
        public int TeacherId { get; set; }

        public string Name { get; set; }

        public string SurName { get; set; }

        public string LastName { get; set; }

        public float ForTheEntirePeriod { get; set; }

        public float PreviousMonth { get; set; }

        public float AvgRating { get; set; }

        public float AvgInterest { get; set; }

        public float AvgQuality { get; set; }

        public float AvgRelevantToStudents { get; set; }

        public string PathToPhoto { get; set; }

        public string Description { get; set; }

        public int?  CathedraId { get; set; }

        public Cathedra Cathedra { get; set; }

        public ICollection<Subject> Subjects { get; set; }
        public ICollection<Voting> Votes { get; set; }
        public Teacher()
        {
            Subjects = new List<Subject>();
            Votes = new List<Voting>();
        }
    }
}