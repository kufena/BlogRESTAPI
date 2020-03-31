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

        DbSet<BlogPost> blogPosts;
    }
}
