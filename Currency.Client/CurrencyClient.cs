using Currency.Client.Models;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace Currency.Client;

static class CurrencyClient
{
    static async Task GetAsync()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7056/api/Currencies/");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("All Currency Pairs");
                    Console.WriteLine("-------------------------");

                    var pairs = await response.Content.ReadFromJsonAsync<IEnumerable<CurrencyPair>>(); // Use ReadFromJsonAsync instead
                    if (pairs != null)
                    {
                        foreach (var pair in pairs)
                        {
                            Console.WriteLine($"Base: {pair.BaseCurrency} | Qoute: {pair.QouteCurrency} | Rate: {pair.Rate}");
                        }
                    }
                    Console.WriteLine();
                }

                response = await client.GetAsync("from/eur");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("All EUR Pairs");
                    Console.WriteLine("-------------------------");

                    var pairs = await response.Content.ReadFromJsonAsync<IEnumerable<CurrencyPair>>();
                    if (pairs != null)
                    {
                        foreach (var pair in pairs)
                        {
                            Console.WriteLine($"Base: {pair.BaseCurrency} | Qoute: {pair.QouteCurrency} | Rate: {pair.Rate}");
                        }
                    }
                    Console.WriteLine();
                }

                response = await client.GetAsync("qoute/usd/eur/100");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("-------------------------");
                    Console.WriteLine("USD 100 to EUR");
                    Console.WriteLine("-------------------------");

                    double qoute = await response.Content.ReadFromJsonAsync<double>();
                    Console.WriteLine($"Qoute: {qoute}");
                }
                Console.WriteLine();
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static async Task UpdateAsync()
    {
        try
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7056/api/Currencies/");
                HttpResponseMessage response = await client.PutAsJsonAsync("usd/eur/1.2", "");
                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Rate Update!");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static void Main()
    {
        GetAsync().Wait();
        UpdateAsync().Wait();
    }
}
