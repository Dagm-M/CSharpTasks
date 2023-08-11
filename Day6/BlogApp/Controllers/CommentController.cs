using BlogApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BlogApp.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly CommentManager _commentManager;

    public CommentsController(CommentManager commentManager)
    {
        _commentManager = commentManager;
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create([FromBody] Comment comment)
    {
        if (ModelState.IsValid)
        {
            int commentId = await _commentManager.CreateCommentAsync(comment);
            return Ok(commentId);
        }

        return BadRequest(ModelState);
    }

    [HttpGet("{postId}")]
    public async Task<ActionResult<IEnumerable<Comment>>> GetByPostId(int postId)
    {
        var comments = await _commentManager.GetCommentsForPostAsync(postId);
        return Ok(comments);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Comment>> GetById(int id)
    {
        var comment = await _commentManager.GetCommentByIdAsync(id);
        if (comment == null)
        {
            return NotFound();
        }
        return Ok(comment);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, [FromBody] Comment comment)
    {
        if (ModelState.IsValid)
        {
            bool updated = await _commentManager.UpdateCommentAsync(id, comment);
            if (updated)
            {
                return NoContent();
            }
            return NotFound();
        }

        return BadRequest(ModelState);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        bool deleted = await _commentManager.DeleteCommentAsync(id);
        if (deleted)
        {
            return NoContent();
        }
        return NotFound();
    }
}
