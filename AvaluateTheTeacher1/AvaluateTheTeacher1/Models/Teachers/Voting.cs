using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class Voting
    {
        public int Id { get; set; }
        public int OverallSubject { get; set; }
        public int SomethingNew { get; set; }
        public int ThePracticalValue { get; set; }
        public int DepthPossessionOf { get; set; }
        public int ClarityAndAccessibility { get; set; }
        public int QualityTeachingMaterials { get; set; }
        public int InterestInTheSubject { get; set; }
        public int NumberOfAttendance { get; set; }
        public int ActivityInClass { get; set; }
        public int TheDifficultyOfTheCourse { get; set; }
        public int PreparationTime { get; set; }
        public int AvailabilityTeacherOutsideLessons { get; set; }
        public int CommentsTheWork { get; set; }
        public int RelevantToStudents { get; set; }
        public int ProcedureGrading { get; set; }
        public int HowWellTheProcedurePerformedGrading { get; set; }
        public int QualityMasteringTheSubject { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
    }
}