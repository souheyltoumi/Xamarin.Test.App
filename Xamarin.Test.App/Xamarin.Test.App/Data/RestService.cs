using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Test.App.Model;

namespace Xamarin.Test.App.Data
{
    public class RestService : INotifyPropertyChanged
    {

        public List<Post> _postsList { get; set; }
        public List<Post> PostsList
        {
            get
            {
                return _postsList;
            }
            set
            {
                if (value != _postsList)
                {

                    _postsList = value;
                    NotifyPropertyChanged();
                }
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public RestService()
        {
            GetDataAsync();
        }
        public async void GetDataAsync()
        {
            HttpClient httpClient = new HttpClient();
            var reponse = await httpClient.GetAsync("http://10.0.2.2:5000/viewposts");
            if (reponse.IsSuccessStatusCode)
            {
                var content = await reponse.Content.ReadAsStringAsync();
                var posts = JsonConvert.DeserializeObject<List<Post>>(content);
                PostsList = new List<Post>(posts);
                PostsList.Reverse();
            }
        }


    }


}