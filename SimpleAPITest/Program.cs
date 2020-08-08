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
            BlogPost bp = new BlogPost(-1, 1, "Here's a new one", DateTime.Now, "nofile", true);
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
                var newbp = new JsonObject<BlogPost>(response.Result.Content.ReadAsStringAsync().Result);
                
                Console.WriteLine("New bp has id " + newbp.Object.Id + " and version " + newbp.Object.Version);
                bp = newbp.Object;
                bp.Title += " wee ";
                bp.Date = DateTime.Now;
                jo = new JsonObject<BlogPost>(bp);
                content = new StringContent(jo.ToString(),System.Text.Encoding.UTF8,"application/json");
                response = http.PutAsync("http://localhost:5000/api/blog", content);
                response.Wait();
                if (response.Result.IsSuccessStatusCode)
                {
                    Console.WriteLine("We've updated it!");
                }
            }

            Console.ReadLine();
        }
    }
}
