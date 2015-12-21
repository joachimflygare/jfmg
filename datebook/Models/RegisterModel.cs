using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class RegisterModel
    {
        public string Name { get; set; }
        public string RegUsername { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public string RegPassword { get; set; }
        public int Visible { get; set; }


    }
}