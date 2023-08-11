using Xunit;
using Moq;
using System.Threading.Tasks;
using System.Collections.Generic;
using BlogApp.Models;
using BlogApp.Repositories;

public class BlogPostManagerTests
{
    [Fact]
    public async Task CreatePostAsync_ValidInput_ReturnsPostId()
    {
        // Arrange
        var mockPostRepository = new Mock<IBlogPostRepository>();
        var manager = new BlogPostManager(mockPostRepository.Object);

        var blogPost = new BlogPost
        {
            BlogPostId = 1,
            Title = "Test",
            Content = "Test Text",
            CreatedAt = DateTime.Now
        };
        var expectedPostId = 1;

        mockPostRepository.Setup(repo => repo.CreatePostAsync(blogPost))
            .ReturnsAsync(expectedPostId);

        // Act
        var result = await manager.CreatePostAsync(blogPost);

        // Assert
        Assert.Equal(expectedPostId, result);
    }

    [Fact]
    public async Task GetAllPostsAsync_ReturnsListOfPosts()
    {
        // Arrange
        var mockPostRepository = new Mock<IBlogPostRepository>();
        var manager = new BlogPostManager(mockPostRepository.Object);

        var expectedPosts = new List<BlogPost>
        {
            new BlogPost
            {
                BlogPostId = 2,
                Title = "Test",
                Content = "Test Text",
                CreatedAt = DateTime.Now
             },
            new BlogPost
            {
                BlogPostId = 3,
                Title = "Test",
                Content = "Test Text",
                CreatedAt = DateTime.Now
             }
        };

        mockPostRepository.Setup(repo => repo.GetAllPostsAsync())
            .ReturnsAsync(expectedPosts);

        // Act
        var result = await manager.GetAllPostsAsync();

        // Assert
        Assert.Equal(expectedPosts, result);
    }

    [Fact]
    public async Task GetPostByIdAsync_ValidId_ReturnsPost()
    {
        // Arrange
        var mockPostRepository = new Mock<IBlogPostRepository>();
        var manager = new BlogPostManager(mockPostRepository.Object);

        var postId = 1;
        var expectedPost = new BlogPost { /* Initialize properties */ };

        mockPostRepository.Setup(repo => repo.GetPostByIdAsync(postId))
            .ReturnsAsync(expectedPost);

        // Act
        var result = await manager.GetPostByIdAsync(postId);

        // Assert
        Assert.Equal(expectedPost, result);
    }

    [Fact]
    public async Task UpdatePostAsync_ValidInput_ReturnsTrue()
    {
        // Arrange
        var mockPostRepository = new Mock<IBlogPostRepository>();
        var manager = new BlogPostManager(mockPostRepository.Object);

        var blogPost = new BlogPost
        {
            BlogPostId = 4,
            Title = "Test",
            Content = "Test Text",
            CreatedAt = DateTime.Now
        };

        mockPostRepository.Setup(repo => repo.UpdatePostAsync(blogPost))
            .ReturnsAsync(true);

        // Act
        var result = await manager.UpdatePostAsync(blogPost);

        // Assert
        Assert.True(result);
    }

    [Fact]
    public async Task DeletePostAsync_ValidId_ReturnsTrue()
    {
        // Arrange
        var mockPostRepository = new Mock<IBlogPostRepository>();
        var manager = new BlogPostManager(mockPostRepository.Object);

        var postId = 1;

        mockPostRepository.Setup(repo => repo.DeletePostAsync(postId))
            .ReturnsAsync(true);

        // Act
        var result = await manager.DeletePostAsync(postId);

        // Assert
        Assert.True(result);
    }
}
