using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace datebook.Models
{
    [Table("Poster")]
    public class PostsModel
    {
        public int PostId {get; set;}
        public int userSentId { get; set; }
        public int userRecivedId { get; set; }
        public string text { get; set; }

    }
}