using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Test.App.Data;
using Xamarin.Test.App.Model;

namespace Xamarin.Test.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class HomePage : ContentPage
	{
		public HomePage ()
		{
			InitializeComponent ();
            BindingContext = new RestService();
            listPlatforms.RefreshCommand = new Command(() => {
                //Do your stuff.    
                BindingContext = new RestService();

                listPlatforms.IsRefreshing = false;
            });
        }

        private void post_smthing(object sender, EventArgs e)
        {
            string username = (string)Application.Current.Properties["id"];
            Post post = new Post(username, dess.Text, "");
            PostAsync(post);

        }
        public async void PostAsync(Post post)
        {


            HttpClient httpClient = new HttpClient();


            var jsonObject = JsonConvert.SerializeObject(post);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var reponse = await httpClient.PostAsync(new Uri("http://10.0.2.2:5000/addpost"), content);
            if ((reponse.IsSuccessStatusCode) && (reponse.Content.ToString().Equals("Post Created 200OK")))
            {
                string con = await reponse.Content.ReadAsStringAsync();

                await DisplayAlert("Home Page", con.ToString(), "ok");
                
            }
            else
            {
                string con = await reponse.Content.ReadAsStringAsync();

                await DisplayAlert("Home Page", con.ToString(), "ok");

                }
            }

        }


    }
