using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Http.Connections;
using BlogRESTAPI.Models;

namespace SimpleAPITest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            BlogPost bp = new BlogPost(-1, 1, "Here's a new one", DateTime.Now, "nofile");
            var jo = new JsonObject<BlogPost>(bp);
            var s = jo.ToString();
            Console.WriteLine(s);
            Console.WriteLine("sending");
            HttpClient http = new HttpClient();
            HttpContent content = new StringContent(s,System.Text.Encoding.UTF8,"application/json");
            var response = http.PostAsync("http://localhost:5000/api/blog", content);
            response.Wait();
            if (response.Result.IsSuccessStatusCode)
            {
                Console.WriteLine(response.Result.Content.ToString());
            }

            Console.ReadLine();
        }
    }
}
