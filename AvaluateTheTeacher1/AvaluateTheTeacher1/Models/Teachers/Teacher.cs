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

        public string PathToPhoto { get; set; }

        public string Description { get; set; }

        public int? CathedraId { get; set; }

        public Cathedra Cathedra { get; set; }

        public virtual ICollection<Subject> Subjects { get; set; }
        public virtual ICollection<Voting> Votings { get; set; }
        public virtual ICollection<Suggestions> Suggestion { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public virtual ICollection<Students.Group> Groups { get; set; }
        public virtual ICollection<MessageForModerator> Message { get; set; }
        public virtual ICollection<Students.StudentVoting> StudentVotings { get; set; }
        public Teacher()
        {
            Subjects = new List<Subject>();
            Votings = new List<Voting>();
            Ratings = new List<Rating>();
            Groups = new List<Students.Group>();
            Suggestion = new List<Suggestions>();
            Message = new List<MessageForModerator>();
            StudentVotings = new List<Students.StudentVoting>();
        }
    }
}