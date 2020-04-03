using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogRESTAPI.Models;

namespace BlogRESTAPI.Database
{
    public interface IBlogPostCtxWrapper
    {
        BlogPost createBlogPost(BlogPost bp);
        BlogPost getBlogPost(int id);
        BlogPost updateBlogPost(BlogPost bp);
    }
}
