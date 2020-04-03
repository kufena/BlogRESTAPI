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
        private int version;
        private DateTime date;
        private string file;

        public BlogPost()
        { }

        public BlogPost(int Id, int Version, string Title, DateTime Date, string File)
        {
            this.title = Title;
            this.id = Id;
            this.date = Date;
            this.file = File;
            this.version = Version;
        }

        public string Title { get => title; set => title = value; }
        public int Id { get => id; set => id = value; }
        public int Version { get => version; set => version = value; }
        public DateTime Date { get => date; set => date = value; }
        public string File { get => file; set => file = value; }

        public (int, string, DateTime, string) Deconstruct()
        {
            return (id, title, date, file);
        }
    }
}
