using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogRESTAPI.Models;
using BlogRESTAPIModels;

namespace BlogRESTAPI.Utils
{
    public class DBToAPIModelTransforms
    {

        public static BlogPost DBtoAPIBlogPost(DBBlogPost bp)
        {
            return new BlogPost(bp.Version, bp.Title, bp.Date, bp.File, bp.Status);
        }

        public static DBBlogPost APItoDBBlogPost(BlogPost bp)
        {
            DBBlogPost dbbp = new DBBlogPost
            {
                Version = bp.Version,
                Title = bp.Title,
                Date = bp.Date,
                File = bp.File,
                Status = bp.Status
            };
            return dbbp;
        }

        public static DBBlogPost APItoDBBlogPost(int id, BlogPost bp)
        {
            DBBlogPost dbbp = new DBBlogPost
            {
                Id = id,
                Version = bp.Version,
                Title = bp.Title,
                Date = bp.Date,
                File = bp.File,
                Status = bp.Status
            };
            return dbbp;
        }
    }
}
