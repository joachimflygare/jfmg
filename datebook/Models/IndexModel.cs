using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class IndexModel
    {
        // For LogIn
        [Required(ErrorMessage = "Please enter a username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter a password")]
        public string Password { get; set; }

        //For Register
       
        public string Name { get; set; }
        public string RegUsername { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string RegPassword { get; set; }
        
    }
}