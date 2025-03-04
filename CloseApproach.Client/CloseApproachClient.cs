using CloseApproach.Client.Models;
using System.Text.Json;

namespace CloseApproach.Client;

static class CloseApproachClient
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string baseApiEndpoint = "https://localhost:7123/api/CloseApproach";

    static async Task RunGetTasksAsync()
    {
        try
        {
            // GET All Asteroids
            var streamTask = client.GetStreamAsync(baseApiEndpoint);
            var asteroids = await JsonSerializer.DeserializeAsync<IEnumerable<Asteroid>>(await streamTask);
            if (asteroids != null)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("GET All Asteroids");
                Console.WriteLine("-------------------------------------");

                foreach (var a in asteroids)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine();
            }

            // GET All Hazardous Asteroids
            streamTask = client.GetStreamAsync($"{baseApiEndpoint}/hazardous");
            asteroids = await JsonSerializer.DeserializeAsync<IEnumerable<Asteroid>>(await streamTask);
            if (asteroids != null)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("GET All Hazardous Asteroids");
                Console.WriteLine("-------------------------------------");

                foreach (var a in asteroids)
                {
                    Console.WriteLine(a);
                }
                Console.WriteLine();
            }

            // GET Closest Asteroid
            streamTask = client.GetStreamAsync($"{baseApiEndpoint}/closest");
            var asteroid = await JsonSerializer.DeserializeAsync<Asteroid>(await streamTask);

            Console.WriteLine("-------------------------------------");
            Console.WriteLine("GET Closest Asteroids by Date");
            Console.WriteLine("-------------------------------------");
            Console.WriteLine(asteroid);
            Console.WriteLine();
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

    static void Main()
    {
        RunGetTasksAsync().Wait();

        client.Dispose();
    }
}
