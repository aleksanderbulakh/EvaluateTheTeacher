using AvaluateTheTeacher1.Models;
using AvaluateTheTeacher1.Models.Teachers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1.CodeReview.Models
{
    public class RaitingModel
    {
        private int? SelectedCathedraId { get; set; }
        private IQueryable<ListOfTeachers> query { get; set; }
        
        ApplicationDbContext db = new ApplicationDbContext();

        public FilterDataModel ListOfTeacherData(int? id)
        {
            if (id == 0 || id == null)
            {
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && (listTeachers1.CathedraId == listCathedras.Id) && (listRaitings.AvgRating != 0) && (listRaitings.CountRaitingVoting > 3))
                    orderby listRaitings.AvgRating descending, listRaitings.CountRaitingVoting descending, listRaitings.TheDifficultyOfTheCourse descending
                    select new ListOfTeachers()
                    {
                        TeacherId = listTeachers.TeacherId,
                        NameCathedra = listCathedras.NameCathedra,
                        Name = listTeachers.Name.Substring(0, 1),
                        SurName = listTeachers.SurName.Substring(0, 1),
                        LastName = listTeachers.LastName,
                        PathToPhoto = listTeachers.PathToPhoto,
                        Description = listTeachers.Description,
                        AvgRating = listRaitings.AvgRating,
                        Count = listRaitings.CountRaitingVoting,
                        TheDifficultyOfTheCourse = listRaitings.TheDifficultyOfTheCourse
                    };
            }
            else
            {
                SelectedCathedraId = id;
                query =
                    from listCathedras in db.Cathedras
                    from listRaitings in db.Ratings
                    from listTeachers in db.Teachers
                    .Where(listTeachers1 => (listTeachers1.TeacherId == listRaitings.TeacherId) && ((listTeachers1.CathedraId == SelectedCathedraId) && (listTeachers1.CathedraId == listCathedras.Id) && (listRaitings.AvgRating != 0)) && (listRaitings.CountRaitingVoting > 3))
                    orderby listRaitings.AvgRating descending, listRaitings.CountRaitingVoting descending, listRaitings.TheDifficultyOfTheCourse descending
                    select new ListOfTeachers()
                    {
                        TeacherId = listTeachers.TeacherId,
                        NameCathedra = listCathedras.NameCathedra,
                        Name = listTeachers.Name.Substring(0, 1),
                        SurName = listTeachers.SurName.Substring(0, 1),
                        LastName = listTeachers.LastName,
                        PathToPhoto = listTeachers.PathToPhoto,
                        Description = listTeachers.Description,
                        AvgRating = listRaitings.AvgRating,
                        Count = listRaitings.CountRaitingVoting,
                        TheDifficultyOfTheCourse = listRaitings.TheDifficultyOfTheCourse
                    };
            }
            List<Cathedra> cathedra = db.Cathedras.ToList();
            cathedra.Insert(0, new Cathedra { NameCathedra = "Всі кафедри", Id = 0 });
            FilterDataModel data = new FilterDataModel
            {
                Teachers = query.ToList(),
                Cathedras = cathedra,
                SelectedId = id
            };

            return data;
        }
    }
}