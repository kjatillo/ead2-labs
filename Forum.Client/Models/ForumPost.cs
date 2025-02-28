using System.Runtime.Serialization;

namespace Forum.Client.Models;

[DataContract]
class ForumPost
{
    [DataMember(Name = "forumPostId")]
    public int ForumPostId { get; set; }

    [DataMember(Name = "userPost")]
    public UserPost UserPost { get; set;}

    [DataMember(Name = "timestamp")]
    public string Timestamp { get; set; }  // JSON serializer does not support DateTime

    public override string ToString()
    {
        return $"ForumPostId: {ForumPostId} | Subject: {UserPost.Subject} | Message: {UserPost.Message} | Timestamp: {Timestamp}";
    }
}
