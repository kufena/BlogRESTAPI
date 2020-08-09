using BlogRESTAPI.Database;
using BlogRESTAPI.Models;
using BlogRESTAPIModels;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Xunit;

namespace BlogPostAPITest
{
    public class BlogPostUpdateTest
    {
        BlogPostContext newContext()
        {
            return new BlogPostContext(new DbContextOptionsBuilder<BlogPostContext>()
                .UseSqlite(CreateInMemoryDatabase())
                .Options);
        }

        private static DbConnection CreateInMemoryDatabase()
        {
            var connection = new SqliteConnection("Filename=:memory:");

            connection.Open(); 
            var cmd0 = connection.CreateCommand();
            cmd0.CommandText = "create table BlogIds (Id INTEGER PRIMARY KEY)";
            cmd0.ExecuteNonQuery();

            var cmd1 = connection.CreateCommand();
            cmd1.CommandText = "create table BlogPost (Id INTEGER, Title TEXT, Version INTEGER, Date TEXT, File TEXT, Status TEXT, PRIMARY KEY (Id, Version))";
            cmd1.ExecuteNonQuery();

            var cmd2 = connection.CreateCommand();
            cmd2.CommandText = "insert into BlogPost (Id,Title,Version,Date,File,Status) values (1,'Help',1,'2019-01-01','jimbob','live')";
            cmd2.ExecuteNonQuery();

            return connection;
        }

        [Fact]
        public void testUpdate()
        {
            var ctx = newContext();
            var wrapper = new BlogPostCtxWrapper(ctx);
            var oldblog = wrapper.getBlogPost(1);
            // copied because oldblog is written over by the update function, unfortunately.
            var updblog = new DBBlogPost() { Id = oldblog.Id, Title = "Flimsey Fool", Date = DateTime.Now, File = oldblog.File, Status = oldblog.Status, Version = oldblog.Version };
            wrapper.updateBlogPost(updblog);
            var newblog = wrapper.getBlogPost(1);

            Assert.Equal(oldblog.Id, newblog.Id);
            Assert.NotEqual(oldblog.Version, newblog.Version);
            
        }
    }
}
