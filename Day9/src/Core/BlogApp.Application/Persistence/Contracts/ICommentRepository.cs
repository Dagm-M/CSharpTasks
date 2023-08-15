using BlogApp.Domain;

namespace BlogApp.Application.Persitence.Contracts
{
    public interface ICommentRepository : IGenericRepository<Comment>
    {
        Task<int> CreateCommentAsync(Comment comment);
        Task<List<Comment>> GetCommentsForPostAsync(int postId);
        Task<Comment> GetCommentByIdAsync(int commentId);
        Task<bool> UpdateCommentAsync(Comment comment);
        Task<bool> DeleteCommentAsync(int commentId);
    }
}
