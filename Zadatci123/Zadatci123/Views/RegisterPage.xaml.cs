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
	public partial class RegisterPage : ContentPage
	{
		public RegisterPage ()
		{
			InitializeComponent ();
		}

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            string name = nameEntry.Text;
            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string passwordConfirm = passwordEntryConfirm.Text;

            if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(email) || String.IsNullOrEmpty(password) || String.IsNullOrEmpty(passwordConfirm))
            {
                await DisplayAlert("Greška!", "Morate popuniti sva polja", "OK");
                return;
            }

            if (password == passwordConfirm)
            {
                registerButton.IsEnabled = false;
                cancelButton.IsEnabled = false;
                registerActivityIndicator.IsVisible = true;

                bool succcess = await RegistrationLogic.Register(name, email, password);
                if (succcess) Application.Current.MainPage = new MainPage();
                else await DisplayAlert("Greška!", "Registracija nije uspjela", "OK");

                registerButton.IsEnabled = true;
                cancelButton.IsEnabled = true;
                registerActivityIndicator.IsVisible = false;
            }
            else
            {
                await DisplayAlert("Greška!", "Lozinke se ne podudaraju", "OK");
            }
        }

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PopAsync(false);
        }

    }
}