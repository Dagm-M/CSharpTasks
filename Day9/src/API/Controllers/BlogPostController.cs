using Microsoft.AspNetCore.Mvc;
using BlogApp.Domain;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data.Config;

namespace BlogApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostsController : ControllerBase
{
    private readonly AppDbContext _BlogPostManager;

    public BlogPostsController(AppDbContext context)
    {
        _BlogPostManager = context;
    }

    [HttpGet]
    public async Task<List<BlogPost>> Index()
    {
        var blogPosts = await _BlogPostManager.BlogPosts.ToListAsync();

        return blogPosts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogPost = await _BlogPostManager.BlogPosts.FirstOrDefaultAsync(m => m.Id == id);

        if (blogPost == null)
        {
            return NotFound();
        }

        return blogPost;
    }


    [HttpPost]
    public async Task<ActionResult<BlogPost>> Create(BlogPost blogPost)
    {
        if (ModelState.IsValid)
        {
            _BlogPostManager.Add(blogPost);
            await _BlogPostManager.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return blogPost;
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost>> Edit(int id, [Bind("PostId,Title,Content,CreatedAt")] BlogPost blogPost)
    {
        if (id != blogPost.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _BlogPostManager.Update(blogPost);
                await _BlogPostManager.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogPost.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return blogPost;
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {

        var blogPost = await _BlogPostManager.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _BlogPostManager.BlogPosts.Remove(blogPost);
            await _BlogPostManager.SaveChangesAsync();
        }

        return Ok();
    }

    private bool BlogPostExists(int id)
    {
        return _BlogPostManager.BlogPosts.Any(e => e.Id == id);
    }
}

