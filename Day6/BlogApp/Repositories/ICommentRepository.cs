using BlogApp.Models;

public interface ICommentRepository
{
    Task<int> CreateCommentAsync(Comment comment);
    Task<List<Comment>> GetCommentsForPostAsync(int postId);
    Task<Comment> GetCommentByIdAsync(int commentId);
    Task<bool> UpdateCommentAsync(Comment comment);
    Task<bool> DeleteCommentAsync(int commentId);
}
