﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRESTAPI.Models
{
    public class DBBlogId
    {
        private int _id;

        public DBBlogId()
        {

        }

        public DBBlogId(int id)
        {
            _id = id;
        }

        public int Id { get => _id; set => _id = value; }
    }
}
