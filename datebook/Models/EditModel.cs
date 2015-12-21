using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class EditModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Info { get; set; }
        [Required]
        public int Visible { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}