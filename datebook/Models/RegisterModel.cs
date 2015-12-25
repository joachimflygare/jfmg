using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string Password { get; set; }
        public int Visible { get; set; }


    }
}