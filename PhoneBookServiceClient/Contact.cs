using System.Text.Json.Serialization;

public class Contact
{
    [JsonPropertyName("phoneNumber")]
    public string PhoneNumber { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("address")]
    public string? Address { get; set; }

    public override string ToString()
    {
        return $"Name: {Name} | Phone Number: {PhoneNumber} | Address: {Address}";
    }
}
