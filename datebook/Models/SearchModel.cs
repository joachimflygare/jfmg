using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace datebook.Models
{
    public class SearchModel
    {
        [Required]
        public string SearchString { get; set; }

    }
}