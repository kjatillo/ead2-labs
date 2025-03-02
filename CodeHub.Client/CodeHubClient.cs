using CodeHub.Client.Models;
using System.Text;
using System.Text.Json;

namespace CodeHub.Client;

static class CodeHubClient
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string baseApiEndpoint = "https://localhost:7112/api/Repositories";

    static async Task GetTaskAsync()
    {
        try
        {
            // GET all repos
            var streamTask = client.GetStreamAsync(baseApiEndpoint);
            var repos = await JsonSerializer.DeserializeAsync<IEnumerable<CodeHubRepo>>(await streamTask);
            if (repos != null)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("GET All Repos");
                Console.WriteLine("-------------------------");
                foreach (var r in repos)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();
            }
            else
            {
                throw new ArgumentNullException("No repos found.");
            }

            // GET repo by owner
            streamTask = client.GetStreamAsync($"{baseApiEndpoint}/owner/gclynch1");
            repos = await JsonSerializer.DeserializeAsync<IEnumerable<CodeHubRepo>>(await streamTask);
            if (repos != null)
            {
                Console.WriteLine("-------------------------");
                Console.WriteLine("GET Repos by Owner");
                Console.WriteLine("-------------------------");
                foreach (var r in repos)
                {
                    Console.WriteLine(r);
                }
                Console.WriteLine();
            }
            else
            {
                throw new ArgumentNullException("No repo found.");
            }
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine(hre.Message);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static async Task PostTaskAsync()
    {
        try
        {
            var newRepo = new CodeHubRepo
            {
                Owner = "ken",
                Name = "testrepo",
                StarredCount = 4
            };

            var jsonContent = new StringContent(JsonSerializer.Serialize(newRepo), Encoding.UTF8, "application/json");
            var response = await client.PostAsync($"{baseApiEndpoint}/owner/ken/new", jsonContent);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("-------------------------");
            Console.WriteLine("POST Create New Repo");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Created repository 'testrepo' owned by 'ken' with 4 stars.\n");
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine($"Failed to create repository: {hre.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static async Task PutTaskAsync()
    {
        try
        {
            var response = await client.PutAsync($"{baseApiEndpoint}/owner/gclynch1/repo/repo1/star", null);
            response.EnsureSuccessStatusCode();

            Console.WriteLine("-------------------------");
            Console.WriteLine("PUT Star Repo");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Starred repository 'repo1' owned by 'gclynch1'.\n");
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine($"Failed to update star count: {hre.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
    

    static async Task DeleteTaskAsync()
    {
        try
        {
            var response = await client.DeleteAsync($"{baseApiEndpoint}/owner/ken/repo/testrepo");
            response.EnsureSuccessStatusCode();

            Console.WriteLine("-------------------------");
            Console.WriteLine("DELETE Repo");
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Deleted repository 'testrepo' owned by 'ken'.\n");
        }
        catch (HttpRequestException hre)
        {
            Console.WriteLine($"Failed to delete repository: {hre.Message}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        GetTaskAsync().Wait();
        PostTaskAsync().Wait();
        GetTaskAsync().Wait();
        PutTaskAsync().Wait();
        DeleteTaskAsync().Wait();
        GetTaskAsync().Wait();

        client.Dispose();
    }
}
