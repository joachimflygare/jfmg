using Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class FriendModel
    {
        public Friends Friend { get; set; }
        public List<Friends> FriendsList { get; set; }
    }
}