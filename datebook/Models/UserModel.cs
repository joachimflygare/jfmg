using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class UserModel
    {
        public int Uid { get; set; }
        public string Name { get; set; }
        public string Usernamne { get; set; }
        public string Gender { get; set; }
        public int Age { get; set; }
        public Boolean Visible { get; set; }
        public string Password { get; set; }

    }
}