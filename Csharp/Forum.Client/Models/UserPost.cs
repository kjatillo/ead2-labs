using System.Runtime.Serialization;

namespace Forum.Client.Models;

[DataContract]
class UserPost
{
    [DataMember(Name = "subject")]
    public string Subject { get; set; }

    [DataMember(Name = "message")]
    public string Message { get; set; }
}
