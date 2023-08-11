using BlogApp.Models;
using BlogApp.Repositories;

public class BlogPostManager
{
    private readonly IBlogPostRepository _postRepository;

    public BlogPostManager(IBlogPostRepository postRepository)
    {
        _postRepository = postRepository;
    }

    public async Task<int> CreatePostAsync(BlogPost post)
    {
        return await _postRepository.CreatePostAsync(post);
    }

    public async Task<List<BlogPost>> GetAllPostsAsync()
    {
        return await _postRepository.GetAllPostsAsync();
    }

    public async Task<BlogPost> GetPostByIdAsync(int postId)
    {
        return await _postRepository.GetPostByIdAsync(postId);
    }

    public async Task<bool> UpdatePostAsync(BlogPost post)
    {
        return await _postRepository.UpdatePostAsync(post);
    }

    public async Task<bool> DeletePostAsync(int postId)
    {
        return await _postRepository.DeletePostAsync(postId);
    }
}
