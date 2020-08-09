using BlogRESTAPI.Database;
using BlogRESTAPI.Models;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Xunit;

namespace BlogPostAPITest
{
    public class BlogPostCreateTest
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
            
            return connection;
        }

        [Fact]
        public void testBlogPostCreate()
        {
            var ctx = newContext();
            BlogPostCtxWrapper wrapper = new BlogPostCtxWrapper(ctx);
            var writterpost = wrapper.createBlogPost(new DBBlogPost() { Title = "Whatto", Date = DateTime.Now, File = "johnboy", Status = true, Version = 0 });
            Assert.Equal(1, writterpost.Id);
        }
    }
}
