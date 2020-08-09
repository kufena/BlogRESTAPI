using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using BlogRESTAPI.Database;
using BlogRESTAPI.Controllers;
using BlogRESTAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace BlogPostAPITest
{
    public class BlogPostGetTest
    {
        public BlogPostGetTest()
        {
        }

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
            var cmd1 = connection.CreateCommand();
            /*
             * 
        public string Title { get => title; set => title = value; }
        public int Id { get => id; set => id = value; }
        public int Version { get => version; set => version = value; }
        public DateTime Date { get => date; set => date = value; }
        public string File { get => file; set => file = value; }
        public bool Status { get => status; set => status = value; }

            */
            cmd1.CommandText = "create table BlogPost (id INTEGER PRIMARY KEY, Title TEXT, Version INTEGER, Date TEXT, File TEXT, Status TEXT)";
            cmd1.ExecuteNonQuery();
            var cmd2 = connection.CreateCommand();
            cmd2.CommandText = "insert into BlogPost (Title,Version,Date,File,Status) values ('Help',1,'2019-01-01','jimbob','live')";
            cmd2.ExecuteNonQuery();
            
            return connection;
        }

        

        [Fact]
        public void TestSimpleReturn()
        {
            BlogPostContext ctx = newContext();
            BlogPostCtxWrapper wrapper = new BlogPostCtxWrapper(ctx);
            BlogController bpc = new BlogController(wrapper);
            var obj = bpc.Get(1);
            Assert.Equal("Help", obj.Value.Title);
            Assert.Equal(1, obj.Value.Version);
        }

        [Fact]
        public void TestNullReturn()
        {
            BlogPostContext ctx = newContext();
            BlogPostCtxWrapper wrapper = new BlogPostCtxWrapper(ctx);
            BlogController bpc = new BlogController(wrapper);
            var obj = bpc.Get(2);
            Assert.Null(obj.Value);
        }
    }
}
