using System.Text.Json.Serialization;

namespace CloseApproach.Client.Models;

public class Asteroid
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("diameter")]
    public double Diameter { get; set; }

    [JsonPropertyName("closeApproach")]
    public CloseApproachData CloseApproach { get; set; }

    [JsonPropertyName("isHazardous")]
    public bool IsHazardous { get; set; }

    public override string ToString()
    {
        return $"Diameter: {Diameter} | Approach Date: {CloseApproach.CloseApproachDate} | " +
            $"Distance (Lunar): {CloseApproach.LunarDistance} | Hazardous: {IsHazardous}";
    }
}

