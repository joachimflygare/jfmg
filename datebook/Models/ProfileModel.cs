using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class ProfileModel : FriendModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Info { get; set; }
        public Boolean visible { get; set; }
    }
}