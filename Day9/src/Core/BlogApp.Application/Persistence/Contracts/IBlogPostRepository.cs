using BlogApp.Domain;

namespace BlogApp.Application.Persitence.Contracts
{
    public interface IBlogPostRepository : IGenericRepository<BlogPost>
    {
        Task<int> CreatePostAsync(BlogPost post);
        Task<List<BlogPost>> GetAllPostsAsync();
        Task<BlogPost> GetPostByIdAsync(int postId);
        Task<bool> UpdatePostAsync(BlogPost post);
        Task<bool> DeletePostAsync(int postId);
    }
}
