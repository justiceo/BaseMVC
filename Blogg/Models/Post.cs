﻿using System;
using System.Collections.Generic;

namespace Blogg.Models
{
    public class Post
    {
        public Post()
        {
            CreatedDate = DateTime.Now;
        }

        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Excerpt { get; set; }
        public string Content { get; set; }
        public string Status { get; set; }
        public string PostType { get; set; }
        public int ApplicationUserID { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<PostMeta> PostMetas { get; set; }
    }
}