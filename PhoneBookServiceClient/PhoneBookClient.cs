using System.Text.Json;

namespace PhoneBookServiceClient;

public static class PhoneBookClient
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string baseApiEndpoint = "https://localhost:7137/api/contacts";

    static async Task RunAsync()
    {
        try
        {
            // Get all contacts
            Console.WriteLine("-----------------------");
            Console.WriteLine($"All Contacts");
            Console.WriteLine("-----------------------");
            var response = await client.GetAsync(baseApiEndpoint);
            response.EnsureSuccessStatusCode();
            var jsonString = await response.Content.ReadAsStringAsync();
            var contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            if (contacts != null)
            {
                foreach (var c in contacts)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            Console.WriteLine();

            // Get contacts by name
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Contacts by Name");
            Console.WriteLine("-----------------------");
            response = await client.GetAsync($"{baseApiEndpoint}/name/Joe Soap");
            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();
            contacts = JsonSerializer.Deserialize<List<Contact>>(jsonString);
            if (contacts != null)
            {
                foreach (var c in contacts)
                {
                    Console.WriteLine(c.ToString());
                }
            }
            Console.WriteLine();

            // Get contact by phone number
            Console.WriteLine("-----------------------");
            Console.WriteLine($"Contact by Number");
            Console.WriteLine("-----------------------");
            response = await client.GetAsync($"{baseApiEndpoint}/number/01-1111111");
            response.EnsureSuccessStatusCode();
            jsonString = await response.Content.ReadAsStringAsync();
            var contact = JsonSerializer.Deserialize<Contact>(jsonString);
            if (contact != null)
            {
                Console.WriteLine(contact.ToString());
            }
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        RunAsync().Wait();
        client.Dispose();
    }
}