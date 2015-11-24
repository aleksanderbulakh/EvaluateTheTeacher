using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Voting
    {
        public int Id { get; set; }

        public float Interest { get; set; }

        public float Quality { get; set; }

        public float RelevantToStudents { get; set; }

        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        
    }
}