using BlogApp.Domain.Common;

namespace BlogApp.Domain
{
    public class Comment : BaseDomainEntity
    {
        public int BlogPostId { get; set; }

        public string Text { get; set; } = "";
        public virtual BlogPost? BlogPost { get; set; }
    }
}