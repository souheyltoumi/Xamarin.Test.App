using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Xamarin.Test.App.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProfilPage : ContentPage
	{
		public ProfilPage ()
		{
            //var id = Application.Current.Properties["id"] ;
            //BindingContext = id;

            InitializeComponent();
            if (Application.Current.Properties.ContainsKey("id"))
            { username.Text = (string)Application.Current.Properties["id"]; }



        }
    }
}