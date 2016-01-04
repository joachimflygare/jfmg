using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class EditModel
    {
        public string Picture { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public int Age { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Info { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public int Visible { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}