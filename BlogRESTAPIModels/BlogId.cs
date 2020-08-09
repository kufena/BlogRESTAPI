using System;
using System.Collections.Generic;
using System.Text;

namespace BlogRESTAPIModels
{
    public class BlogId
    {
        private int _id;
        private string _url;

        public BlogId(int id, string url)
        {
            _id = id;
            _url = url;
        }

        public int Id { get => _id; set => _id = value; }
        public string URL { get => _url; set => _url = value; }
    }
}
