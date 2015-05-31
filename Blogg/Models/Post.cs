using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Post
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public virtual ICollection<Comment> Comments { get; set; } 
    }
}