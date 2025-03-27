using Forum.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Forum.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController : ControllerBase
{
    private static List<ForumPost> posts = new List<ForumPost>();

    [HttpGet]
    public IEnumerable<ForumPost> GetPosts()
    {
        return posts.OrderBy(p => p.ForumPostId);
    }

    [HttpGet("id/{postId}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(UserPost), StatusCodes.Status200OK)]
    public ActionResult<ForumPost> GetPostById(int postId)
    {
        var post = posts.FirstOrDefault(p => p.ForumPostId == postId);
        if (post == null)
        {
            return NotFound();
        }

        return Ok(post);
    }

    [HttpGet("recent/{postCount:min(1)}")]
    public ActionResult<IEnumerable<ForumPost>> GetRecentPosts(int postCount)
    {
        var recentPosts = posts
            .OrderByDescending(p => p.ForumPostId).Take(postCount);

        return Ok(recentPosts);
    }

    [HttpPost]
    [ProducesResponseType(typeof(ForumPost), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public IActionResult NewPost([FromBody] UserPost userPost)
    {
        ForumPost forumPost;
        int forumPostId;

        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (posts.Count == 0)
        {
            forumPostId = 1;
        }
        else
        {
            forumPostId = posts[posts.Count - 1].ForumPostId + 1;
        }

        forumPost = new ForumPost
        {
            ForumPostId = forumPostId,
            UserPost = userPost,
            Timestamp = DateTime.Now
        };
        posts.Add(forumPost);

        return CreatedAtRoute
        (
            nameof(GetPostById),
            new { id = forumPost.ForumPostId }, 
            forumPost
        );
    }
}
