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

        public DBBlogPost createBlogPost(DBBlogPost bp)
        {
            // Uses a Blog Ids table to generate unique ids for blog entries.
            var res = bpc.BlogIds.Add(new DBBlogId());
            bpc.SaveChanges();
            bp.Version = 0;
            bp.Id = res.CurrentValues.GetValue<int>("Id");
            bpc.SaveChanges();
            return bp;
        }

        public ICollection<DBBlogPost> getAllBlogTitles()
        {
            //var entries = from blog in bpc.BlogPost where blog.Status == true group blog by blog.Id into g select g;
            return new List<DBBlogPost>(); //entries.ToList<BlogPost>();
        }

        public DBBlogPost getBlogPost(int id)
        {
            var blogentry = from blog in bpc.BlogPost where blog.Id == id orderby blog.Id, blog.Version select blog;
            return blogentry.FirstOrDefault<DBBlogPost>();
        }

        public DBBlogPost updateBlogPost(DBBlogPost bp)
        {
            var maxver = from blog in bpc.BlogPost where blog.Id == bp.Id group blog by blog.Id into g select new { version = g.Max(x => x.Version) };
            if (maxver.First().version == bp.Version)
            {
                bp.Version += 1;
                bpc.BlogPost.Update(bp); //.Add(bp);
                bpc.SaveChanges();
                return bp;
            }

            throw new Exception("aaarggh!");
        }
    }
}
