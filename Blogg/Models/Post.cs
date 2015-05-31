using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string PostType { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostMeta> PostMetas { get; set; }

        public Post()
        {
            CreatedDate = DateTime.Now;
        }

    }

    
}