using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlogApp.Models;
using BlogApp.Repositories;

public class CommentManagerTests
{
    [Fact]
    public async Task CreateCommentAsync_ValidInput_ReturnsCommentId()
    {
        // Arrange
        var mockCommentRepository = new Mock<ICommentRepository>();
        var manager = new CommentManager(mockCommentRepository.Object);

        var comment = new Comment
        {
            CommentId = commentId,
            BlogPostId = 2,
            Text = "Test Text",
            CreatedAt = DateTime.Now
        };
        var expectedCommentId = 1;

        mockCommentRepository.Setup(repo => repo.CreateCommentAsync(comment))
            .ReturnsAsync(expectedCommentId);

        // Act
        var result = await manager.CreateCommentAsync(comment);

        // Assert
        Assert.Equal(expectedCommentId, result);
    }

    [Fact]
    public async Task GetCommentsForPostAsync_ValidPostId_ReturnsListOfComments()
    {
        // Arrange
        var mockCommentRepository = new Mock<ICommentRepository>();
        var manager = new CommentManager(mockCommentRepository.Object);

        var postId = 1;
        var expectedComments = new List<Comment>
        {
            new Comment
            {
                CommentId = commentId,
                BlogPostId = 3,
                Text = "Test Text",
                CreatedAt = DateTime.Now
             },
            new Comment
            {
                CommentId = commentId,
                BlogPostId = 4,
                Text = "Test Text",
                CreatedAt = DateTime.Now
            }
        };

        mockCommentRepository.Setup(repo => repo.GetCommentsForPostAsync(postId))
            .ReturnsAsync(expectedComments);

        // Act
        var result = await manager.GetCommentsForPostAsync(postId);

        // Assert
        Assert.Equal(expectedComments, result);
    }

    [Fact]
    public async Task GetCommentByIdAsync_ValidCommentId_ReturnsComment()
    {
        // Arrange
        var mockCommentRepository = new Mock<ICommentRepository>();
        var manager = new CommentManager(mockCommentRepository.Object);

        var commentId = 1;
        var expectedComment = new Comment
        {
            CommentId = commentId,
            BlogPostId = 5,
            Text = "Test Text",
            CreatedAt = DateTime.Now
        };

        mockCommentRepository.Setup(repo => repo.GetCommentByIdAsync(commentId))
            .ReturnsAsync(expectedComment);

        // Act
        var result = await manager.GetCommentByIdAsync(commentId);

        // Assert
        Assert.Equal(expectedComment, result);
    }

    [Fact]
    public async Task UpdateCommentAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        var mockCommentRepository = new Mock<ICommentRepository>();
        var manager = new CommentManager(mockCommentRepository.Object);

        var commentId = 1;
        var comment = new Comment
        {
            CommentId = commentId,
            BlogPostId = 6,
            Text = "Test Text",
            CreatedAt = DateTime.Now
        };

        mockCommentRepository.Setup(repo => repo.UpdateCommentAsync(comment))
            .ReturnsAsync(true);

        // Act
        var result = await manager.UpdateCommentAsync(commentId, comment);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeleteCommentAsync_ValidCommentId_ReturnsTrue()
    {
        // Arrange
        var mockCommentRepository = new Mock<ICommentRepository>();
        var manager = new CommentManager(mockCommentRepository.Object);

        var commentId = 1;

        mockCommentRepository.Setup(repo => repo.DeleteCommentAsync(commentId))
            .ReturnsAsync(true);

        // Act
        var result = await manager.DeleteCommentAsync(commentId);

        // Assert
        Assert.True(result);
    }

}
