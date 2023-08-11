namespace BlogApp.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public int BlogPostId { get; set; }

        public string Text { get; set; } = "";

        public DateTime CreatedAt { get; set; }
        public virtual BlogPost BlogPost { get; set; }
    }
}