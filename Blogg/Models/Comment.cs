using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class Comment
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public string parent { get; set; }
        public int PostID { get; set; }
        public int ApplicationUserID { get; set; }

        public virtual Post Post { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<CommentMeta> CommentMetas { get; set; } 


        public Comment()
        {
            CreatedDate = DateTime.Now;
        }
    }
}