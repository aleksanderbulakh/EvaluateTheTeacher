using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AvaluateTheTeacher1
{
    public class UpdateGroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Dictionary<bool, Dictionary<int, string>> TeacheSubjectForGroup { get; set; }
        public List<DateTime> SemesterFrom { get; set; }
        public List<DateTime> SemesterTo { get; set; }
    }
}