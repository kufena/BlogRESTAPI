using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogRESTAPI.Models;

namespace BlogRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {

        Random r = new Random();

        [HttpPost]
        public ActionResult<BlogPost> Create(BlogPost post)
        {
            post.Id = 101;
            return post;
        }
        
        [HttpGet]
        public ActionResult<BlogPost> Get(int id)
        {
            if (r.NextDouble() > 0.95)
                return BadRequest("Not Found");
            BlogPost bp = new BlogPost(102, "Here's a thing", DateTime.Now, "");
            return bp;
        }

    }
}