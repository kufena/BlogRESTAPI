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

        public ICollection<BlogPost> getAllBlogTitles()
        {
            //var entries = from blog in bpc.BlogPost where blog.Status == true group blog by blog.Id into g select g;
            return new List<BlogPost>(); //entries.ToList<BlogPost>();
        }

        public BlogPost getBlogPost(int id)
        {
            var blogentry = from blog in bpc.BlogPost where blog.Id == id orderby blog.Id, blog.Version select blog;
            return blogentry.FirstOrDefault<BlogPost>();
        }

        public BlogPost updateBlogPost(BlogPost bp)
        {
            var maxver = from blog in bpc.BlogPost where blog.Id == bp.Id group blog by blog.Id into g select new { version = g.Max(x => x.Version) };
            if (maxver.First().version == bp.Version)
            {
                bp.Version += 1;
                bpc.BlogPost.Add(bp);
                bpc.SaveChanges();
                return bp;
            }

            throw new Exception("aaarggh!");
        }
    }
}
