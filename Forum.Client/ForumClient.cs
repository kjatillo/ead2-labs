using Forum.Client.Models;
using System.Runtime.Serialization.Json;
using System.Text;

namespace Forum.Client;

static class ForumClient
{
    private static readonly HttpClient client = new HttpClient();
    private static readonly string baseApiEndpoint = "https://localhost:7053/api/posts";

    static async Task RunPost()
    {
        try
        {
            // User post serialised in request body
            UserPost userPost = new UserPost() { Subject = "Cool Subject", Message = "Cool Message" };

            // Serialise to JSON
            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(UserPost));
            serializer.WriteObject(ms, userPost);

            // Read and create string content for POST
            ms.Position = 0;
            StreamReader sr = new StreamReader(ms);
            StringContent content = new StringContent(await sr.ReadToEndAsync(), Encoding.UTF8, "application/json");

            // POST
            HttpResponseMessage response = await client.PostAsync(baseApiEndpoint, content);
            response.EnsureSuccessStatusCode();

            // Read reponse
            ForumPost? forumPost = serializer.ReadObject(await response.Content.ReadAsStreamAsync()) as ForumPost;
            Console.WriteLine($"Created: {forumPost} | URI: {response.Headers.Location}");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }

    static async Task RunGets()
    {
        try
        {
            // GET all posts
            var streamTask = client.GetStreamAsync(baseApiEndpoint);
            var serializer = new DataContractJsonSerializer(typeof(List<ForumPost>));
            var posts = serializer.ReadObject(await streamTask) as List<ForumPost>;
            
            Console.WriteLine("---------------------");
            Console.WriteLine("All Posts");
            Console.WriteLine("---------------------");
            if (posts != null)
            {
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine();

            // GET recent 3 posts
            streamTask = client.GetStreamAsync($"{baseApiEndpoint}/recent/3");
            posts = serializer.ReadObject(await streamTask) as List<ForumPost>;
            
            Console.WriteLine("---------------------");
            Console.WriteLine("Last 5 Posts");
            Console.WriteLine("---------------------");
            if (posts != null)
            {
                foreach (var p in posts)
                {
                    Console.WriteLine(p);
                }
            }
            Console.WriteLine();

            // GET post with ID = 1
            streamTask = client.GetStreamAsync($"{baseApiEndpoint}/id/1");
            serializer = new DataContractJsonSerializer(typeof(ForumPost));
            var post = serializer.ReadObject(await streamTask) as ForumPost;

            Console.WriteLine("---------------------");
            Console.WriteLine("Post with ID: 1");
            Console.WriteLine("---------------------");
            Console.WriteLine($"ID: 1 | Post: {post}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine(e.Message);

        }
    }


    static void Main()
    {
        RunPost().Wait();
        RunGets().Wait();
        client.Dispose();
    }
}
