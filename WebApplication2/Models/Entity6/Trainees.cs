using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication2.Models.Entity6
{
    public class Trainees
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter Education")]
        public string Education { get; set; }
        [Required(ErrorMessage = "Please enter DOB")]
        public string DOB { get; set; }
        [Required(ErrorMessage = "Please enter Age")]
        public string Age { get; set; }
        [Required(ErrorMessage = "Please enter Department")]
        public string Department { get; set; }
        [Required(ErrorMessage = "Please enter Toeic")]
        public string TOEIC { get; set; }
        [Required(ErrorMessage = "Please enter Location")]
        public string Location { get; set; }

        public Course Course { get; set; }
    }
}