using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace datebook.Api.Models
{
    public class PostModel
    {
        public string Post { get; set; }
        public int? PostBy { get; set; }
        public string PosterName { get; set; }
        public int? PostTo { get; set; }

    }
}