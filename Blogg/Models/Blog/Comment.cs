using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Blogg.Models.Blog
{
    public class Comment
    {
        #region ctor

        public Comment()
        {
            CreatedDate = DateTime.Now;
        }

        #endregion

        #region properties

        public int ID { get; set; }
        public string Content { get; set; }
        public int PostID { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string Status { get; set; }
        public int Parent { get; set; }

        #endregion

        #region navigational properties

        public virtual Post Post { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<CommentMeta> CommentMetas { get; set; }

        #endregion 
    }
}