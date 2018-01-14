using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Zadatci123.Logic;

namespace Zadatci123.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class LoginPage : ContentPage
	{
		public LoginPage ()
		{
			InitializeComponent ();
		}

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            string email = emailEntry.Text;
            string password = passwordEntry.Text;

            if (String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password))
            {
                await DisplayAlert("Greška!", "Morate popuniti sva polja", "OK");
                return;
            }
            else
            {
                loginButton.IsEnabled = false;
                registerButton.IsEnabled = false;
                loginActivityIndicator.IsVisible = true;

                bool success = await LoginLogic.Login(email, password);
                if (success) Application.Current.MainPage = new MainPage();
                else await DisplayAlert("Neispravan unos!", "Email ili lozinka nisu ispravni", "OK");

                loginButton.IsEnabled = true;
                registerButton.IsEnabled = true;
                loginActivityIndicator.IsVisible = false;
            }
        }

        private void RegisterButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RegisterPage(), false);
        }

    }
}