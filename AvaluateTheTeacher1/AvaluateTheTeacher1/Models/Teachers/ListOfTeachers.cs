﻿using System;
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


        public List<Subject> Subjects { get; set; }
    }
}