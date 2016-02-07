using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Models.Teachers
{
    public class FilterDataModel
    {
        public IEnumerable<ListOfTeachers> Teachers { get; set; }

        public List<Cathedra> Cathedras { get; set; }

        public int? SelectedId { get; set; }
    }
}