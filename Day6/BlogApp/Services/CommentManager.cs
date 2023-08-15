using BlogApp.Models;

public class CommentManager
{
    private readonly ICommentRepository _commentRepository;

    public CommentManager(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async Task<int> CreateCommentAsync(Comment comment)
    {
        return await _commentRepository.CreateCommentAsync(comment);
    }

    public async Task<List<Comment>> GetCommentsForPostAsync(int postId)
    {
        return await _commentRepository.GetCommentsForPostAsync(postId);
    }

    public async Task<Comment> GetCommentByIdAsync(int commentId)
    {
        return await _commentRepository.GetCommentByIdAsync(commentId);
    }

    public async Task<bool> UpdateCommentAsync(int id, Comment comment)
    {
        return await _commentRepository.UpdateCommentAsync(comment);
    }

    public async Task<bool> DeleteCommentAsync(int commentId)
    {
        return await _commentRepository.DeleteCommentAsync(commentId);
    }
}
