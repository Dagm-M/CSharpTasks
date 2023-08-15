using BlogApp.Application.DTOs.Common;

namespace BlogApp.Domain
{
    public class BlogPostDto : BaseDto
    {
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";

    }
}