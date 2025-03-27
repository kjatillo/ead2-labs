using System.Text.Json.Serialization;

namespace CloseApproach.Client.Models;

public class CloseApproachData
{
    [JsonPropertyName("closeApproachDate")]
    public DateTime CloseApproachDate { get; set; }

    [JsonPropertyName("lunarDistance")]
    public double LunarDistance { get; set; }
}
