using CodeHub.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeHub.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RepositoriesController : ControllerBase
{
    private static readonly List<CodeHubRepo> repos = new List<CodeHubRepo>
    {
        new CodeHubRepo{ Owner = "gclynch1", Name = "repo1", StarredCount = 1 },
        new CodeHubRepo{ Owner = "gclynch2", Name = "repo2", StarredCount = 2 },
        new CodeHubRepo{ Owner = "gclynch3", Name = "repo3", StarredCount = 3 },
        new CodeHubRepo{ Owner = "gclynch4", Name = "repo4", StarredCount = 0 },
    };

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CodeHubRepo>), StatusCodes.Status200OK)]
    public IActionResult GetAllRepos()
    {
        var sortedRepos = repos.OrderByDescending(r => r.StarredCount);

        return Ok(sortedRepos);
    }

    [HttpGet("owner/{owner}")]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(IEnumerable<CodeHubRepo>), StatusCodes.Status200OK)]
    public IActionResult GetReposByOwner(string owner)
    {
        var reposByOwner = repos.Where(r => r.Owner == owner);
        if (!reposByOwner.Any())
        {
            return NotFound($"Could not find any repository owned by '{owner}'.");
        }

        return Ok(reposByOwner);
    }

    [HttpPost("owner/{owner}/new")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(CodeHubRepo), StatusCodes.Status201Created)]
    public IActionResult AddRepo(string owner, string repoName, int starCount)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        if (repos.Any(r => r.Owner == owner && r.Name == repoName))
        {
            return BadRequest(
                $"Repository named '{repoName}' owned by '{owner}' already exists.");
        }

        var newRepo = new CodeHubRepo
        {
            Owner = owner,
            Name = repoName,
            StarredCount = starCount
        };

        repos.Add(newRepo);

        return CreatedAtAction(
            nameof(GetReposByOwner), new { owner = newRepo.Owner }, newRepo);
    }

    [HttpPut("owner/{owner}/repo/{repo}/star")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult UpdateRepoStar(string owner, string repoName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var repo = repos.FirstOrDefault(r => r.Owner == owner && r.Name == repoName);
        if (repo == null)
        {
            return NotFound($"Repository '{repoName}' owned by '{owner}' not found.");
        }

        repo.StarredCount++;

        return NoContent();
    }

    [HttpDelete("owner/{owner}/repo/{repo}")]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public IActionResult DeleteRepo(string owner, string repoName)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var repoToDelete = repos.FirstOrDefault(r => r.Owner == owner && r.Name == repoName);
        if (repoToDelete == null)
        {
            return NotFound($"Repository '{repoName}' owned by '{owner}' not found.");
        }

        repos.Remove(repoToDelete);

        return NoContent();
    }
}
