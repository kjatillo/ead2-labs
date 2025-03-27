using System.Runtime.Serialization.Json;
using System.Text;

namespace SmsService.Client;

public class SmsClient
{
    private static readonly HttpClient _client = new HttpClient();
    private static readonly string apiEndpoint = "https://localhost:7010/api";

    static async Task RunPost()
    {
        try
        {
            ShortMessage text = new ShortMessage { Sender = "087 1111111", Receiver = "087 2222222", Message = "Hello there!" };

            // Serialise to JSON
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(ShortMessage));
            serializer.WriteObject(ms, text);

            // Read and create string content for POST
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            StringContent content = new StringContent(sr.ReadToEnd(), Encoding.UTF8, "application/json");

            // HTTP POST
            HttpResponseMessage response = await _client.PostAsync($"{apiEndpoint}/sms", content);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("Message Sent!");
            Console.WriteLine($"Content: {text.Message}");
            Console.WriteLine($"Sender: {text.Sender}");
            Console.WriteLine($"Receiver: {text.Receiver}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        RunPost().Wait();
        _client.Dispose();
    }
}
