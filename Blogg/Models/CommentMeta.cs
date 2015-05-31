using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blogg.Models
{
    public class CommentMeta
    {
        public int ID { get; set; }
        public int CommentID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public virtual Comment Comment { get; set; }
    }
}