using AvaluateTheTeacher1.Controllers;
using AvaluateTheTeacher1.Models.Students;
using AvaluateTheTeacher1.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.Models
{
    public static class RaitingInfo
    {
        public static VotingList RaitingList(ApplicationDbContext db, ApplicationUser student)
        {
            var Group = db.Groups.Where(n => n.GroupId == student.GroupId).ToList();
            var listS = new List<int>();
            foreach (var s in Group)
            {
                foreach (var st in s.TeachersSubjects)
                {
                    listS.Add(st.Id);
                }
            }

            var query = from listTeacher in db.Teachers
                        from listRaiting in db.RaitingTeacherSubject
                        from listSubject in db.Subjects
                        from listTeachersSubject in db.TeacherSubject
                        .Where(listTeachersSubj => (listS.Contains(listTeachersSubj.Id) && listTeachersSubj.Id == listRaiting.TeacherSubjectId && listSubject.Id == listTeachersSubj.SubjectId && listTeacher.TeacherId == listTeachersSubj.TeacherId))
                        orderby listRaiting.AvgRating descending
                        select new ListOfTeachers()
                        {
                            TeacherId = listTeacher.TeacherId,
                            Name = listTeacher.Name,
                            SurName = listTeacher.SurName,
                            LastName = listTeacher.LastName,
                            PathToPhoto = listTeacher.PathToPhoto,
                            Description = listTeacher.Description,
                            ForTheEntirePeriod = listRaiting.ForTheEntirePeriod,
                            PreviousMonth = listRaiting.PreviousMonth,
                            AvgRating = listRaiting.AvgRating,
                            IdForVoiting = listTeachersSubject.Id,
                            SubjectName = listSubject.Name
                        };
            var data = new VotingList
            {
                Info = query.ToList()
            };
            return data;
        }
        public static bool IsVoting(ApplicationDbContext db, ApplicationUser student, int? id)
        {
            var listStudentVotings = db.StudentVotings.Where(m => m.TeachersSubjectId == id && m.StudentId == student.Id).ToList();
            if (listStudentVotings != null)
            {
                foreach (var stVt in listStudentVotings)
                {
                    if (stVt.Date.Month == DateTime.Now.Month) return true;
                }
            }
            return false;
        }
        public static List<string> MinInfoAboutTeacher(ApplicationDbContext db, int? id)
        {
            int TSIdInController = Int32.Parse(id.ToString());
            var query = (from listTeachers in db.Teachers
                         from listTeacherSubject in db.TeacherSubject
                        .Where(list => list.Id == TSIdInController && list.TeacherId == listTeachers.TeacherId)
                         select listTeachers).ToList();
            var minInfo = new List<string>();
            minInfo.Add(query[0].Name.ToString() + " " + query[0].SurName.ToString() + " " + query[0].LastName.ToString());
            minInfo.Add(query[0].PathToPhoto);
            return minInfo;
        }
        public static void NewVoting(VotingFull model, int TSIdInController, ApplicationDbContext db)
        {
            var voting = new Voting
            {
                ActivityInClass = model.ActivityInClass,
                AvailabilityTeacherOutsideLessons = model.AvailabilityTeacherOutsideLessons,
                ClarityAndAccessibility = model.ClarityAndAccessibility,
                CommentsTheWork = model.CommentsTheWork,
                DepthPossessionOf = model.DepthPossessionOf,
                HowWellTheProcedurePerformedGrading = model.HowWellTheProcedurePerformedGrading,
                InterestInTheSubject = model.InterestInTheSubject,
                NumberOfAttendance = model.NumberOfAttendance,
                OverallSubject = model.OverallSubject,
                PreparationTime = model.PreparationTime,
                ProcedureGrading = model.ProcedureGrading,
                QualityMasteringTheSubject = model.QualityMasteringTheSubject,
                QualityTeachingMaterials = model.QualityTeachingMaterials,
                RelevantToStudents = model.RelevantToStudents,
                SomethingNew = model.SomethingNew,
                TheDifficultyOfTheCourse = model.TheDifficultyOfTheCourse,
                ThePracticalValue = model.ThePracticalValue,
                TeacherSubjectId = TSIdInController
            };
            db.Votings.Add(voting);
            db.SaveChanges();
        }
        public static void FixVoting(ApplicationUser student, int TSIdInController, ApplicationDbContext db)
        {
            var StVoting = new StudentVoting
            {
                Date = DateTime.Now.Date,
                StudentId=student.Id,
                TeachersSubjectId=TSIdInController
            };
            db.StudentVotings.Add(StVoting);
            db.SaveChanges();
        }
        public static void UpdateRaitingTeacherSubject(ApplicationDbContext db, int TSIdInController)
        {
            double[] SumRaitingTS = AvgRaitingTS(db, TSIdInController);
            int count = Int32.Parse(SumRaitingTS[18].ToString());
            //-------------------4
            var raitTeachSubj = db.RaitingTeacherSubject.Where(x => x.TeacherSubjectId == TSIdInController).ToList();
            foreach (var rating in raitTeachSubj)
            {
                rating.ActivityInClass = float.Parse(Math.Round(SumRaitingTS[0]/count, 1).ToString());
                rating.AvailabilityTeacherOutsideLessons = float.Parse(Math.Round(SumRaitingTS[1] / count, 1).ToString());
                rating.ClarityAndAccessibility = float.Parse(Math.Round(SumRaitingTS[2] / count, 1).ToString());
                rating.CommentsTheWork = float.Parse(Math.Round(SumRaitingTS[3] / count, 1).ToString());
                rating.DepthPossessionOf = float.Parse(Math.Round(SumRaitingTS[4] / count, 1).ToString());
                rating.HowWellTheProcedurePerformedGrading = float.Parse(Math.Round(SumRaitingTS[5] / count, 1).ToString());
                rating.InterestInTheSubject = float.Parse(Math.Round(SumRaitingTS[6] / count, 1).ToString());
                rating.NumberOfAttendance = float.Parse(Math.Round(SumRaitingTS[7] / count, 1).ToString());
                rating.OverallSubject = float.Parse(Math.Round(SumRaitingTS[8] / count, 1).ToString());
                rating.PreparationTime = float.Parse(Math.Round(SumRaitingTS[9] / count, 1).ToString());
                rating.ProcedureGrading = float.Parse(Math.Round(SumRaitingTS[10] / count, 1).ToString());
                rating.QualityMasteringTheSubject = float.Parse(Math.Round(SumRaitingTS[11] / count, 1).ToString());
                rating.QualityTeachingMaterials = float.Parse(Math.Round(SumRaitingTS[12] / count, 1).ToString());
                rating.RelevantToStudents = float.Parse(Math.Round(SumRaitingTS[13] / count, 1).ToString());
                rating.SomethingNew = float.Parse(Math.Round(SumRaitingTS[14] / count, 1).ToString());
                rating.TheDifficultyOfTheCourse = float.Parse(Math.Round(SumRaitingTS[15] / count, 1).ToString());
                rating.ThePracticalValue = float.Parse(Math.Round(SumRaitingTS[16] / count, 1).ToString());
                rating.RelevantToStudents = float.Parse(Math.Round(SumRaitingTS[17] / count, 1).ToString());
                rating.AvgRating = float.Parse((AvgRaiting(rating)).ToString());
                rating.CountVoting = count;
            }
            db.SaveChanges();
        }
        private static double[] AvgRaitingTS(ApplicationDbContext db, int TSIdInController)
        {
            var listId = db.Votings.Where(x => x.TeacherSubjectId == TSIdInController).ToList();
            double[] SumRaiting = new double[19];
            Array.Clear(SumRaiting, 0, 19);
            foreach (var voit in listId)
            {
                SumRaiting[0] += voit.ActivityInClass;
                SumRaiting[1] += voit.AvailabilityTeacherOutsideLessons;
                SumRaiting[2] += voit.ClarityAndAccessibility;
                SumRaiting[3] += voit.CommentsTheWork;
                SumRaiting[4] += voit.DepthPossessionOf;
                SumRaiting[5] += voit.HowWellTheProcedurePerformedGrading;
                SumRaiting[6] += voit.InterestInTheSubject;
                SumRaiting[7] += voit.NumberOfAttendance;
                SumRaiting[8] += voit.OverallSubject;
                SumRaiting[9] += voit.PreparationTime;
                SumRaiting[10] += voit.ProcedureGrading;
                SumRaiting[11] += voit.QualityMasteringTheSubject;
                SumRaiting[12] += voit.QualityTeachingMaterials;
                SumRaiting[13] += voit.RelevantToStudents;
                SumRaiting[14] += voit.SomethingNew;
                SumRaiting[15] += voit.TheDifficultyOfTheCourse;
                SumRaiting[16] += voit.ThePracticalValue;
                SumRaiting[17] += voit.RelevantToStudents;
                SumRaiting[18]++;
            }
            return SumRaiting;
        }
        private static double AvgRaiting(RaitingTeacherSubject rating)
        {
            return Math.Round(((rating.ActivityInClass + rating.AvailabilityTeacherOutsideLessons + rating.ClarityAndAccessibility + rating.CommentsTheWork + rating.DepthPossessionOf + rating.HowWellTheProcedurePerformedGrading + rating.InterestInTheSubject + rating.NumberOfAttendance + rating.OverallSubject + rating.PreparationTime + rating.ProcedureGrading + rating.QualityMasteringTheSubject + rating.QualityTeachingMaterials + rating.RelevantToStudents + rating.SomethingNew + rating.ThePracticalValue + rating.RelevantToStudents) / 16), 1);
        }
    }
}