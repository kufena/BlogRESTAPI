using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogRESTAPI.Models;

namespace BlogRESTAPI.Database
{
    public interface IBlogPostCtxWrapper
    {
        DBBlogPost createBlogPost(DBBlogPost bp);
        DBBlogPost getBlogPost(int id);
        ICollection<DBBlogPost> getAllBlogTitles();

        DBBlogPost updateBlogPost(DBBlogPost bp);
    }
}
