using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Moq;
using BlogRESTAPI.Database;
using BlogRESTAPI.Controllers;
using BlogRESTAPI.Models;

namespace BlogPostAPITest
{
    public class BlogPostGetTest
    {
        [Fact]
        public void TestSimpleReturn()
        {
            Mock<IBlogPostCtxWrapper> wrapper = new Mock<IBlogPostCtxWrapper>();
            wrapper.Setup(x => x.getBlogPost(1)).Returns(new BlogRESTAPI.Models.BlogPost(1, 1, "haha", DateTime.Now, "nofile")); //Verify(x => x.getBlogPost(1),)
            BlogController bpc = new BlogController(wrapper.Object);
            var obj = bpc.Get(1);
            Assert.Equal(1, obj.Value.Id);
            Assert.Equal(1, obj.Value.Version);
        }

        [Fact]
        public void TestNullReturn()
        {
            Mock<IBlogPostCtxWrapper> wrapper = new Mock<IBlogPostCtxWrapper>();
            wrapper.Setup(x => x.getBlogPost(1)).Returns<BlogPost>(null);
            BlogController bpc = new BlogController(wrapper.Object);
            var obj = bpc.Get(1);
            Assert.Null(obj.Value);
        }
    }
}
