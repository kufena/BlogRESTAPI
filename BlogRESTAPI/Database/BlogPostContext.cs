using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogRESTAPI.Models;

namespace BlogRESTAPI.Database
{
    public class BlogPostContext : DbContext
    {
        public BlogPostContext(DbContextOptions options) : base(options)
        { }

        /**
         * A table of blog posts, keyed on Id and Version.
         */
        public DbSet<BlogPost> BlogPost { get; set; }

        /**
         * A table used to auto generate blog ids.  Used for creation only.
         */
        public DbSet<BlogId> BlogIds { get; set; }
    }
}
