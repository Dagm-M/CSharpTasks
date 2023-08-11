using BlogApp.Models;

namespace BlogApp.Repositories;

public interface IBlogPostRepository
{
    Task<int> CreatePostAsync(BlogPost post);
    Task<List<BlogPost>> GetAllPostsAsync();
    Task<BlogPost> GetPostByIdAsync(int postId);
    Task<bool> UpdatePostAsync(BlogPost post);
    Task<bool> DeletePostAsync(int postId);
}
