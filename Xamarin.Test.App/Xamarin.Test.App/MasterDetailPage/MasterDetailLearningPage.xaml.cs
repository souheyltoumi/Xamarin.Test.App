using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Test.App.Views;

namespace Xamarin.Test.App.MasterDetailPage
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MasterDetailLearningPage : IMasterDetailPageController
    {
		public MasterDetailLearningPage ()
		{
			InitializeComponent ();
            Detail = new NavigationPage(new ProfilPage());
		}

        private void Logout(object sender, EventArgs e)
        {
            Application.Current.Properties.Clear();
             Application.Current.SavePropertiesAsync();
            Navigation.PushModalAsync(new LoginPage());
            IsPresented = false;
        }

        private void profile(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new ProfilPage());
            IsPresented = false;

        }
        private void home(object sender, EventArgs e)
        {
            Detail = new NavigationPage(new HomePage());
            IsPresented = false;

        }
    }
}