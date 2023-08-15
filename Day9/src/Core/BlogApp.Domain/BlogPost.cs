using BlogApp.Domain.Common;

namespace BlogApp.Domain
{
    public class BlogPost : BaseDomainEntity
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
        public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();
    }
}