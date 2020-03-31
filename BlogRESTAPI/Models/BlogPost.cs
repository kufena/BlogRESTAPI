using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRESTAPI.Models
{
    public class BlogPost
    {

        private string title;
        private int id;
        private DateTime date;
        private string file;

        public BlogPost(int id, string title, DateTime dt, string fl)
        {
            this.title = title;
            this.id = id;
            this.date = dt;
            this.file = fl;

            var tt = 5.40m;
            Console.WriteLine("The value is {0}", tt);
        }

        public string Title { get => title; set => title = value; }
        public int Id { get => id; set => id = value; }
        public DateTime Date { get => date; set => date = value; }
        public string File { get => file; set => file = value; }

        public (int, string, DateTime, string) Deconstruct()
        {
            return (id, title, date, file);
        }
    }
}
