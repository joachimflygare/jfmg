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
        public string Gender { get; set; }
        public string info { get; set; }
        public List<int> Friend { get; set; }
        public Boolean visible { get; set; }

    }
}