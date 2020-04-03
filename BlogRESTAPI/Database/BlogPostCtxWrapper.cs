using BlogRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BlogRESTAPI.Database
{
    public class BlogPostCtxWrapper : IBlogPostCtxWrapper
    {
        protected BlogPostContext bpc;
        public BlogPostCtxWrapper(BlogPostContext ctx)
        {
            this.bpc = ctx;
        }

        public BlogPost createBlogPost(BlogPost bp)
        {
            // Uses a Blog Ids table to generate unique ids for blog entries.
            var res = bpc.BlogIds.Add(new BlogId());
            bpc.SaveChanges();
            bp.Id = res.CurrentValues.GetValue<int>("Id");
            bp.Version = 0;
            bpc.BlogPost.Add(bp);
            bpc.SaveChanges();
            return bp;
        }

        public BlogPost getBlogPost(int id)
        {
            var blogentry = from blog in bpc.BlogPost where blog.Id == id orderby blog.Id, blog.Version select blog;
            return blogentry.FirstOrDefault<BlogPost>();
        }
    }
}
