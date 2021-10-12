using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity6
{
    public class Course
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name of course")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Descrpition")]
        public string Descrpitipon { get; set; }

        public List<Trainees> Trainee { get; set; }

        public List<Trainner> Trainer { get; set; }
        public int CatId { get; set; }
    }
}