namespace Blogg.Models
{
    public class PostMeta
    {
        public int ID { get; set; }
        public int PostID { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public virtual Post Post { get; set; }
    }
}