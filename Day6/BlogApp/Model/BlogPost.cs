namespace BlogApp.Models
{
    public class BlogPost
    {
        public int BlogPostId { get; set; }

        public string Title { get; set; } = "";

        public string Content { get; set; } = "";

        public DateTime CreatedAt { get; set; }
        public virtual ICollection<Comment> Comment { get; set; } = new List<Comment>();
    }
}