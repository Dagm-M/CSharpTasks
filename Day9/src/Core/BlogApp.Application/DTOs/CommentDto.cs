using BlogApp.Application.DTOs.Common;

namespace BlogApp.Application.DTOs
{
    public class CommentDto : BaseDto
    {
        public int BlogPostId { get; set; }

        public string Text { get; set; } = "";
    }
}