using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Test.App.MasterDetailPage;
using Xamarin.Test.App.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Xamarin.Test.App
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new SplashScreen();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
