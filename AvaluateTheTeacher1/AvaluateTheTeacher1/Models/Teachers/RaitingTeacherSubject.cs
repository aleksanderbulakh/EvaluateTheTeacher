using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class RaitingTeacherSubject
    {
        public int Id { get; set; }
        public float ForTheEntirePeriod { get; set; }
        public float PreviousMonth { get; set; }
        public float AvgRating { get; set; }
        public float OverallSubject { get; set; }
        public float SomethingNew { get; set; }
        public float ThePracticalValue { get; set; }
        public float DepthPossessionOf { get; set; }
        public float ClarityAndAccessibility { get; set; }
        public float QualityTeachingMaterials { get; set; }
        public float InterestInTheSubject { get; set; }
        public float NumberOfAttendance { get; set; }
        public float ActivityInClass { get; set; }
        public float TheDifficultyOfTheCourse { get; set; }
        public float PreparationTime { get; set; }
        public float AvailabilityTeacherOutsideLessons { get; set; }
        public float CommentsTheWork { get; set; }
        public float RelevantToStudents { get; set; }
        public float ProcedureGrading { get; set; }
        public float HowWellTheProcedurePerformedGrading { get; set; }
        public float QualityMasteringTheSubject { get; set; }
        public int CountVoting { get; set; }

        public int? TeacherSubjectId { get; set; }

        public TeacherSubject TeacherSubject { get; set; }
    }
}