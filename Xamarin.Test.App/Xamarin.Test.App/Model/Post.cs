using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Test.App.Model
{
    public class Post
    {
        public string username { set; get; }
        public string description { set; get; }
        public string date { set; get; }
        public Post(string username, string description,string date)
        {
            this.username = username;
            this.description = description;
            this.date = date;


        }

        public Post()
        {
        }
    }
}
