using System.Text.Json.Serialization;

namespace CodeHub.Client.Models;

class CodeHubRepo
{
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("starredCount")]
    public int StarredCount { get; set; }

    public override string ToString()
    {
        return $"Owner: {Owner} | Repo: {Name} | Stars: {StarredCount}";
    }
}
