using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MainPageMenu : ContentPage
	{
        public ListView ListView { get { return listView; } }
        public MainPageMenu ()
		{
			InitializeComponent ();
		}

        private void LogoutBtn_Clicked(object sender, EventArgs e)
        {
            Constants.CurrentUser = null;
            Constants.TasksList = null;
            Application.Current.MainPage = new NavigationPage(new LoginPage());
        }
    }
}