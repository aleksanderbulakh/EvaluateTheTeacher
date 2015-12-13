using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class TopTeachersViewModel
    {
        public string Name { get; set; }

        public string SurName { get; set; }

        public string LastName { get; set; }

        public double Rating { get; set; }

        public string PathToPhoto { get; set; }
    }
}