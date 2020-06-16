using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Test.App.MasterDetailPage;
using Xamarin.Test.App.Model;

namespace Xamarin.Test.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
            Email.Completed += (s, e) => Password.Focus();
            Password.Completed += (s, e) => signup(s, e);

        }
        private void signin(object sender, EventArgs e)
        {
            string username = Email.Text;
            string password = Password.Text;
            LoginAsync(username, password);
        }
        private void signup(object sender, EventArgs e)
        {
            string username = Email.Text;
            string password = Password.Text;

            User user = new User(username, password);
            if (!user.HasPassword(user))
            {
                DisplayAlert("Signup Page", "no pass", "ok");
            }
            else
            {
                DisplayAlert("Signup Page", "pass", "ok");

            }
           // RegisterAsync(user);
        }
        public async void RegisterAsync(User user)
        {
            HttpClient httpClient = new HttpClient();
           


                var jsonObject = JsonConvert.SerializeObject(user);
                var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
                var reponse = await httpClient.PostAsync(new Uri("http://10.0.2.2:5000/register"), content);
                if ((reponse.IsSuccessStatusCode) && (reponse.Content.ToString().Equals("User Created 200OK")))
                {
                    string con = await reponse.Content.ReadAsStringAsync();

                    await DisplayAlert("Login Page", con.ToString(), "ok");
                }
                else
                {
                    string con = await reponse.Content.ReadAsStringAsync();

                    await DisplayAlert("Login Page", con.ToString(), "ok");

                }
            
            
 
        }
        public async void LoginAsync(string username, string password)
        {
            HttpClient httpClient = new HttpClient();
            User user = new User(username, password);
            var jsonObject = JsonConvert.SerializeObject(user);
            var content = new StringContent(jsonObject, Encoding.UTF8, "application/json");
            var reponse = await httpClient.PostAsync(new Uri("http://10.0.2.2:5000/login"), content);
            if ((reponse.IsSuccessStatusCode)&&(!reponse.ToString().Equals("not found"))&&(!reponse.Equals("Wrong Password")))
            {

                string con = await reponse.Content.ReadAsStringAsync();

                var users = JsonConvert.DeserializeObject<List<User>>(con);

                Application.Current.Properties["id"] = users[0].username;
                await Application.Current.SavePropertiesAsync();

                Application.Current.MainPage = new MasterDetailLearningPage();


            }
            else
            {
                string con = await reponse.Content.ReadAsStringAsync();

                await DisplayAlert("Login Page", con.ToString(), "ok");
            }
        }


    }
}