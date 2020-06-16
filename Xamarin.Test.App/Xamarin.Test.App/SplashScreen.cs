using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Test.App.MasterDetailPage;
using Xamarin.Test.App.Views;

namespace Xamarin.Test.App
{
    public class SplashScreen:ContentPage
    {
        Image SplashImage;
        public SplashScreen()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            var sub = new AbsoluteLayout();
            SplashImage = new Image
            {
                Source = "enchufe.png",
                WidthRequest = 100,
                HeightRequest = 100,

            };
            AbsoluteLayout.SetLayoutFlags(SplashImage, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(SplashImage, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            sub.Children.Add(SplashImage);
            this.BackgroundImage = "back.jpg";
            this.Content = sub;
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(0.9, 1500,Easing.Linear);
            await SplashImage.ScaleTo(150, 1200,Easing.Linear);
            await SplashImage.ScaleTo(1, 2000);
            await SplashImage.ScaleTo(1, 2000);
            if (Application.Current.Properties.ContainsKey("id"))
            {
                Application.Current.MainPage = new MasterDetailLearningPage();
            }
            else { Application.Current.MainPage = new LoginPage(); }
        }
    }
}
