﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogRESTAPI.Models;
using BlogRESTAPI.Database;

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
        public ActionResult<BlogPost> Create(BlogPost post)
        {
            return database.createBlogPost(post);
        }
        
        [HttpGet]
        public ActionResult<BlogPost> Get(int id)
        {
            var bp = database.getBlogPost(id);
            if (bp is null)
            {
                return NotFound("No entry with id " + id + " found.");
            }
            return bp;
        }

        [HttpPut]
        public ActionResult<BlogPost> Update(BlogPost put)
        {
            return database.updateBlogPost(put);
        }

    }
}