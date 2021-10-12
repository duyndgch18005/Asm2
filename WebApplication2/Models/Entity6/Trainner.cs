using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity6
{
    public class Trainner
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter telephone")]
        public string Telephone { get; set; }
        [Required(ErrorMessage = "Please enter Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter type")]
        public string Type { get; set; }
        [Required(ErrorMessage = "Please enter Working Place")]
        public string WorkingPlace { get; set; }
        public List<Course> Courses { get; set; }

    }
}