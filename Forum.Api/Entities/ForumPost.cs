namespace Forum.Api.Entities;

public class ForumPost
{
    public int ForumPostId { get; set; }
    public UserPost UserPost { get; set; }
    public DateTime Timestamp { get; set; }
}
