using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogRESTAPIModels
{
    /**
     * Class representing a blog post, in its current structural form.
     * There is no id here because they can be a source of confusion, and
     * sometimes (creation time) you don't have one, so I've left it out
     * of the model.  Usually, you either ask for the model with the id,
     * create it so you don't know the id, or get a list, which will give
     * you a link to the post, which is all you need.
     */
    public class BlogPost
    {

        private string _title;
        private int _version;
        private DateTime _date;
        private string _file;
        private bool _status;

        public BlogPost()
        { }

        public BlogPost(int version, string title, DateTime date, string file, bool status)
        {
            this._title = title;
            this._date = date;
            this._file = file;
            this._version = version;
            this._status = status;
        }

        public string Title { get => _title; set => _title = value; }
        public int Version { get => _version; set => _version = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public string File { get => _file; set => _file = value; }
        public bool Status { get => _status; set => _status = value; }

        public (int, bool, string, DateTime, string) Deconstruct()
        {
            return (_version, _status, _title, _date, _file);
        }
    }
}