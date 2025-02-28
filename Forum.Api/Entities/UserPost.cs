using System.ComponentModel.DataAnnotations;

namespace Forum.Api.Entities;

public class UserPost
{
    [Required]
    [MinLength(1)]
    [MaxLength(25)]
    public string Subject { get; set; }

    [Required]
    [MinLength(1)]
    [MaxLength(140)]
    public string Message { get; set; }
}
