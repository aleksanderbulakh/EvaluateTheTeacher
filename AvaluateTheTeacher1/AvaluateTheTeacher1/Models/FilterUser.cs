using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AvaluateTheTeacher1.Models
{
    public class FilterUser
    {
        public IEnumerable<ListOfUsers> List { get; set; }
        public int? SelectedId { get; set; }
        public SelectList Group { get; set; }
    }
}