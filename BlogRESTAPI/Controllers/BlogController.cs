using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogRESTAPI.Models;
using BlogRESTAPI.Database;
using BlogRESTAPI.Utils;
using BlogRESTAPIModels;

namespace BlogRESTAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        IBlogPostCtxWrapper database;

        public BlogController(IBlogPostCtxWrapper db)
        {
            this.database = db;
        }

        [HttpPost]
        public ActionResult<BlogId> Create(BlogPost post)
        {
            DBBlogPost dbpost = DBToAPIModelTransforms.APItoDBBlogPost(post);
            DBBlogPost creation = database.createBlogPost(dbpost);
            BlogId newid = new BlogId(creation.Id, "/blogs/" + creation.Id);
            return newid;
        }
        
        [HttpGet]
        public ActionResult<BlogPost> Get(int id)
        {
            var bp = database.getBlogPost(id);
            if (bp is null)
            {
                return NotFound("No entry with id " + id + " found.");
            }
            return DBToAPIModelTransforms.DBtoAPIBlogPost(bp);
        }

        [HttpPut]
        public ActionResult<BlogPost> Update(int id, BlogPost put)
        {
            return DBToAPIModelTransforms.DBtoAPIBlogPost(database.updateBlogPost(DBToAPIModelTransforms.APItoDBBlogPost(id,put)));
        }

    }
}