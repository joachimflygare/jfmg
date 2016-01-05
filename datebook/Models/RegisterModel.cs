using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "No field can be empty")]
        public string Name { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Username { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public int Age { get; set; }
        [Required(ErrorMessage = "No field can be empty")]
        public string Password { get; set; }
        [RegularExpression(@"^(([0-9A-Z])(?!\2))*$")]
        [Required(ErrorMessage = "Invalid password, only letters and numbers is allowed")]
        public int Visible { get; set; }


    }
}