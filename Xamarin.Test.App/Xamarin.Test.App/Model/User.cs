using System;
using System.Collections.Generic;
using System.Text;

namespace Xamarin.Test.App.Model
{
    public class User
    {

        public string username{set; get; }
        public string password { set; get; }
        public User(string username,string password)
        {
            this.username = username;
            this.password = password;
        }

        public bool HasPassword(User user)
        {
            if (string.IsNullOrEmpty(user.password) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public User()
        {

        }


    }
}
