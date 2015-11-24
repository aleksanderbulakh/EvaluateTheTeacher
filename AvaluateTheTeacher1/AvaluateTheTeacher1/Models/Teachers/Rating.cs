using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Rating
    {
        public int Id { get; set; }
        public float ForTheEntirePeriod { get; set; }

        public float PreviousMonth { get; set; }

        public float AvgRating { get; set; }

        public float AvgInterest { get; set; }

        public float AvgQuality { get; set; }

        public float AvgRelevantToStudents { get; set; }

        public int TeacherId { get; set; }

        public Teacher Teacher { get; set; }
    }
}