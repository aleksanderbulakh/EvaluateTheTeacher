using AvaluateTheTeacher1.CodeReview.ViewModels;
using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Students;
using AvaluateTheTeacher1.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AvaluateTheTeacher1.CodeReview.Models
{
    public class VotingModel
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool CheckVote(int idTeacher, ApplicationUser studentData)
        {
            var listStudentVotings = db.StudentVotings.Where(m => m.TeachersSubjectId == idTeacher && m.StudentId == studentData.Id).ToList();
            if (listStudentVotings != null)
            {
                foreach (var stVt in listStudentVotings)
                    if (stVt.Date.Month == DateTime.Now.Month)
                        return true;
            }
            return false;
        }

        public VotingViewModel Voiting(int id)
        {
            var query = (from listTeachers in db.Teachers
                         from Subjectslist in db.Subjects
                         from listTeacherSubject in db.TeacherSubject
                        .Where(list => list.Id == id && list.TeacherId == listTeachers.TeacherId && list.SubjectId == Subjectslist.Id)
                         select listTeachers).ToList();
            var querySubjectName = (from subjectsList in db.Subjects
                                    from teacherSubjectList in db.TeacherSubject
                                    .Where(list => list.Id == id && list.SubjectId == subjectsList.Id)
                                    select subjectsList).ToList();
            var info = new VotingViewModel
            {
                idTeacher = id,
                teacherName = query[0].LastName.ToString() + " " + query[0].Name.ToString() + " " + query[0].SurName.ToString(),
                pathToPhoto = query[0].PathToPhoto,
                SubjectName = querySubjectName[0].Name
            };

            return info;
        }

        public void FixVoting(int id, ApplicationUser studentData)
        {
            var StVoting = new StudentVoting();
            StVoting.Date = DateTime.Now.Date;
            StVoting.StudentId = studentData.Id;
            StVoting.TeachersSubjectId = id;
            db.StudentVotings.Add(StVoting);
            db.SaveChanges();
        }

        private void NewVotingData(VotingViewModel model)
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
                TeacherSubjectId = model.idTeacher
            };
            db.Votings.Add(voting);
            db.SaveChanges();
        }

        private List<double> CalculateAvgVotingValuation(int id)
        {
            var avgValuationList = new List<double>();

            for (int index = 0; index < 19; index++)
                avgValuationList.Add(0);

            var listId = db.Votings.Where(x => x.TeacherSubjectId == id).ToList();

            foreach (var voit in listId)
            {
                avgValuationList[0] += voit.ActivityInClass;
                avgValuationList[1] += voit.AvailabilityTeacherOutsideLessons;
                avgValuationList[2] += voit.ClarityAndAccessibility;
                avgValuationList[3] += voit.CommentsTheWork;
                avgValuationList[4] += voit.DepthPossessionOf;
                avgValuationList[5] += voit.HowWellTheProcedurePerformedGrading;
                avgValuationList[6] += voit.InterestInTheSubject;
                avgValuationList[7] += voit.NumberOfAttendance;
                avgValuationList[8] += voit.OverallSubject;
                avgValuationList[9] += voit.PreparationTime;
                avgValuationList[10] += voit.ProcedureGrading;
                avgValuationList[11] += voit.QualityMasteringTheSubject;
                avgValuationList[12] += voit.QualityTeachingMaterials;
                avgValuationList[13] += voit.RelevantToStudents;
                avgValuationList[14] += voit.SomethingNew;
                avgValuationList[15] += voit.TheDifficultyOfTheCourse;
                avgValuationList[16] += voit.ThePracticalValue;
                avgValuationList[17] += voit.RelevantToStudents;
                avgValuationList[18] = avgValuationList[18] + 1;
            }

            for (int index = 0; index < avgValuationList.Count - 1; index++)
                avgValuationList[index] /= avgValuationList[18];

            return avgValuationList;
        }

        private float RoundNumber(double numer)
        {
            return float.Parse(Math.Round(numer, 1).ToString());
        }

        private void RecalculaitingValuation(int id)
        {
            var avgValuationList = CalculateAvgVotingValuation(id);

            var raitTeachSubj = db.RaitingTeacherSubject.Where(x => x.TeacherSubjectId == id).ToList();

            foreach (var rating in raitTeachSubj)
            {
                rating.ActivityInClass = RoundNumber(avgValuationList[0]);
                rating.AvailabilityTeacherOutsideLessons = RoundNumber(avgValuationList[1]);
                rating.ClarityAndAccessibility = RoundNumber(avgValuationList[2]);
                rating.CommentsTheWork = RoundNumber(avgValuationList[3]);
                rating.DepthPossessionOf = RoundNumber(avgValuationList[4]);
                rating.HowWellTheProcedurePerformedGrading = RoundNumber(avgValuationList[5]);
                rating.InterestInTheSubject = RoundNumber(avgValuationList[6]);
                rating.NumberOfAttendance = RoundNumber(avgValuationList[7]);
                rating.OverallSubject = RoundNumber(avgValuationList[8]);
                rating.PreparationTime = RoundNumber(avgValuationList[9]);
                rating.ProcedureGrading = RoundNumber(avgValuationList[10]);
                rating.QualityMasteringTheSubject = RoundNumber(avgValuationList[11]);
                rating.QualityTeachingMaterials = RoundNumber(avgValuationList[12]);
                rating.RelevantToStudents = RoundNumber(avgValuationList[13]);
                rating.SomethingNew = RoundNumber(avgValuationList[14]);
                rating.TheDifficultyOfTheCourse = RoundNumber(avgValuationList[15]);
                rating.ThePracticalValue = RoundNumber(avgValuationList[16]);
                rating.RelevantToStudents = RoundNumber(avgValuationList[17]);

                double sumValuation = 0;
                for (int index = 0; index < avgValuationList.Count - 1; index++)
                {
                    if (index != 15)
                        sumValuation += avgValuationList[index];
                }

                rating.AvgRating = RoundNumber(sumValuation / 16);
                rating.CountVoting = (int)avgValuationList[18];
            }
            db.SaveChanges();
        }

        private List<double> CalculateAvgRaitingValuation(int id, TeacherSubject teach)
        {

            var avgValuationList = new List<double>();

            for (int index = 0; index < 19; index++)
                avgValuationList.Add(0);

            var listId = db.Votings.Where(x => x.TeacherSubjectId == id).ToList();
            var teachId = db.TeacherSubject.Where(x => x.TeacherId == teach.TeacherId);

            var listS = new List<int>();
            foreach (var s in teachId)
            {
                listS.Add(s.Id);
            }

            int count = 0;

            var listIdRaiting = db.RaitingTeacherSubject.Where(x => x.TeacherSubject.TeacherId == teach.TeacherId && x.AvgRating != 0).ToList();
            foreach (var voit in listIdRaiting)
            {
                avgValuationList[0] += voit.ActivityInClass;
                avgValuationList[1] += voit.AvailabilityTeacherOutsideLessons;
                avgValuationList[2] += voit.ClarityAndAccessibility;
                avgValuationList[3] += voit.CommentsTheWork;
                avgValuationList[4] += voit.DepthPossessionOf;
                avgValuationList[5] += voit.HowWellTheProcedurePerformedGrading;
                avgValuationList[6] += voit.InterestInTheSubject;
                avgValuationList[7] += voit.NumberOfAttendance;
                avgValuationList[8] += voit.OverallSubject;
                avgValuationList[9] += voit.PreparationTime;
                avgValuationList[10] += voit.ProcedureGrading;
                avgValuationList[11] += voit.QualityMasteringTheSubject;
                avgValuationList[12] += voit.QualityTeachingMaterials;
                avgValuationList[13] += voit.RelevantToStudents;
                avgValuationList[14] += voit.SomethingNew;
                avgValuationList[15] += voit.TheDifficultyOfTheCourse;
                avgValuationList[16] += voit.ThePracticalValue;
                avgValuationList[17] += voit.RelevantToStudents;
                avgValuationList[18] += voit.CountVoting;
                count++;
            }

            for (int index = 0; index < avgValuationList.Count - 1; index++)
                avgValuationList[index] /= count;

            return avgValuationList;
        }

        private void RecalculateRaitingValuation(int id)
        {
            var teach = db.TeacherSubject.Find(id);
            var avgRaitingValuatingList = CalculateAvgRaitingValuation(id, teach);


            var raitTeach = db.Ratings.Where(x => x.TeacherId == teach.TeacherId).ToList();
            foreach (var rating in raitTeach)
            {
                rating.ActivityInClass = RoundNumber(avgRaitingValuatingList[0]);
                rating.AvailabilityTeacherOutsideLessons = RoundNumber(avgRaitingValuatingList[1]);
                rating.ClarityAndAccessibility = RoundNumber(avgRaitingValuatingList[2]);
                rating.CommentsTheWork = RoundNumber(avgRaitingValuatingList[3]);
                rating.DepthPossessionOf = RoundNumber(avgRaitingValuatingList[4]);
                rating.HowWellTheProcedurePerformedGrading = RoundNumber(avgRaitingValuatingList[5]);
                rating.InterestInTheSubject = RoundNumber(avgRaitingValuatingList[6]);
                rating.NumberOfAttendance = RoundNumber(avgRaitingValuatingList[7]);
                rating.OverallSubject = RoundNumber(avgRaitingValuatingList[8]);
                rating.PreparationTime = RoundNumber(avgRaitingValuatingList[9]);
                rating.ProcedureGrading = RoundNumber(avgRaitingValuatingList[10]);
                rating.QualityMasteringTheSubject = RoundNumber(avgRaitingValuatingList[11]);
                rating.QualityTeachingMaterials = RoundNumber(avgRaitingValuatingList[12]);
                rating.RelevantToStudents = RoundNumber(avgRaitingValuatingList[13]);
                rating.SomethingNew = RoundNumber(avgRaitingValuatingList[14]);
                rating.TheDifficultyOfTheCourse = RoundNumber(avgRaitingValuatingList[15]);
                rating.ThePracticalValue = RoundNumber(avgRaitingValuatingList[16]);
                rating.RelevantToStudents = RoundNumber(avgRaitingValuatingList[17]);

                double raitingSum = 0;
                for (int index = 0; index < avgRaitingValuatingList.Count - 1; index++)
                {
                    if (index != 15)
                        raitingSum += avgRaitingValuatingList[index];
                }

                rating.AvgRating = RoundNumber(raitingSum / 16);
                rating.CountRaitingVoting = (int)avgRaitingValuatingList[18];
            }
            db.SaveChanges();
        }

        public void CalculateVotings(VotingViewModel model)
        {
            NewVotingData(model);
            RecalculaitingValuation(model.idTeacher);
            RecalculateRaitingValuation(model.idTeacher);
        }

        public VotingList InfoForRaitingList(int? groupId)
        {
            var Group = db.Groups.Where(n => n.GroupId == groupId).ToList();
            var listS = new List<int>();
            foreach (var s in Group)
            {
                foreach (var st in s.TeachersSubjects)
                {
                    listS.Add(st.Id);
                }
            }

            var query = from listTeacher in db.Teachers
                        from listRaiting in db.Ratings
                        from listSubject in db.Subjects
                        from listTeachersSubject in db.TeacherSubject
                        .Where(listTeachersSubj => (listS.Contains(listTeachersSubj.Id) && listSubject.Id == listTeachersSubj.SubjectId && listTeacher.TeacherId == listTeachersSubj.TeacherId && listRaiting.TeacherId == listTeacher.TeacherId))
                        orderby listRaiting.AvgRating descending
                        select new ListOfTeachers()
                        {
                            TeacherId = listTeacher.TeacherId,
                            Name = listTeacher.Name,
                            SurName = listTeacher.SurName,
                            LastName = listTeacher.LastName,
                            PathToPhoto = listTeacher.PathToPhoto,
                            Description = listTeacher.Description,
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
    }
}