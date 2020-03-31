using BlogRESTAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public BlogPost getBlogPost(int id)
        {
            throw new NotImplementedException();
        }
    }
}
