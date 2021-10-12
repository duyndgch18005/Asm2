using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity6
{
    public class CategoryofCourse
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Descrpition")]
        public string Descrpitipon { get; set; }

        public List<Course> CourseOwned { get; set; }
    }
}