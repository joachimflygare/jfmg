//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Repositories
{
    using System;
    using System.Collections.Generic;
    
    public partial class Posts
    {
        public int PostId { get; set; }
        public Nullable<int> PostBy { get; set; }
        public Nullable<int> PostTo { get; set; }
        public string Post { get; set; }
    
        public virtual Users Users { get; set; }
        public virtual Users Users1 { get; set; }
    }
}
