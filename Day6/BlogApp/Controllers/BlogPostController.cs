using Microsoft.AspNetCore.Mvc;
using BlogApp.Models;
using Microsoft.EntityFrameworkCore;
using BlogApp.Data;

namespace BlogApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BlogPostsController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public BlogPostsController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<List<BlogPost>> Index()
    {
        var blogPosts = await _context.BlogPosts.ToListAsync();

        return blogPosts;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<BlogPost>> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogPost = await _context.BlogPosts.FirstOrDefaultAsync(m => m.BlogPostId == id);

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
            _context.Add(blogPost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return blogPost;
    }


    [HttpPut("{id}")]
    public async Task<ActionResult<BlogPost>> Edit(int id, [Bind("PostId,Title,Content,CreatedAt")] BlogPost blogPost)
    {
        if (id != blogPost.BlogPostId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(blogPost);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogPost.BlogPostId))
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

        var blogPost = await _context.BlogPosts.FindAsync(id);
        if (blogPost != null)
        {
            _context.BlogPosts.Remove(blogPost);
            await _context.SaveChangesAsync();
        }

        return Ok();
    }

    private bool BlogPostExists(int id)
    {
        return _context.BlogPosts.Any(e => e.BlogPostId == id);
    }
}

